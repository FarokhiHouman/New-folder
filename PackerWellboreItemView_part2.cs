nsaction())
    {
      packer = (ModelItem) wellString.CreatePacker(this.TopDepth);
      nuTransaction.Commit();
    }
    return packer;
  }

  public bool CanCreateItem(WellString wellString)
  {
    if (wellString == (WellString) null || wellString.Borehole == (Borehole) null || wellString.TubingSectionsType != TubingSectionsType.Casing)
      return false;
    Borehole.TubingBottomGap tubingBottomGap = wellString.Borehole.GeTubingBottomGap();
    if (tubingBottomGap != null)
      return !tubingBottomGap.GapRange.IsWithinExcludingStartEnd(this.TopDepth) && this.TopDepth <= tubingBottomGap.MaxTubingSectionDepth;
    if (!(wellString.Borehole.WellHead != (Slb.Production.Engineering.Model.StandardDomain.WellHead) null))
      return true;
    return wellString.Borehole.TubingWellString.IsValidTubing && this.TopDepth <= wellString.Borehole.TubingWellString.CalcTotalLengthTubingOnly();
  }

  public Slb.Production.Engineering.Model.StandardDomain.WellHead WellHead { get; set; }
}

