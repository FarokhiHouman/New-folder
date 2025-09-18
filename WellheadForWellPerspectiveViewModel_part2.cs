Subscription) new StateChangedSubscription<ActionEventArgs<string, object, object>>(stateService, new Action<ActionEventArgs<string, object, object>>(this.OnStateChanged)));
    this.UpdateWell();
  }

  public override string Title => CoreStrings.Well;

  public WellHeadViewModel SelectedWellHeadViewModel
  {
    get => this._wellHeadViewModel;
    set
    {
      if (this._wellHeadViewModel == value)
        return;
      this.UnregisterContent<WellHeadViewModel>(this._wellHeadViewModel);
      this._wellHeadViewModel = value;
      if (this._wellHeadViewModel != null)
      {
        this.RegisterContent<WellHeadViewModel>(this._wellHeadViewModel);
        this._wellHeadViewModel.RibbonService = this._ribbonService;
      }
      this.OnPropertyChanged(nameof (SelectedWellHeadViewModel));
    }
  }

  private void UpdateWell()
  {
    ModelItem modelItem = (ModelItem) null;
    DurableId activeContext = this._stateService.ActiveContext;
    if (activeContext != (DurableId) null)
      modelItem = activeContext.Resolve<ModelItem>();
    this.SelectedWellHeadViewModel = (object) (modelItem as WellHead) != null ? new WellHeadViewModel(modelItem as WellHead, (Func<ContextTabDefinition>) (() => this.RegisterContent<ContextTabDefinition>(new ContextTabDefinition(CoreStrings.Well, typeof (WellheadForWellPerspectiveView))))) : (WellHeadViewModel) null;
    if (this.SelectedWellHeadViewModel == null || this._selectedTab == WellEditorTabs.SummaryTab)
      return;
    this.SelectedWellHeadViewModel.SelectedIndex = (int) this._selectedTab;
    this._selectedTab = WellEditorTabs.SummaryTab;
  }

  private void OnStateChanged(ActionEventArgs<string, object, object> args)
  {
    if (!(args.Key == "topic://InputContext"))
      return;
    this.UpdateWell();
  }

  public byte[] GetContextStream()
  {
    return StreamSerializer.Serialize<WellheadForWellPerspectiveModelContext>(new WellheadForWellPerspectiveModelContext());
  }
}
