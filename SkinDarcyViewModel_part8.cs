Names.Contains<string>("ReservoirThickness") || e.PropertyNames.Contains<string>("AssociatedFluid"))
      this._skinCalculationPending = true;
    if (e.PropertyNames.Contains<string>("WellCompletionType") || e.PropertyNames.Contains<string>("IsGasModel"))
      this.OnPropertyChanged((string) null);
    else if (e.PropertyNames.Contains<string>("CalculateRateDependentSkin") || e.PropertyNames.Contains<string>("CalculateMechanicalSkin"))
    {
      this.OnPropertyChanged("IsCalculatedSkin");
      this.CalculateSkin();
      this.OnPropertyChanged("Image");
      this.OnPropertyChanged((Expression<Func<object>>) (() => (object) this.CanShowGravelPackSkin));
    }
    else if (e.PropertyNames.Contains<string>("WellboreDiameter") && this.GravelPackViewModel != null)
      this.GravelPackViewModel.SetValue("GravelScreenSize", (object) this.DataSource.FluidLink.Gravel.GravelScreenSize);
    if (!e.PropertyNames.Contains<string>("RatioType"))
      return;
    this.OnPropertyChanged((Expression<Func<object>>) (() => this.CompletionIntervalLabel));
  }

  private void SkinDarcyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
  {
    if (e.PropertyName == null || e.PropertyName == "MechanicalSkin" || e.PropertyName == "RateDependentGasSkin" || e.PropertyName == "RateDependentLiquidSkin" || e.PropertyName == "GravelPackViewModel")
      return;
    if (e.PropertyName == "IsGasModel")
    {
      this.DisplayUnitMeasurement = this.DataSource.IsGasCompletion ? "Inverse_Gas_Flowrate" : "Inverse_Flowrate";
      this.RateDependentGasLiquidSkin = this.DataSource.IsGasCompletion ? "RateDependentGasSkin" : "RateDependentLiquidSkin";
    }
    this._skinCalculationPending = true;
  }

  private void FluidLinkViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
  {
    string[] source = new string[2]
    {
      "SandProductionRatio",
      "SandGrainSize"
    };
    if (e.PropertyName == null || e.PropertyNa
