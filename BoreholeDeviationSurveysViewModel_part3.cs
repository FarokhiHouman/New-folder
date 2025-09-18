 this._measurementsAccessor = TrajectoryMeasurementAccessor.GetFacadeAccessor(ServiceDirectory.GetService<IDomainObjectHost>());
    this.TrajectoryMeasurements = this.RegisterContent<GridItemCollection<ViewModelGridItem<TrajectoryMeasurement>>>(new GridItemCollection<ViewModelGridItem<TrajectoryMeasurement>>(ViewModel.CurrentDispatcher, new Action<ViewModelGridItem<TrajectoryMeasurement>>(this.InitializeTrajectoryMeasurement)));
    this.InitializeTrajectoryMeasurements();
    this.UpdateTubularSectionListeners();
    this._wellViewNavigationService = wellViewNavigationService;
    this._recalulateTrajectoryValuesSubscription = this.RegisterSubscription((ISubscription) new TransactionCompletedSubscription(NuDataManager.TransactionManager, new EventHandler<NuTransactionEventArgs>(this.RecalculateTrajectoryValuesIfNecessary)));
    this.Initialized = true;
    this.BeginInvoke((Action) (() =>
    {
      this.OnPropertyChanged("Initialized");
      this.OnPropertyChanged("TrajectoryMeasurements");
    }), DispatcherPriority.Normal);
  }

  public static ObservableCollection<string> CalculationMethods { get; private set; }

  public ICommand DeleteSelectedTrajectoryMeasurementsCommand { get; private set; }

  public ChartAreaDefinition ChartViewModel { get; private set; }

  public GridItemCollection<ViewModelGridItem<TrajectoryMeasurement>> TrajectoryMeasurements { get; private set; }

  public TrajectoryDependantParameter SelectedTrajectoryDependantParameter
  {
    get => this.DataSource.TrajectoryDependantParameter;
    set
    {
      if (!(this.DataSource != (WellTrajectory) null) || value == this.SelectedTrajectoryDependantParameter)
        return;
      this.SetValue("TrajectoryDependantParameter", (object) value);
      this.OnPropertyChanged(nameof (SelectedTrajectoryDependantParameter));
      if (this.DataSource.TrajectoryDependantParameter == TrajectoryDependantParameter.TVD || this.DataSource.CalculateUsingTangentialMethod
