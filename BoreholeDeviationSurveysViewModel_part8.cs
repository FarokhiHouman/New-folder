    }
        foreach (TrajectoryMeasurement trajectoryMeasurement in source)
        {
          this._measurementSubscriptions.Add(this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) trajectoryMeasurement, new EventHandler<DomainObjectChangeEventArgs>(this.OnTrajectoryMeasurementChanged))));
          bool isFirstRow = trajectoryMeasurement == source.First<TrajectoryMeasurement>();
          this.TrajectoryMeasurements.Add(new ViewModelGridItem<TrajectoryMeasurement>((DomainObjectViewModel<TrajectoryMeasurement>) new TrajectoryMeasurementViewModel(trajectoryMeasurement, isFirstRow, this)));
        }
        if (source.Any<TrajectoryMeasurement>((Func<TrajectoryMeasurement, bool>) (x => !this.IsValidTrajectoryPoint(x, this.SelectedSurveyType))))
          this.CalculateTrajectoryValues();
      }
    }
    this.PrepareChart();
  }

  private void DataSource_Measurements_CollectionChanged(
    object sender,
    NotifyCollectionChangedEventArgs e)
  {
    if (e.OldItems == null)
      return;
    HashSet<TrajectoryMeasurement> itemsDeleted = new HashSet<TrajectoryMeasurement>(e.OldItems.OfType<TrajectoryMeasurement>());
    foreach (ViewModelGridItem<TrajectoryMeasurement> viewModelGridItem in this.TrajectoryMeasurements.Where<ViewModelGridItem<TrajectoryMeasurement>>((Func<ViewModelGridItem<TrajectoryMeasurement>, bool>) (x => itemsDeleted.Contains(x.Data))).ToList<ViewModelGridItem<TrajectoryMeasurement>>())
      this.TrajectoryMeasurements.Remove(viewModelGridItem);
    foreach (ISubscription sub in this._measurementSubscriptions.Where<ISubscription>((Func<ISubscription, bool>) (x => ((IEnumerable<object>) itemsDeleted).Contains<object>(x.Publisher))).ToList<ISubscription>())
    {
      this._measurementSubscriptions.Remove(sub);
      this.UnregisterSubscription(sub);
    }
  }

  private bool CanDeleteSelectedTrajectoryMeasurements(object parameter)
  {
    return parameter is IL
