
    BaseTubularItem baseTubularItem = this.TryDockingAtTubularItem(TubularType.Tubing);
    if (baseTubularItem != null)
    {
      this.OD = baseTubularItem.OD;
      this.ID = baseTubularItem.ID;
    }
    else
      base.TryDocking();
  }

  protected override Size MeasureOverride(Size availableSize)
  {
    return !this.IsDragging ? base.MeasureOverride(availableSize) : new Size(0.001, 0.001);
  }

  protected override void CalculateBounds()
  {
    base.CalculateBounds();
    System.Windows.Rect bounds = this.Bounds;
    if (this.IsDragging)
    {
      bounds.Width = 20.0;
      bounds.Height = bounds.Width / this.AspectRatio;
      this.Bounds = bounds;
    }
    if (this.Shape == null)
      return;
    this.LeftBounds = this.RightBounds = this.Bounds = bounds;
  }

  public bool IsDragging { get; set; }

  public ModelItem CreateWellStringItem(WellString wellString)
  {
    ModelItem singlephaseSeparator;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      singlephaseSeparator = (ModelItem) wellString.CreateSinglephaseSeparator(this.TopDepth);
      nuTransaction.Commit();
    }
    return singlephaseSeparator;
  }

  public bool CanCreateItem(WellString wellString)
  {
    return wellString.TubingSectionsType == TubingSectionsType.Tubing && this.TopDepth <= wellString.CalcTotalLengthTubingOnly();
  }

  public Slb.Production.Engineering.Model.StandardDomain.WellHead WellHead { get; set; }
}

