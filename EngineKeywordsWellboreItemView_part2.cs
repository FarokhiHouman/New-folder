ywords(this.TopDepth);
      nuTransaction.Commit();
    }
    return engineKeywords;
  }

  public bool CanCreateItem(WellString wellString)
  {
    return wellString.TubingSectionsType == TubingSectionsType.Tubing;
  }

  public Slb.Production.Engineering.Model.StandardDomain.WellHead WellHead { get; set; }
}

