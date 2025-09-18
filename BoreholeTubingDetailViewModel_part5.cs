AnnulusMaterialType>(Enum.GetValues(typeof (AnnulusMaterialType)).Cast<AnnulusMaterialType>());
    this.AnnulusMaterialTypes.Remove(AnnulusMaterialType.Cement);
  }

  private void DataSource_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    foreach (string propertyName in e.PropertyNames)
    {
      if (propertyName == "Grade")
      {
        this.OnPropertyChanged("GradeDisplay");
        break;
      }
      if (propertyName == "Name")
      {
        this.OnPropertyChanged("Name");
        break;
      }
      if (propertyName == "SectionType")
      {
        TransactionHelper.InsideTransaction<TubingSection>(this.DataSource, (Action<INuTransaction>) (tn => this.DataSource.CementTop = double.NaN));
        this.OnPropertyChanged("SelectedSectionType");
        this.OnPropertyChanged("ExpanderHeaderTitle");
        this.OnPropertyChanged("ShowCement");
        break;
      }
      if (propertyName == "TopMeasuredDepth")
      {
        this.OnPropertyChanged("ShowCement");
        break;
      }
      if (propertyName == "AnnulusMaterialType")
      {
        this.OnPropertyChanged("AnnulusMaterialType");
        this.OnPropertyChanged((Expression<Func<object>>) (() => (object) this.DefaultAnnulusMaterialDensity));
        this.OnPropertyChanged("DefaultAnnulusMaterialThermalConductivity");
        this.SetValue("AnnulusMaterialDensity", (object) Constants.DefaultAnnulusMaterialDensities[this.DataSource.AnnulusMaterialType]);
        this.SetValue("FluidThermalConductivity", (object) Constants.DefaultAnnulusMaterialThermalConductivities[this.DataSource.AnnulusMaterialType]);
      }
      if (propertyName == "BoreholeDiameter")
        this.OnPropertyChanged("BoreholeDiameter");
    }
  }

  public double DefaultAnnulusMaterialDensity
  {
    get => Constants.DefaultAnnulusMaterialDensities[this.DataSource.AnnulusMaterialType];
  }

  public double DefaultAnnulusMaterialThermalConductivity
  {
   
