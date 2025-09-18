ellheadForWellPerspectiveViewModel ViewModelFactory(IModelContext modelContext)
  {
    WellheadForWellPerspectiveViewModel perspectiveViewModel = (WellheadForWellPerspectiveViewModel) null;
    if (modelContext is WellheadForWellPerspectiveModelContext)
      perspectiveViewModel = new WellheadForWellPerspectiveViewModel();
    return perspectiveViewModel;
  }

  private static WellHead RelayNewWellValue(
    object parameter,
    CreateWellViewModel createWellViewModel)
  {
    WellHead resultWell = createWellViewModel.ResultWell;
    if (parameter is RelayCommandParameter commandParameter)
      commandParameter.ResultValue = (object) resultWell;
    return resultWell;
  }

  private static void OnLaunch(object parameter)
  {
    try
    {
      Slb.Production.Engineering.UI.Utilities.SetCursor(true);
      WellHead wellHead = parameter as WellHead;
      IViewService service1 = ServiceDirectory.GetService<IViewService>();
      IStateService service2 = ServiceDirectory.GetService<IStateService>();
      if (service2 != null && wellHead == (WellHead) null)
        wellHead = service2.ActiveContext == (DurableId) null ? (WellHead) null : service2.ActiveContext.TryResolveAs<WellHead>();
      if (WorkspaceDataRoot.Current.WorkspaceType == WorkspaceType.Well)
        service1.AddOrActivateView<IModelContext, WellheadForWellPerspectiveViewModel>((IModelContext) new WellheadForWellPerspectiveModelContext());
      else if (wellHead != (WellHead) null)
        service1.ShowActiveContextView((object) wellHead);
      if (!(wellHead != (WellHead) null) || !(parameter is ValidationIssue) || service2 == null)
        return;
      service2.FireStateChangedEvent(new ActionEventArgs<string, object, object>("topic://WellBoreEditorStateChanged", parameter, (object) wellHead));
    }
    catch (Exception ex)
    {
      NuLogger.Error("Error opening wellbore editor", ex);
    }
    finally
    {
      Slb.Production.Engineering.UI.Utili
