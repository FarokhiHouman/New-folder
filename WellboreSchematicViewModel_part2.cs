IStateService>(), ServiceDirectory.GetService<IUnitServiceSettings>(), ServiceDirectory.GetService<IViewService>())
  {
  }

  private WellboreSchematicViewModel(
    Slb.Production.Engineering.Model.StandardDomain.WellHead wellHead,
    ITabbedActiveItemNotifier activeWellItemNotifier,
    IStateService stateService,
    IUnitServiceSettings unitServiceSettings,
    IViewService viewService)
  {
    if (wellHead == (Slb.Production.Engineering.Model.StandardDomain.WellHead) null)
      throw new ArgumentNullException(nameof (wellHead));
    if (activeWellItemNotifier == null)
      throw new ArgumentNullException(nameof (activeWellItemNotifier));
    if (stateService == null)
      throw new ArgumentNullException(nameof (stateService));
    if (unitServiceSettings == null)
      throw new ArgumentNullException(nameof (unitServiceSettings));
    if (viewService == null)
      throw new ArgumentNullException(nameof (viewService));
    this._activeWellItemNotifier = activeWellItemNotifier;
    this._stateService = stateService;
    this._viewService = viewService;
    this._wellHead = wellHead;
    this._itemSelectedSubscription = this.RegisterSubscription((ISubscription) new ActiveItemSelectionChangedSubscription((IActiveItemNotifier) this._activeWellItemNotifier, new EventHandler(this.WellItemSelectionChanged)));
    if (!wellHead.IsTemplate)
    {
      Network network = wellHead.ParentModel.Networks[0];
      this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) network.Equipment, new NotifyCollectionChangedEventHandler(this.Connections_CollectionChanged)));
      this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) network.Zones, new NotifyCollectionChangedEventHandler(this.Connections_CollectionChanged)));
      this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) network.FlowCorrelatio
