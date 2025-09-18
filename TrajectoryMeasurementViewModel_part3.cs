", (object) value);
      this.OnPropertyChanged("TVD");
      this._parent.WellheadDepth = value;
    }
  }

  public double HD
  {
    get => this.DataSource.HorizontalDisplacement;
    set
    {
      if (!(this.DataSource != (TrajectoryMeasurement) null) || !this.ValueDifferent((object) this.HD, (object) value))
        return;
      this.SetValue("HorizontalDisplacement", (object) value);
      this.OnPropertyChanged(nameof (HD));
    }
  }

  protected override void OnSetValue(PropertySpecEventArgs e)
  {
    if (e.Value is double)
    {
      double val1 = (double) e.Value;
      e.Value = val1 <= 0.0 ? (object) Math.Max(val1, -100000000.0) : (object) Math.Min(val1, 100000000.0);
    }
    base.OnSetValue(e);
  }

  protected override string GetValidationPropertyNameFromViewModelPropertyName(
    string viewModelPropertyName,
    out ModelItem propertyOwner)
  {
    switch (viewModelPropertyName)
    {
      case "TVD":
        propertyOwner = (ModelItem) this.DataSource;
        return "TrueVerticalDepth";
      case "MD":
        propertyOwner = (ModelItem) this.DataSource;
        return "MeasuredDepth";
      case "Angle":
        propertyOwner = (ModelItem) this.DataSource;
        return "Inclination";
      default:
        propertyOwner = (ModelItem) null;
        return viewModelPropertyName;
    }
  }

  protected override string GetPropertyError(string propertyName)
  {
    if (!propertyName.Equals("Angle"))
      return base.GetPropertyError(propertyName);
    bool? nullable1 = this.IsLast();
    if (!nullable1.HasValue)
      return string.Empty;
    if (this.DataSource.WellTrajectory.CalculateUsingTangentialMethod)
    {
      bool? nullable2 = nullable1;
      bool flag = true;
      if (nullable2.GetValueOrDefault() == flag & nullable2.HasValue)
        return string.Empty;
    }
    return !double.IsNaN(this.DataSource.Inclination) ? base.GetPropertyError(propertyName) : CoreStrin
