sCalculatedSkin || !this._performCalculation)
      return true;
    IEngineCompletionCalculationProvider service = ServiceDirectory.GetService<IEngineCompletionCalculationProvider>();
    ISkinValues skinValues;
    if (this.FluidLinkViewModel.IsValid)
    {
      EngineMessageReporter engineMessageReporter = new EngineMessageReporter(this.Title);
      skinValues = service.CalculateDarcySkin(this.DataSource, this.FluidLinkViewModel.FluidMode, new EngineErrorCallback(engineMessageReporter.OnErrorMessage));
    }
    else
      skinValues = SkinValuesFactory.Empty;
    if (this.DataSource.CalculateMechanicalSkin)
    {
      using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
      {
        nuTransaction.Lock((object) this.DataSource);
        this.DataSource.DamagedZoneSkin = skinValues.DamagedZoneSkin;
        this.DataSource.PerforationSkin = skinValues.PerforationSkin;
        this.DataSource.CompactedZoneSkin = skinValues.CompactedZoneSkin;
        this.DataSource.PartialPenetrationSkin = skinValues.PartialPenetrationSkin;
        this.DataSource.DeviationSkin = skinValues.DeviationSkin;
        this.DataSource.GravelPackSkin = skinValues.GravelPackSkin;
        this.DataSource.FracPackSkin = skinValues.FracPackSkin;
        this.DataSource.MechanicalSkin = skinValues.MechanicalSkin;
        nuTransaction.Commit();
      }
    }
    if (this.DataSource.CalculateRateDependentSkin)
    {
      using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
      {
        nuTransaction.Lock((object) this.DataSource);
        if (this.DataSource.IsGasCompletion)
          this.DataSource.RateDependentGasSkin = skinValues.DynamicSkinSkin;
        else
          this.DataSource.RateDependentLiquidSkin = skinValues.DynamicSkinSkin;
        nuTransaction.Commit();
      }
    }
    return true;
  }

  private void DataSource_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    if (e.Property
