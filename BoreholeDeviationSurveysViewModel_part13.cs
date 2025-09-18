 (e => !double.IsNaN(e.MeasuredDepth)));
    using (this._measurementSubscriptions.Where<ISubscription>((Func<ISubscription, bool>) (x => x.Publisher as TrajectoryMeasurement == firstPoint)).Suspend())
      this.DataSource.CalculateValues(firstPoint, source.Where<TrajectoryMeasurement>((Func<TrajectoryMeasurement, bool>) (e => !double.IsNaN(e.MeasuredDepth))).ToList<TrajectoryMeasurement>());
    this.PrepareChart();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this._parent != null && this._parent.DataSource != (Borehole) null && this._parent.DataSource.WellStrings != null)
    {
      foreach (WellString wellString in (IEnumerable<WellString>) this._parent.DataSource.WellStrings)
      {
        wellString.Sections.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.TubingCasingCollection_ModelCollectionChanged);
        foreach (OdtDomainObjectBase section in wellString.GetSections())
          section.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.TubularSection_Changed);
      }
    }
    base.Dispose(disposing);
  }

  protected override string GetValidationPropertyNameFromViewModelPropertyName(
    string propertyName,
    out ModelItem propertyOwner)
  {
    if (propertyName == "WellheadDepth")
    {
      propertyOwner = (ModelItem) this._parent.DataSource.WellHead;
      return propertyName;
    }
    propertyOwner = (ModelItem) null;
    return propertyName;
  }

  private bool IsValidTrajectoryPoint(TrajectoryMeasurement m, DeviationSurveyType surveyType)
  {
    int num = (surveyType == DeviationSurveyType.ThreeDimensional ? 1 : 0) * ((double.IsNaN(m.Azimuth) ? 0 : 1) + (double.IsNaN(m.MaxDogLegSeverity) ? 0 : 1)) + (surveyType == DeviationSurveyType.VerticalDeviation ? 0 : 1) * ((double.IsNaN(m.TrueVerticalDepth) ? 0 : 1) + (double.IsNaN(m.HorizontalDisplacement) ? 0 : 1) + (double.IsNaN(m.MeasuredDepth) ? 0 : 1) + (double.IsNaN(m.Inclination) ? 0 : 1));
