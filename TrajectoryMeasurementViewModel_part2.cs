Changed("HD");
  }

  private void DataSource_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    this.OnPropertyChanged("Inclination");
    this.OnPropertyChanged("Angle");
    this.OnPropertyChanged("TrueVerticalDepth");
    this.OnPropertyChanged("TVD");
    this.OnPropertyChanged("MeasuredDepth");
    this.OnPropertyChanged("MD");
    this.OnPropertyChanged("HorizontalDisplacement");
    this.OnPropertyChanged("HD");
  }

  public bool IsFirstRow
  {
    get => this._isFirstRow;
    set
    {
      if (this._isFirstRow == value)
        return;
      this._isFirstRow = value;
      this.OnPropertyChanged((Expression<Func<object>>) (() => (object) this.IsFirstRow));
    }
  }

  public double Angle
  {
    get => this.DataSource.Inclination;
    set
    {
      if (!(this.DataSource != (TrajectoryMeasurement) null) || !this.ValueDifferent((object) this.Angle, (object) value))
        return;
      this.SetValue("Inclination", (object) value);
      this.OnPropertyChanged(nameof (Angle));
    }
  }

  public double TVD
  {
    get => this.DataSource.TrueVerticalDepth;
    set
    {
      if (!(this.DataSource != (TrajectoryMeasurement) null) || !this.ValueDifferent((object) this.TVD, (object) value))
        return;
      this.SetValue("TrueVerticalDepth", (object) value);
      this.OnPropertyChanged(nameof (TVD));
      if (!this._isFirstRow)
        return;
      this.SetValue("MeasuredDepth", (object) value);
      this.OnPropertyChanged("MD");
      this._parent.WellheadDepth = value;
    }
  }

  public double MD
  {
    get => this.DataSource.MeasuredDepth;
    set
    {
      if (!(this.DataSource != (TrajectoryMeasurement) null) || !this.ValueDifferent((object) this.MD, (object) value))
        return;
      this.SetValue("MeasuredDepth", (object) value);
      this.OnPropertyChanged(nameof (MD));
      if (!this._isFirstRow)
        return;
      this.SetValue("TrueVerticalDepth
