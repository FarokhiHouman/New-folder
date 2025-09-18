
      this._measurementSubscriptions.Add(this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) measurementViewModel.DataSource, new EventHandler<DomainObjectChangeEventArgs>(this.OnTrajectoryMeasurementChanged))));
    }
    this.OnPropertyChanged("TrajectoryMeasurements");
  }

  private void OnTrajectoryMeasurementChanged(object sender, DomainObjectChangeEventArgs e)
  {
    if (!(sender as TrajectoryMeasurement != (TrajectoryMeasurement) null))
      return;
    this._requiresRecalculation = true;
  }

  private void RecalculateTrajectoryValuesIfNecessary(object sender, NuTransactionEventArgs e)
  {
    if (!this._requiresRecalculation)
      return;
    using (this._measurementSubscriptions.Suspend())
    {
      using (this._recalulateTrajectoryValuesSubscription.Suspend())
      {
        using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
        {
          this._requiresRecalculation = false;
          this.CalculateTrajectoryValues();
          foreach (TrajectoryMeasurementViewModel measurementViewModel in this.TrajectoryMeasurements.Select<ViewModelGridItem<TrajectoryMeasurement>, DomainObjectViewModel<TrajectoryMeasurement>>((Func<ViewModelGridItem<TrajectoryMeasurement>, DomainObjectViewModel<TrajectoryMeasurement>>) (x => x.ViewModel)).OfType<TrajectoryMeasurementViewModel>())
            measurementViewModel.RefreshHorizontalDistance();
          nuTransaction.Commit();
        }
      }
    }
  }

  private void TryFixCurrentPoint(TrajectoryMeasurement currentPoint)
  {
    if (currentPoint == (TrajectoryMeasurement) null)
      return;
    if (this.DataSource.TrajectoryDependantParameter == TrajectoryDependantParameter.MD && double.IsNaN(currentPoint.MeasuredDepth) && !double.IsNaN(currentPoint.TrueVerticalDepth))
      TransactionHelper.InsideTransaction<TrajectoryMeasurement>(currentPoint, (Action<INuTransaction>) (t => currentPoint.MeasuredDepth
