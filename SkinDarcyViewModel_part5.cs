mpletionType].Contains(SkinComponentType.GravelPack);
    }
  }

  public bool IsSkinPerforationSupported
  {
    get
    {
      return SkinDarcyViewModel._skinSupportMappings[this.DataSource.WellCompletionType].Contains(SkinComponentType.Perforation);
    }
  }

  public bool IsSkinFracPackSupported
  {
    get
    {
      return SkinDarcyViewModel._skinSupportMappings[this.DataSource.WellCompletionType].Contains(SkinComponentType.FracPack);
    }
  }

  public bool IsCalculatedSkin
  {
    get => this.DataSource.CalculateMechanicalSkin || this.DataSource.CalculateRateDependentSkin;
  }

  public string DisplayUnitMeasurement
  {
    get => this._displayUnitMeasurement;
    set
    {
      if (!(this._displayUnitMeasurement != value))
        return;
      this._displayUnitMeasurement = value;
      this.OnPropertyChanged(nameof (DisplayUnitMeasurement));
    }
  }

  public string RateDependentGasLiquidSkin
  {
    get => this._rateDependentGasLiquidSkin;
    set
    {
      if (!(this._rateDependentGasLiquidSkin != value))
        return;
      this._rateDependentGasLiquidSkin = value;
      this.OnPropertyChanged(nameof (RateDependentGasLiquidSkin));
    }
  }

  public bool IsOpenHole
  {
    get
    {
      return this.DataSource.WellCompletionType == PointCompletionType.OpenHole || this.DataSource.WellCompletionType == PointCompletionType.OpenHoleGravelPack;
    }
  }

  public bool CanShowSkinMethod
  {
    get
    {
      return this.DataSource.WellCompletionType != PointCompletionType.OpenHole && this.DataSource.WellCompletionType != PointCompletionType.OpenHoleGravelPack && this.DataSource.WellCompletionType != PointCompletionType.FracPack;
    }
  }

  public string CompletionIntervalLabel
  {
    get
    {
      return this.IsOpenHole ? (this.DataSource.RatioType != CompletionRatioType.Absolute ? CoreStrings.SV_Completion_interval_ratio_openhole : CoreStrings.OpenInterval) : (this.Dat
