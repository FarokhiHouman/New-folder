] _blackOilProperties = new string[7]
  {
    "WaterCut",
    "GWR",
    "WGR",
    "GLR",
    "LGR",
    "GOR",
    "OGR"
  };
  private readonly Slb.Production.Engineering.Model.StandardDomain.Model _model;
  private DomainObjectChangedSubscription _associatedZoneChanged;
  private Zone _associatedZone;
  private IPRModelType _iprModelType = IPRModelType.None;
  private IIPRModelViewModel _iprModel;
  private bool _completionDeviationCalculatedNeedsUpdate = true;
  private double _completionDeviationCalculated;
  private List<ISubscription> _transientSubscriptionList;
  private bool _engineIsCalculating;
  private ISubscription _IprModelChangedSubscription;
  private bool creatingViewModel;
  private int refreshTestPointsValidation;

  protected FluidLinkViewModel(T link, Slb.Production.Engineering.Model.StandardDomain.Model model)
    : base(link)
  {
    this._model = model;
    if ((object) (link.Location as DownholeLocation) != null)
    {
      this.LocationViewModel = this.RegisterContent<DownholeEquipmentLocationViewModel>(new DownholeEquipmentLocationViewModel((DownholeLocation) link.Location, (NamedItem) link));
      this.RegisterSubscription((ISubscription) new NotifyPropertyChangedSubscription((INotifyPropertyChanged) this.LocationViewModel, new PropertyChangedEventHandler(this.LocationViewModel_PropertyChanged)));
    }
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) link, new EventHandler<DomainObjectChangeEventArgs>(this.OnPerforationChanged)));
    this.TestPoints = this.RegisterContent<GridItemCollection<ViewModelGridItem<CompletionTestPoint>>>(new GridItemCollection<ViewModelGridItem<CompletionTestPoint>>(ViewModel.CurrentDispatcher, new Action<ViewModelGridItem<CompletionTestPoint>>(this.InitializeNewTestPoint)));
    this.FluidSourceViewModel = this.RegisterContent<FluidLinkFluidSourceViewModel>(new FluidLinkFluidSourceViewModel((FluidLink) link, (IFluidLi
