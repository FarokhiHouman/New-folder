      this.OnPropertyChanged(nameof (OpenHole));
      this.OnPropertyChanged("CanAddCasingSection");
    }
  }

  public bool CanAddCasingSection => this.OpenHole == null;

  public double WellheadDepth
  {
    get
    {
      return !DataHelper.IsNullObject((IDomainObject) this.DataSource) && !DataHelper.IsNullObject((IDomainObject) this.DataSource.WellHead) ? this.DataSource.WellHead.WellheadDepth : double.NaN;
    }
  }

  public TubingConfigType TubingMode
  {
    get => this.DataSource.WellHead.TubingConfig;
    set
    {
      if (!(this.DataSource != (Borehole) null) || value == this.TubingMode)
        return;
      TransactionHelper.InsideTransaction<WellHead>(this.DataSource.WellHead, (Action<INuTransaction>) (transaction => this.DataSource.WellHead.TubingConfig = value));
    }
  }

  public TubingDimensionOption EnterOD
  {
    get => this._enterOD;
    set
    {
      if (this._enterOD == value)
        return;
      this._enterOD = value;
      this.SetValue("EnterODValue", (object) (value == TubingDimensionOption.OuterDiameter));
      this.OnPropertyChanged(nameof (EnterOD));
    }
  }

  public BoreholeTubingDetailViewModel SelectedTubingViewModel
  {
    get => this._selectedTubingViewModel;
    set
    {
      if (this._selectedTubingViewModel == value)
        return;
      this._selectedTubingViewModel = value;
      this.OnPropertyChanged(nameof (SelectedTubingViewModel));
      if (this._selectedTubingViewModel == null || !this._selectedTubingViewModel.DataSource.IsTubingOrTailPipe)
        return;
      this.SelectedIndex = this._selectedTubingViewModel.DataSource.IsTailPipe ? 1 : 0;
    }
  }

  public int SelectedIndex
  {
    get => this._selectedIndex;
    set
    {
      if (value == this._selectedIndex)
        return;
      this._selectedIndex = value;
      this.OnPropertyChanged(nameof (SelectedIndex));
    }
  }

  public bool IsTubingTabControlVisible => this.DataSo
