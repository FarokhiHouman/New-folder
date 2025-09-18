uble Length
  {
    get => !(this.DataSource != (TubingSection) null) ? double.NaN : this.DataSource.Length;
    set
    {
      if (this.DataSource == (TubingSection) null || value.AlmostEqual(this.Length))
        return;
      this.SetValue(nameof (Length), (object) value);
      this.OnPropertyChanged("BottomMD");
    }
  }

  public double OutD
  {
    get
    {
      return !(this.DataSource != (TubingSection) null) ? double.NaN : TubingExtension.GetOuterDiameter(this.DataSource);
    }
    set
    {
      if (this.DataSource == (TubingSection) null || this.OutD.AlmostEqual(value))
        return;
      this.SetValue("InnerDiameter", (DomainObjectViewModel<TubingSection>.SetMethod) (() => TubingExtension.SetOuterDiameter(this.DataSource, value)));
      this.OnPropertyChanged("WallThickness");
      this.OnPropertyChanged(nameof (OutD));
    }
  }

  public double InD
  {
    get => !(this.DataSource != (TubingSection) null) ? double.NaN : this.DataSource.InnerDiameter;
    set
    {
      if (this.DataSource == (TubingSection) null || this.InD.AlmostEqual(value))
        return;
      if (this.parentBorehole.DataSource.EnterODValue && !double.IsNaN(this.WallThickness))
        this.WallThickness += 0.5 * (this.InD - value);
      this.SetValue("InnerDiameter", (object) value);
      this.OnPropertyChanged(nameof (InD));
      this.OnPropertyChanged("OutD");
    }
  }

  public double SectionRoughness
  {
    get => !(this.DataSource != (TubingSection) null) ? double.NaN : this.DataSource.Roughness;
    set
    {
      if (this.DataSource == (TubingSection) null || value.AlmostEqual(this.SectionRoughness))
        return;
      this.SetValue("Roughness", (object) value);
      this.OnPropertyChanged(nameof (SectionRoughness));
    }
  }

  public string SectionCatalogName
  {
    get => !(this.DataSource != (TubingSection) null) ? string.Empty : this.DataSource.CatalogName;
    set
    {
      if (thi
