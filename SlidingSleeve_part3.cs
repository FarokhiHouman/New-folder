agging)
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
    ModelItem slidingSleeve;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      slidingSleeve = (ModelItem) wellString.CreateSlidingSleeve(this.TopDepth);
      nuTransaction.Commit();
    }
    return slidingSleeve;
  }

  public bool CanCreateItem(WellString wellString)
  {
    return wellString.TubingSectionsType == TubingSectionsType.Tubing;
  }

  public Slb.Production.Engineering.Model.StandardDomain.WellHead WellHead { get; set; }
}

