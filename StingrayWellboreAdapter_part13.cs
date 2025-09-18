}
    }
    return tubularStringAtDepth;
  }

  private static TubularString GetOutsideTubularStringAtDepthForPerf(
    Wellbore wellbore,
    double depth,
    TubularString stringToIgnore)
  {
    TubularString stringAtDepthForPerf = (TubularString) null;
    double num = double.MaxValue;
    foreach (TubularString tubularString in (Collection<TubularString>) wellbore.TubularStrings)
    {
      BaseTubularItem upperItem;
      BaseTubularItem lowerItem;
      if (tubularString != stringToIgnore && tubularString.TubularType == TubularType.Casing && tubularString.TubularItems.GetItemAtDepth(depth, out upperItem, out lowerItem))
      {
        if (upperItem != null && upperItem.ID < num)
        {
          stringAtDepthForPerf = upperItem.TubularString;
          num = upperItem.ID;
        }
        else if (lowerItem != null && lowerItem.ID < num)
        {
          stringAtDepthForPerf = lowerItem.TubularString;
          num = lowerItem.ID;
        }
      }
    }
    return stringAtDepthForPerf;
  }

  private static TubularString GetInsideTubularStringAtDepth(
    Wellbore wellbore,
    double depth,
    TubularString stringToIgnore)
  {
    TubularString tubularStringAtDepth = (TubularString) null;
    double num = double.MaxValue;
    foreach (TubularString tubularString in (Collection<TubularString>) wellbore.TubularStrings)
    {
      BaseTubularItem upperItem;
      BaseTubularItem lowerItem;
      if (tubularString != stringToIgnore && tubularString.TubularItems.GetItemAtDepth(depth, out upperItem, out lowerItem))
      {
        if (upperItem != null && upperItem.ID < num)
        {
          tubularStringAtDepth = upperItem.TubularString;
          num = upperItem.ID;
        }
        else if (lowerItem != null && lowerItem.ID < num)
        {
          tubularStringAtDepth = lowerItem.TubularString;
          num = lowerItem.ID;
        }
      }
    }
    return tubularStringAtDepth;
  }
