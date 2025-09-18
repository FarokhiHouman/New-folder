      return;
    if (!(parameter is RelayCommandParameter))
      ServiceDirectory.GetService<IStateService>()?.SetInputContext(wellHead.DurableId, parameter);
    StateMessageDisplayHelper.DisplayStateMessage(CoreStrings.InsertEquipment, (object) CoreStrings.Well, (object) wellHead.Name, (object) currentWorkspaceModel.Name);
  }

  private static bool CanCreateWell(object parameter)
  {
    return WellCommands.CanOperationBasedOnWellType(true);
  }

  private static bool CanSaveAsTemplate(object parameter)
  {
    return WellCommands.CanOperationBasedOnWellType(true);
  }

  private static void OnSaveAsTemplate(object parameter)
  {
    string str = string.Empty;
    try
    {
      Slb.Production.Engineering.UI.Utilities.SetCursor(true);
      WellHead actualWell = parameter as WellHead;
      if (actualWell == (WellHead) null)
      {
        IStateService service = ServiceDirectory.GetService<IStateService>();
        if (service != null && service.ActiveContext != (DurableId) null)
          actualWell = service.ActiveContext.TryResolveAs<WellHead>();
      }
      if (!(actualWell != (WellHead) null))
        return;
      str = actualWell.Name;
      WellHead well;
      using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
      {
        well = DataHelper.GetCurrentWorkspaceModel().Networks[0].CreateTemplateFromWell(actualWell);
        nuTransaction.Commit();
      }
      if (!(well != (WellHead) null))
        return;
      InvokeHelper.BeginInvoke((Action) (() => StateMessageDisplayHelper.DisplayStateMessage(CoreStrings.SaveAsTemplateSuccessful, (object) well.Name)), DispatcherPriority.ApplicationIdle);
    }
    catch (Exception ex)
    {
      NuLogger.Error(string.Format(CoreStrings.SaveAsTemplateFailed, (object) str), ex);
    }
    finally
    {
      Slb.Production.Engineering.UI.Utilities.SetCursor(false);
    }
  }

  private static bool OnCanImportWell(object parameter) => tru
