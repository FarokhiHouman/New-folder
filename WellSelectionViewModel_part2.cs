eof (stateService));
    if (domainObjectHost == null)
      throw new ArgumentNullException(nameof (domainObjectHost));
    this._stateService = stateService;
    this._domainObjectHost = domainObjectHost;
    this.AddCommands();
    this.RegisterSubscription((ISubscription) new StateChangedSubscription<ActionEventArgs<string, object, object>>(this._stateService, new Action<ActionEventArgs<string, object, object>>(this.OnStateChanged)));
    WellHeadAccessor facadeAccessor = WellHeadAccessor.GetFacadeAccessor(this._domainObjectHost);
    this.RegisterSubscription((ISubscription) new AccessorCreatedSubscription((AbstractOdtFacadeAccessor) facadeAccessor, new EventHandler<DomainObjectEventGroup>(this.WellHeadAccessor_Created), true));
    this.RegisterSubscription((ISubscription) new AccessorChangedSubscription((AbstractOdtFacadeAccessor) facadeAccessor, new EventHandler<DomainObjectChangeEventArgs>(this.WellHeadAccessor_Changed), true));
    this.RegisterSubscription((ISubscription) new AccessorDeletedSubscription((AbstractOdtFacadeAccessor) facadeAccessor, new EventHandler<DomainObjectEventGroup>(this.WellHeadAccessor_Deleted), true));
    this.RegisterSubscription((ISubscription) new TransactionCompletedSubscription(NuDataManager.TransactionManager, new EventHandler<NuTransactionEventArgs>(this.TransactionManager_TransactionCompleted), true));
  }

  public override string Title => CoreStrings.Wells;

  public DurableId DefaultSelection
  {
    get
    {
      this.BeginRefresh();
      DurableId selectedValueDurableId = this.SelectedValue != null ? this.SelectedValue.DataSource.DurableId : (DurableId) null;
      return !(selectedValueDurableId != (DurableId) null) || !this.Items.Any<NamedItemViewModel>((Func<NamedItemViewModel, bool>) (item => selectedValueDurableId == item.DataSource.DurableId)) ? this.Items.Select<NamedItemViewModel, DurableId>((Func<NamedItemViewModel, DurableId>) (item => item.DataSource.DurableId)).FirstOrDefault<Durab
