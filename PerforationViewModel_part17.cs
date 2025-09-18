pe FluidEntry => this.DataSource.FluidEntryType;

  public bool HasSandConfiguration
  {
    get
    {
      return this.DataSource.ParentModel != (Slb.Production.Engineering.Model.StandardDomain.Model) null && this.DataSource.ParentModel.DefaultErosionModel == ErosionModel.Salama2000;
    }
  }

  [DefaultValue(0)]
  public double SandProductionRatio
  {
    get => this.DataSource.SandProductionRatio;
    set
    {
      TransactionHelper.InsideTransaction<Perforation>(this.DataSource, (Action<INuTransaction>) (t => this.DataSource.SandProductionRatio = value));
    }
  }

  [DefaultValue(0.00025)]
  public double SandGrainSize
  {
    get => this.DataSource.SandGrainSize;
    set
    {
      TransactionHelper.InsideTransaction<Perforation>(this.DataSource, (Action<INuTransaction>) (t => this.DataSource.SandGrainSize = value));
    }
  }

  public virtual string ActiveTabHeader
  {
    get => this._activeTabHeader;
    set
    {
      this._activeTabHeader = value;
      this.OnPropertyChanged(nameof (ActiveTabHeader));
    }
  }

  public void SetActiveTabFromProperty(string propertyName)
  {
    if (!PerforationViewModel._propertyToTab.ContainsKey(propertyName))
      return;
    PerforationViewModel.TabNumbers key = PerforationViewModel._propertyToTab[propertyName];
    if (!PerforationViewModel._tabsHeaderMap.ContainsKey(key))
      return;
    this.BeginInvoke((Action) (() => this.ActiveTabHeader = PerforationViewModel._tabsHeaderMap[key]), DispatcherPriority.ApplicationIdle);
  }

  protected override void Dispose(bool disposing)
  {
    this.PropertyChanged -= new PropertyChangedEventHandler(this.PerforationViewModel_PropertyChanged);
    base.Dispose(disposing);
  }

  protected override string GetValidationPropertyNameFromViewModelPropertyName(
    string viewModelPropertyName)
  {
    return viewModelPropertyName.Equals("ItemName", StringComparison.Ordinal) ? ViewModel.GetPropertyName((Expression<
