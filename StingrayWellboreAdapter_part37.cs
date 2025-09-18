
    this.AddWatch((INotifyCollectionChanged) wellString.Measurements);
    foreach (MeasurementPoint measurement in (IEnumerable<MeasurementPoint>) wellString.Measurements)
    {
      this.AddWatch((ModelItem) measurement);
      DownholeLocation location = measurement.Location as DownholeLocation;
      this.AddWatch((ModelItem) location);
      BaseDownholeItem element = (object) (measurement as Slb.Production.Engineering.Model.StandardDomain.Gauge) == null ? (BaseDownholeItem) StingrayWellboreAdapter.NewNodal(measurement.Name, this._showText) : (BaseDownholeItem) StingrayWellboreAdapter.NewGauge(measurement.Name, this._showText);
      element.TopDepth = location.TopMeasuredDepth;
      element.LabelTrackIndex = 0;
      this.AssociateModelObject((FrameworkElement) element, (ModelItem) measurement);
      StingrayWellboreAdapter.GetOutsideTubularStringAtDepth(wellbore, element.TopDepth, (TubularString) null)?.DownholeItems.Add(element);
    }
  }

  private double GetAValidWellHeadDepth(bool adjust)
  {
    double num = adjust ? 10.0 : 0.0;
    double wellheadDepth = this._wellHead.WellheadDepth;
    return !double.IsNaN(wellheadDepth) && !double.IsInfinity(wellheadDepth) ? this._wellHead.WellheadDepth - num : 0.0;
  }

  private bool RedrawWellAlreadyInProgress { get; set; }

  internal void RedrawWell(object sender = null)
  {
    Slb.Production.Engineering.Model.StandardDomain.Model currentModel = Slb.Production.Engineering.Model.StandardDomain.Model.GetCurrentModel();
    if (this.RedrawWellAlreadyInProgress || currentModel != (Slb.Production.Engineering.Model.StandardDomain.Model) null && currentModel.IsImportingWell)
      return;
    this.RedrawWellAlreadyInProgress = true;
    this.BeginInvoke((Action) (() => this.DrawWellHeadWithSelectionImpl(sender)), DispatcherPriority.ApplicationIdle);
  }

  private bool ValidateTubingSection(TubingSection section)
  {
    if (section == (TubingSection) null)
      return false;

