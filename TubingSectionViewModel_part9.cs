    goto case SectionType.OpenHole;
      }
      if (value != SectionType.Liner && this.SelectedSectionType == SectionType.Liner)
        this.parentBorehole.Liner = (TubingSectionViewModel) null;
      else if (value == SectionType.Liner && this.SelectedSectionType != SectionType.Liner && this.parentBorehole.Liner == null)
        this.parentBorehole.Liner = this;
      SectionType sectionType = this.DataSource.SectionType;
      this.SetValue("SectionType", (object) value);
      using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
      {
        nuTransaction.Lock((object) this.DataSource);
        this.DataSource.InitializeTubularSection(isSwitchingSectionType: true, oldType: sectionType);
        nuTransaction.Commit();
      }
      this.OnPropertyChanged("TopMD");
      this.OnPropertyChanged("BottomMD");
      this.OnPropertyChanged("InD");
      this.OnPropertyChanged("OutD");
      this.OnPropertyChanged("WallThickness");
      this.OnPropertyChanged("SectionRoughness");
      this.OnPropertyChanged(nameof (SelectedSectionType));
      this.OnPropertyChanged("CasingSectionTypes");
    }
  }

  public BoreholeTubingDetailViewModel DetailViewModel
  {
    get => this._detailViewModel;
    set
    {
      if (this._detailViewModel == value)
        return;
      this._detailViewModel = value;
      this.OnPropertyChanged(nameof (DetailViewModel));
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.DataSource.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.DataSource_Changed);
    base.Dispose(disposing);
  }

  protected override string GetValidationPropertyNameFromViewModelPropertyName(string propertyName)
  {
    if (this.parentBorehole == null || this.parentBorehole.DataSource == (Borehole) null)
      return (string) null;
    bool enterOdValue = this.DataSource.WellString.Borehole.EnterODValue;
    switch (propertyName)
    {
  
