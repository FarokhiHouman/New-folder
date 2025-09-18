;

  static BoreholeDeviationSurveysViewModel()
  {
    ObservableCollection<string> observableCollection = new ObservableCollection<string>();
    observableCollection.Add(CoreStrings.CalculateMethod_Tangential);
    observableCollection.Add(CoreStrings.CalculateMethod_MinimumCurvature);
    BoreholeDeviationSurveysViewModel.CalculationMethods = observableCollection;
  }

  public BoreholeDeviationSurveysViewModel(
    WellTrajectory model,
    BoreholeViewModel borehole,
    IWellViewNavigationService wellViewNavigationService = null)
    : base(model)
  {
    BoreholeDeviationSurveysViewModel surveysViewModel = this;
    if (model == (WellTrajectory) null)
      throw new ArgumentNullException(nameof (model));
    this._parent = borehole;
    this.ChartViewModel = this.RegisterContent<ChartAreaDefinition>(new ChartAreaDefinition());
    PropertyInfo property1 = this.GetType().GetProperty(nameof (WellheadDepth));
    if (property1 != (PropertyInfo) null)
      this.ObjectProperties.Add(new PropertySpec(nameof (WellheadDepth), typeof (double))
      {
        Info = property1,
        AssociatedObject = (object) this
      });
    PropertyInfo property2 = this.GetType().GetProperty(nameof (BottomDepth));
    if (property2 != (PropertyInfo) null)
      this.ObjectProperties.Add(new PropertySpec(nameof (BottomDepth), typeof (double))
      {
        Info = property2,
        AssociatedObject = (object) this
      });
    this.DeleteSelectedTrajectoryMeasurementsCommand = (ICommand) new RelayCommand(new Action<object>(this.DeleteSelectedTrajectoryMeasurements), new Predicate<object>(this.CanDeleteSelectedTrajectoryMeasurements));
    this._initializeTask = this.RegisterNewTask((Action) (() => Task.Factory.StartNew((Action) (() => surveysViewModel.Initialize(wellViewNavigationService)))));
  }

  public bool Initialized { get; set; }

  private void Initialize(
    IWellViewNavigationService wellViewNavigationService)
  {
   
