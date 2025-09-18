e DisposableToken DisableItems()
  {
    return this.HasTailPipe && this.TopDepth.AlmostGreaterThanOrEqualTo(this.WellHead.DefaultBorehole.TubingWellString.FirstTailPipe.TopMeasuredDepth) ? new DisposableToken((Action) (() => this.EnableDisableTubingStrings(false)), (Action) (() => this.EnableDisableTubingStrings(true)), true) : new DisposableToken((Action) (() => { }), (Action) (() => { }));
  }

  protected override void TryDocking()
  {
    using (this.DisableItems())
      base.TryDocking();
  }

  public override bool IsDocked
  {
    get
    {
      if (this.WellHead == (Slb.Production.Engineering.Model.StandardDomain.WellHead) null || !this.IsDragged || !this.HasTailPipe)
        return base.IsDocked;
      return base.IsDocked && this.TopDepth.AlmostGreaterThanOrEqualTo(this.WellHead.DefaultBorehole.TubingWellString.CalcTotalLengthTubingOnly()) && this.TopDepth.AlmostLessThan(this.WellHead.DefaultBorehole.CasingWellString.CalcTotalLengthCasingString(true));
    }
  }

  public override ModelItem CreateWellStringItem(WellString wellString)
  {
    ModelItem wellStringItem;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      bool isTailPipe = this.HasTailPipe && this.TopDepth.AlmostGreaterThanOrEqualTo(wellString.FirstTailPipe.TopMeasuredDepth);
      TubingSection tubingSection = wellString.CreateTubingSection(this.TopDepth, isTailPipe);
      tubingSection.InitializeTubularSection(wellString);
      wellStringItem = (ModelItem) tubingSection;
      nuTransaction.Commit();
    }
    return wellStringItem;
  }

  public override bool CanCreateItem(WellString wellString) => true;
}

