
  }

  private void TubingCasingCollection_ModelCollectionChanged(
    object sender,
    NotifyCollectionChangedEventArgs e)
  {
    this.UpdateTubularSectionListeners();
    this.OnPropertyChanged("BottomDepth");
  }

  private void TubularSection_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    this.UpdateTubularSectionListeners();
    this.OnPropertyChanged("BottomDepth");
  }

  private void UpdateTubularSectionListeners()
  {
    if (this._parent == null || !(this._parent.DataSource != (Borehole) null) || this._parent.DataSource.WellStrings == null)
      return;
    foreach (WellString wellString in (IEnumerable<WellString>) this._parent.DataSource.WellStrings)
    {
      wellString.Sections.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.TubingCasingCollection_ModelCollectionChanged);
      wellString.Sections.CollectionChanged += new NotifyCollectionChangedEventHandler(this.TubingCasingCollection_ModelCollectionChanged);
      foreach (TubingSection section in wellString.GetSections())
      {
        section.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.TubularSection_Changed);
        section.Changed += new EventHandler<DomainObjectChangeEventArgs>(this.TubularSection_Changed);
      }
    }
  }

  public void CalculateTrajectoryValues()
  {
    if (!(this.DataSource != (WellTrajectory) null))
      return;
    List<TrajectoryMeasurement> source = this.SelectedTrajectoryDependantParameter == TrajectoryDependantParameter.MD ? this.GetTrajectoryMeasurementsTableValidNodes() : this.DataSource.GetSortedMeasurements();
    if (source.Count == 0)
      return;
    foreach (TrajectoryMeasurement currentPoint in source.Where<TrajectoryMeasurement>((Func<TrajectoryMeasurement, bool>) (e => double.IsNaN(e.MeasuredDepth))))
      this.TryFixCurrentPoint(currentPoint);
    TrajectoryMeasurement firstPoint = source.First<TrajectoryMeasurement>((Func<TrajectoryMeasurement, bool>)
