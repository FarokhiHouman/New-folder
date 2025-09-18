aSource.RatioType != CompletionRatioType.Absolute ? CoreResourceStrings.SV_Completion_interval_ratio : CoreStrings.PerforatedInterval);
    }
  }

  public bool CanShowGravelPackSkin
  {
    get
    {
      return this.DataSource.CalculateMechanicalSkin && this.DataSource.WellCompletionType != PointCompletionType.FracPack;
    }
  }

  public void Update()
  {
    if (!this._skinCalculationPending || !this.CalculateSkin())
      return;
    this._skinCalculationPending = false;
  }

  private void UpdateCompletionDeviation()
  {
    if (this.FluidLinkViewModel == null)
      return;
    double deviationCalculated = this.FluidLinkViewModel.CompletionDeviationCalculated;
    if (this.DataSource.CompletionDeviation.AlmostEqual(deviationCalculated))
      return;
    this.SetValue("CompletionDeviation", (object) deviationCalculated);
  }

  private void InitializeGravelPack()
  {
    if (DataHelper.IsNullObject((IDomainObject) this.DataSource.FluidLink.Gravel))
      return;
    this.GravelPackViewModel = this.RegisterContent<GravelPackViewModel>(new GravelPackViewModel(this.DataSource.FluidLink.Gravel, this.DataSource.FluidLink));
    this.RegisterSubscription((ISubscription) new NotifyPropertyChangedSubscription((INotifyPropertyChanged) this.GravelPackViewModel, new PropertyChangedEventHandler(this.GravelPackViewModel_PropertyChanged)));
    this.OnPropertyChanged("GravelPackViewModel");
  }

  private void UpdateCompletionType()
  {
    if (this.FluidLinkViewModel == null || this.CompletionTypeMethods.Contains<PointCompletionType>(this.DataSource.WellCompletionType))
      return;
    List<PointCompletionType> fluidLinkTypeMapping = SkinDarcyViewModel._fluidLinkTypeMappings[this.FluidLinkViewModel.Type];
    if (fluidLinkTypeMapping == null || fluidLinkTypeMapping.Count <= 0)
      return;
    this.SetValue("WellCompletionType", (object) fluidLinkTypeMapping[0]);
  }

  private bool CalculateSkin()
  {
    if (!this.I
