sChangedSubscription;
  private readonly ISubscription _selectedDetailedTailTubingsChangedSubscription;
  private TubingSectionViewModel _openHole;
  private TubingDimensionOption _enterOD;
  private BoreholeTubingDetailViewModel _selectedTubingViewModel;
  private int _selectedIndex;

  public BoreholeTubingViewModel(
    Borehole borehole,
    ITabbedActiveItemNotifier activeWellItemNotifier,
    IWellViewNavigationService wellViewNavigationService = null)
    : this(borehole, activeWellItemNotifier, ServiceDirectory.GetService<IViewService>(), ServiceDirectory.GetService<IDomainObjectHost>(), wellViewNavigationService)
  {
  }

  private BoreholeTubingViewModel(
    Borehole borehole,
    ITabbedActiveItemNotifier activeWellItemNotifier,
    IViewService viewService,
    IDomainObjectHost domainObjectHost,
    IWellViewNavigationService wellViewNavigationService)
    : base(borehole)
  {
    if (DataHelper.IsNullObject((IDomainObject) borehole))
      throw new ArgumentNullException(nameof (borehole));
    this._activeWellItemNotifier = activeWellItemNotifier ?? throw new ArgumentNullException(nameof (activeWellItemNotifier));
    this._viewService = viewService ?? throw new ArgumentNullException(nameof (viewService));
    this._domainObjectHost = domainObjectHost ?? throw new ArgumentNullException(nameof (domainObjectHost));
    wellViewNavigationService?.Register((IWellViewNavigateFromValidation) this);
    this._wellActiveItemSubscription = this.RegisterSubscription((ISubscription) new ActiveItemSelectionChangedSubscription((IActiveItemNotifier) this._activeWellItemNotifier, new EventHandler(this.WellActiveItemChanged)));
    this.TubingSections = this.RegisterContent<GridItemCollection<ViewModelGridItem<TubingSection>>>(new GridItemCollection<ViewModelGridItem<TubingSection>>(ViewModel.CurrentDispatcher, new Action<ViewModelGridItem<TubingSection>>(this.InitializeMainTubingSection)));
    this.TailTubingSections = this.RegisterC
