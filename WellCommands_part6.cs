ties.SetCursor(false);
    }
  }

  private static void OnCreateNewWithoutTemplateAndLaunch(object parameter)
  {
    Slb.Production.Engineering.Model.StandardDomain.Model currentWorkspaceModel = DataHelper.GetCurrentWorkspaceModel();
    WellHead wellWithoutTemplate;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      nuTransaction.Lock((object) currentWorkspaceModel);
      string uniqueName = Slb.Production.Engineering.Common.Utilities.GetUniqueName(CoreStrings.Well, currentWorkspaceModel.DefaultNetwork.Wells.Select<WellHead, string>((Func<WellHead, string>) (item => item.Name)));
      wellWithoutTemplate = currentWorkspaceModel.DefaultNetwork.CreateWellWithoutTemplate(uniqueName);
      nuTransaction.Commit();
    }
    ServiceDirectory.GetService<IStateService>()?.SetInputContext(wellWithoutTemplate.DurableId, (object) typeof (WellCommands));
  }

  private static string GetCommandType(object parameter)
  {
    if (parameter as string == "CommandType_InputTree")
      return "CommandType_InputTree";
    return parameter is CheckableCommandParameter ? "CommandType_Toolbar" : "CommandType_Other";
  }

  private static void OnCreateNewWithTemplateAndLaunch(object parameter)
  {
    Slb.Production.Engineering.Model.StandardDomain.Model currentWorkspaceModel = DataHelper.GetCurrentWorkspaceModel();
    bool canImportWell = true;
    if ((parameter is RelayCommandParameter commandParameter ? commandParameter.Parameter : (object) null) is bool)
      canImportWell = (bool) commandParameter.Parameter;
    CreateWellViewModel createWellViewModel = new CreateWellViewModel(currentWorkspaceModel, WellCommands.GetCommandType(parameter), canImportWell);
    if (!ServiceDirectory.GetService<IViewService>().ShowDialog<CreateWellView>((ViewModel) createWellViewModel))
      return;
    WellHead wellHead = WellCommands.RelayNewWellValue(parameter, createWellViewModel);
    if (!(wellHead != (WellHead) null))

