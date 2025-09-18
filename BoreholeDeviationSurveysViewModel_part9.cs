ist source && source.OfType<ViewModelGridItem<TrajectoryMeasurement>>().Any<ViewModelGridItem<TrajectoryMeasurement>>();
  }

  private void DeleteSelectedTrajectoryMeasurements(object parameter)
  {
    if (!this.CanDeleteSelectedTrajectoryMeasurements(parameter))
      return;
    List<ViewModelGridItem<TrajectoryMeasurement>> list = ((IEnumerable) parameter).OfType<ViewModelGridItem<TrajectoryMeasurement>>().ToList<ViewModelGridItem<TrajectoryMeasurement>>();
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      foreach (ViewModelGridItem<TrajectoryMeasurement> viewModelGridItem in list)
      {
        if (!viewModelGridItem.Data.IsDeletePending)
        {
          nuTransaction.Lock((object) this.DataSource, (object) viewModelGridItem.Data);
          this._measurementsAccessor.Delete(viewModelGridItem.Data);
        }
      }
      nuTransaction.Commit();
    }
    this.PrepareChart();
  }

  private void InitializeTrajectoryMeasurement(ViewModelGridItem<TrajectoryMeasurement> item)
  {
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      nuTransaction.Lock((object) this.DataSource);
      TrajectoryMeasurementViewModel measurementViewModel = new TrajectoryMeasurementViewModel(this._measurementsAccessor.Create(this.DataSource.DataSource));
      if (this.DataSource.Measurements.Count > 0)
        measurementViewModel.HD = this.DataSource.GetMeasurements().Last<TrajectoryMeasurement>().HorizontalDisplacement;
      else if (this.DataSource.Measurements.Count == 0)
      {
        measurementViewModel.MD = this.WellheadDepth;
        measurementViewModel.TVD = this.WellheadDepth;
        measurementViewModel.Angle = 0.0;
        measurementViewModel.HD = 0.0;
      }
      measurementViewModel.DataSource.WellTrajectory = this.DataSource;
      item.ViewModel = (DomainObjectViewModel<TrajectoryMeasurement>) measurementViewModel;
      nuTransaction.Commit();
