      this._associatedZoneChanged = new DomainObjectChangedSubscription((OdtDomainObjectBase) this._associatedZone, new EventHandler<DomainObjectChangeEventArgs>(this.AssociatedZone_Changed));
      this.ReflectCurrentFluidForValidation();
      this.OnPropertyChanged("Pressure");
      this.OnPropertyChanged("Temperature");
      this.OnPropertyChanged(nameof (AssociatedZone));
    }
  }

  [UnitMeasurement("Pressure")]
  public double Pressure
  {
    get
    {
      return !(this.AssociatedZone != (Zone) null) ? this.DataSource.ReservoirPressure : this.AssociatedZone.Pressure;
    }
    set
    {
      if (this.DataSource.ReservoirPressure == value)
        return;
      this.SetValue("ReservoirPressure", (object) value);
      this.OnPropertyChanged(nameof (Pressure));
    }
  }

  [UnitMeasurement("Temperature")]
  public double Temperature
  {
    get
    {
      return !(this.AssociatedZone != (Zone) null) ? this.DataSource.ReservoirTemperature : this.AssociatedZone.Temperature;
    }
    set
    {
      if (this.DataSource.ReservoirTemperature == value)
        return;
      this.SetValue("ReservoirTemperature", (object) value);
      this.OnPropertyChanged(nameof (Temperature));
    }
  }

  public bool HasFractureConfiguration
  {
    get => this.IPRModelViewModel != null && this.IPRModelViewModel.HasFractureConfiguration;
  }

  public bool HasSkinConfiguration
  {
    get => this.IPRModelViewModel != null && this.IPRModelViewModel.SkinViewModel != null;
  }

  public DownholeEquipmentLocationViewModel LocationViewModel { get; private set; }

  public IPRModelType IPRModelType
  {
    get => this._iprModelType;
    set
    {
      if (this._iprModelType == value)
        return;
      this._iprModelType = value;
      using (this.DataSource.SuspendCalculation())
        this.UpdateIPRModelViewModel();
      this.OnPropertyChanged(nameof (IPRModelType));
      this.RecalculateCompletionModelVal
