bscription((ISubscription) new DomainObjectChangedSubscription(gasliftInjection, (EventHandler<DomainObjectChangeEventArgs>) ((sender, args) => this.RefreshFlowDirection()))));
    this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) this._wellString.Borehole.TubingWellString.DownholeEquipment, new NotifyCollectionChangedEventHandler(this.WellHeadGasLiftInjectionCollection_ModelCollectionChanged)));
  }

  public override string Title => this._wellString.DisplayName;

  public SourceViewModel StreamOutletViewModel { get; }

  public bool IsFlowDirectionReadOnly
  {
    get
    {
      return this._wellString.TubingSectionsType == TubingSectionsType.Casing && this._wellString.Borehole.WellHead.GasliftInjections.Any<GasLiftInjection>();
    }
  }

  public FlowDirectionType FlowDirection
  {
    get => this._wellString.FlowDirectionType;
    set
    {
      TransactionHelper.InsideTransaction<WellString>(this._wellString, (Action<INuTransaction>) (transaction => this._wellString.FlowDirectionType = value));
      this.OnPropertyChanged(nameof (FlowDirection));
    }
  }

  public CheckValveOptions CheckValveOptions
  {
    get => this._wellString.CheckValveSetting;
    set
    {
      TransactionHelper.InsideTransaction<WellString>(this._wellString, (Action<INuTransaction>) (transaction => this._wellString.CheckValveSetting = value));
      this.OnPropertyChanged("FlowDirection");
    }
  }

  private void WellHeadGasLiftInjectionCollection_ModelCollectionChanged(
    object obj,
    NotifyCollectionChangedEventArgs e)
  {
    if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null && e.NewItems.OfType<GasLiftInjection>().Any<GasLiftInjection>())
    {
      foreach (OdtDomainObjectBase eventPublisher in e.NewItems.OfType<GasLiftInjection>())
        this._gasLiftInjectionSubscriptions.Add(this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscri
