s.DataSource == (TubingSection) null)
        return;
      this.SetValue("CatalogName", (object) value);
      this.OnPropertyChanged(nameof (SectionCatalogName));
    }
  }

  public string SectionCatalogLabel
  {
    get => !(this.DataSource != (TubingSection) null) ? string.Empty : this.DataSource.CatalogLabel;
    set
    {
      if (this.DataSource == (TubingSection) null)
        return;
      this.SetValue("CatalogLabel", (object) value);
      this.OnPropertyChanged(nameof (SectionCatalogLabel));
    }
  }

  public double WallThickness
  {
    get
    {
      return !DataHelper.IsNullObject((IDomainObject) this.DataSource) ? this.DataSource.WallThickness : double.NaN;
    }
    set
    {
      if (this.DataSource == (TubingSection) null || this.WallThickness.AlmostEqual(value))
        return;
      this.SetValue(nameof (WallThickness), (object) value);
      this.OnPropertyChanged("OutD");
    }
  }

  public SectionType SelectedSectionType
  {
    get
    {
      return !(this.DataSource != (TubingSection) null) ? SectionType.Casing : this.DataSource.SectionType;
    }
    set
    {
      if (this.DataSource == (TubingSection) null || this.SelectedSectionType == value)
        return;
      switch (value)
      {
        case SectionType.OpenHole:
          if (value == SectionType.OpenHole && this.SelectedSectionType != SectionType.OpenHole && this.parentBorehole.OpenHole == null)
          {
            this.parentBorehole.OpenHole = this;
            break;
          }
          break;
        case SectionType.Tubing:
        case SectionType.TailPipe:
          this.SetValue("SectionType", (object) value);
          this.OnPropertyChanged(nameof (SelectedSectionType));
          return;
        default:
          if (this.SelectedSectionType == SectionType.OpenHole)
          {
            this.parentBorehole.OpenHole = (TubingSectionViewModel) null;
            break;
          }
      
