
    if (this.DataSource.FluidLink.Location != (EquipmentLocation) null)
      this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) this.DataSource.FluidLink.Location, new EventHandler<DomainObjectChangeEventArgs>(this.PerforationLocation_Changed)));
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) this.DataSource, new EventHandler<DomainObjectChangeEventArgs>(this.DataSource_Changed)));
  }

  public bool CanSetWellboreDiameter
  {
    get
    {
      return this.DataSource.DownholeLocation != (DownholeLocation) null && this.DataSource.DownholeLocation.TopMeasuredDepth.IsNotNaN();
    }
  }

  public string BoreholeDiameterToolTip
  {
    get
    {
      return !this.CanSetWellboreDiameter ? CoreResourceStrings.BoreholeDiameterDisabledTooTip : (string) null;
    }
  }

  public bool IsVogelBelowBubblePoint
  {
    get => !this.DataSource.IsGasCompletion && this.DataSource.UseVogelBelowBubblepoint;
  }

  private void PerforationLocation_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    this.OnPropertyChanged((Expression<Func<object>>) (() => (object) this.CanSetWellboreDiameter));
    this.OnPropertyChanged((Expression<Func<object>>) (() => this.BoreholeDiameterToolTip));
  }

  protected override bool UpdateCurveRequired(string property)
  {
    return property == "UseVogelBelowBubblepoint" || property == "UseVogelWaterCutCorrection" || property == "ReservoirThickness" || property == "ReservoirPermeability" || property == "ReservoirRadius" || property == "WellboreDiameter" || property == "FractureHalfLength" || property == "FracturePermeability" || property == "FractureWidth" || property == "UseTransientModel" || property == "Time" || property == "Porosity" || property == "TotalCompressibility";
  }

  protected override string GetPropertyError(string propertyName)
  {
    string propertyError = string.Empty;
  
