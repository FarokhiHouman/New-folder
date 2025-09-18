oryMeasurement>((Func<ViewModelGridItem<TrajectoryMeasurement>, TrajectoryMeasurement>) (x => x.Data)).OrderBy<TrajectoryMeasurement, int>((Func<TrajectoryMeasurement, int>) (x => x.Id)));
    return measurementsTableValidNodes;
  }

  private void InitializeTrajectoryMeasurements()
  {
    if (this.collectionChangedSubscription == null)
      this.RegisterSubscription((ISubscription) (this.collectionChangedSubscription = new CollectionChangedSubscription((INotifyCollectionChanged) this.DataSource.Measurements, new NotifyCollectionChangedEventHandler(this.DataSource_Measurements_CollectionChanged))));
    using (this.collectionChangedSubscription.Suspend())
    {
      if (this.DataSource.Measurements.Count > 0)
      {
        foreach (ViewModelGridItem<TrajectoryMeasurement> viewModelGridItem in this.TrajectoryMeasurements.ToList<ViewModelGridItem<TrajectoryMeasurement>>())
          this.TrajectoryMeasurements.Remove(viewModelGridItem);
        foreach (ISubscription sub in this._measurementSubscriptions.ToList<ISubscription>())
        {
          this._measurementSubscriptions.Remove(sub);
          this.UnregisterSubscription(sub);
        }
        List<TrajectoryMeasurement> source = new List<TrajectoryMeasurement>((IEnumerable<TrajectoryMeasurement>) this.DataSource.GetMeasurements());
        TrajectoryMeasurement previousMeasurement = (TrajectoryMeasurement) null;
        foreach (TrajectoryMeasurement trajectoryMeasurement in source)
        {
          if (previousMeasurement == (TrajectoryMeasurement) null)
          {
            trajectoryMeasurement.HorizontalDisplacement = 0.0;
            this.TryFixCurrentPoint(trajectoryMeasurement);
          }
          else
            trajectoryMeasurement.HorizontalDisplacement = this.DataSource.GetCumulativeHorizontalDisplacement(previousMeasurement.HorizontalDisplacement, previousMeasurement, trajectoryMeasurement);
          previousMeasurement = trajectoryMeasurement;
    
