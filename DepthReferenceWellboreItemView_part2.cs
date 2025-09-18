de void CalculateLocation()
  {
    if (this.IsDocked)
    {
      if (this.TubularString.IsTubing)
      {
        this.BorderPen = this.tubingBorderPen;
        this.Background = this.tubingBorderBrush;
        this.Foreground = this.tubingBorderBrush;
        this.DynamicBrush = this.tubingBorderBrush;
      }
      else
      {
        this.BorderPen = this.casingBorderPen;
        this.Background = this.casingBorderBursh;
        this.Foreground = this.casingBorderBursh;
        this.DynamicBrush = this.casingBorderBursh;
      }
    }
    base.CalculateLocation();
  }

  public ModelItem CreateWellStringItem(WellString wellString)
  {
    ModelItem nodalPoint;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      nodalPoint = (ModelItem) wellString.CreateNodalPoint(this.TopDepth);
      nuTransaction.Commit();
    }
    return nodalPoint;
  }

  public bool CanCreateItem(WellString wellString) => true;

  public Slb.Production.Engineering.Model.StandardDomain.WellHead WellHead { get; set; }
}

