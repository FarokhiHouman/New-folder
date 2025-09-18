 WellboreEventArgs e)
  {
    if (this._wellHead == (Slb.Production.Engineering.Model.StandardDomain.WellHead) null)
      return;
    BaseWellboreItem baseWellboreItem = e.Item;
    if (baseWellboreItem.TubularString == null)
    {
      NuLogger.Debug($"A valid TubularString was not associated with the provided BaseWellboreItem: {baseWellboreItem}");
      baseWellboreItem.Delete();
      e.Cancel = true;
    }
    else
    {
      ModelItemType modelItemType = StingrayWellboreAdapter.GetModelItemType(baseWellboreItem);
      if (modelItemType == ModelItemType.Undefined)
      {
        NuLogger.Debug($"Unable to resolve the ModelItemType associated with the provided BaseWellboreItem: {baseWellboreItem}");
        baseWellboreItem.Delete();
        e.Cancel = true;
      }
      else
      {
        WellString wellString1;
        if (modelItemType != ModelItemType.TubingSection)
        {
          wellString1 = modelItemType != ModelItemType.CasingSection ? (WellString) baseWellboreItem.TubularString.Tag : this._wellHead.Boreholes.First<Borehole>().WellStrings.First<WellString>((Func<WellString, bool>) (x => !x.IsValidTubing));
        }
        else
        {
          WellString casingString = this._wellHead.Boreholes.First<Borehole>().WellStrings.First<WellString>((Func<WellString, bool>) (x => !x.IsValidTubing));
          WellString wellString2 = this._wellHead.Boreholes.First<Borehole>().WellStrings.FirstOrDefault<WellString>((Func<WellString, bool>) (x => x.IsValidTubing));
          if ((object) wellString2 == null)
            wellString2 = this._wellHead.Boreholes.First<Borehole>().WellStrings.FirstOrDefault<WellString>((Func<WellString, bool>) (x => x.GetSections().Count == 0 && x != casingString));
          wellString1 = wellString2;
        }
        if (wellString1 != (WellString) null)
        {
          if (baseWellboreItem is ICreateWellStringItem createWellStringItem && createWellStringItem.CanCreateItem(w
