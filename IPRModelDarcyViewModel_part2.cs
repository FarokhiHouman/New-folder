adonly HashSet<string> _propertyErrors = new HashSet<string>();
  private readonly Dictionary<string, string> _validationErrors = new Dictionary<string, string>();
  private ISubscription _casingSubscription;

  static IPRModelDarcyViewModel()
  {
    IPRModelDarcyViewModel.DarcyCompletionModelProperties.Add(IPRModelDarcyViewModel.boreHolePropertyName);
    foreach (PropertyInfo property in typeof (DarcyCompletionModel).GetProperties())
      IPRModelDarcyViewModel.DarcyCompletionModelProperties.Add(property.Name);
  }

  public IPRModelDarcyViewModel(
    DarcyCompletionModel model,
    Slb.Production.Engineering.Model.StandardDomain.Model _workspaceModel,
    IFluidLinkViewModel link,
    bool performCalculation = true)
    : base(model, link, (ISkinViewModel) new SkinDarcyViewModel(model, link, performCalculation), performCalculation)
  {
    this.workspaceModel = _workspaceModel;
    this.RelativePermeabilityPoints = new GridItemCollection<ViewModelGridItem<RelativePermeabilityPoint>>(ViewModel.CurrentDispatcher, new Action<ViewModelGridItem<RelativePermeabilityPoint>>(this.InitializeNewRelativePermeabilityPoint));
    this.ReservoirShapeOption = this.DataSource.UseDrainageRadius ? ReservoirShapeOption.DrainageRadius : ReservoirShapeOption.ShapeFactor;
    this.PopulatePermeabilityPoints();
    this.RelativePermeabilityPoints.CollectionChanged += new NotifyCollectionChangedEventHandler(this.RelativePermeabilityPoints_CollectionChanged);
    this.RegisterSubscription((ISubscription) new ValidationCompletedSubscription(this.validationService, new EventHandler<ValidateArgs>(this.ValidationService_ValidationCompleted)));
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) this.DataSource, new EventHandler<DomainObjectChangeEventArgs>(this.DataSource_Changed)));
    if (this.DataSource.FluidLink.Location != (EquipmentLocation) null)
      this.RegisterSubscription((ISubscription) new Domain
