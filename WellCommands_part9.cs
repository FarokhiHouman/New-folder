= 0;
    saveFileDialog1.FileName = string.Format(CoreStrings.WorkspaceExtension, (object) wellHead.Name);
    SaveFileDialog saveFileDialog2 = saveFileDialog1;
    if (saveFileDialog2.ShowDialog() != DialogResult.OK)
      return;
    string fileName = saveFileDialog2.FileName;
    IArchiveService service1 = ServiceDirectory.GetService<IArchiveService>();
    IValidationService validationService = ServiceDirectory.GetService<IValidationService>();
    IPluginService service2 = ServiceDirectory.GetService<IPluginService>();
    IStateService service3 = ServiceDirectory.GetService<IStateService>();
    service3.SynchronousProgress.Message = string.Format(CoreStrings.Exporting, (object) wellHead.Name);
    service3.FireStateChangedEvent(new ActionEventArgs<string, object, object>("topic://StartExportingWell", (object) wellHead, (object) wellHead));
    ExportStatus success = WellheadExporter.Export(wellHead, service1.WorkingModelPath, fileName, service2, (Func<IDisposable>) (() => validationService.SuspendValidation()));
    WellCommands.OnExportWellFinished(wellHead.Name, fileName, success, service3);
  }

  private static void OnExportWellFinished(
    string targetWellName,
    string targetFileName,
    ExportStatus success,
    IStateService stateService)
  {
    if (success == ExportStatus.Success)
    {
      stateService.SynchronousProgress.Message = string.Format(CoreStrings.ExportedSuccessfully, (object) targetWellName, (object) targetFileName);
    }
    else
    {
      stateService.SynchronousProgress.Message = CoreStrings.WellExportFailed;
      string message;
      if (WellCommands.WellExportErrorMessageMap.TryGetValue(success, out message))
        NuLogger.Error(message, LogCategories.User);
      else
        NuLogger.Error(CoreStrings.WellExportFailed, LogCategories.User);
    }
  }

  private static bool CanExportWell(object parameter) => parameter is WellHead;

  private static bool CanFindWellAndCanSetWellS
