
    this.TubingCasingCatalogCommand = (ICommand) new RelayCommand(new Action<object>(this.LaunchTubingCasingCatalog));
    foreach (WellString wellString in (IEnumerable<WellString>) borehole.WellStrings)
    {
      this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) wellString.Sections, new NotifyCollectionChangedEventHandler(this.WellStringSectionsCollection_ModelCollectionChanged)));
      this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) wellString, new EventHandler<DomainObjectChangeEventArgs>(this.OnWellStringChanged)));
    }
    this._enterOD = borehole.EnterODValue ? TubingDimensionOption.OuterDiameter : TubingDimensionOption.WallThickness;
    if (!(this.DataSource.WellHead != (WellHead) null))
      return;
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) this.DataSource.WellHead, new EventHandler<DomainObjectChangeEventArgs>(this.OnWellHeadChanged)));
  }

  public ICommand DeleteSelectedItemsCommand { get; }

  public ICommand TubingCasingCatalogCommand { get; }

  public bool CanAddTailPipe => this.DataSource.CanAddTailPipe();

  public GridItemCollection<ViewModelGridItem<TubingSection>> TubingSections { get; private set; }

  public GridItemCollection<ViewModelGridItem<TubingSection>> TailTubingSections { get; }

  public GridItemCollection<ViewModelGridItem<TubingSection>> CasingSections { get; }

  public TubingSectionViewModel Liner { get; set; }

  public ObservableCollection<ViewModelGridItem<TubingSection>> SelectedDetailedCasings { get; }

  public ObservableCollection<ViewModelGridItem<TubingSection>> SelectedDetailedTubings { get; }

  public ObservableCollection<ViewModelGridItem<TubingSection>> SelectedDetailedTailTubings { get; }

  public TubingSectionViewModel OpenHole
  {
    get => this._openHole;
    set
    {
      this._openHole = value;

