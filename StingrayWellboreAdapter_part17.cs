tings.CurrentCatalog.GetConverter(unitMeasurement2, unit4, unit3);
    wellbore.DisplayUnits.Diameter.ConversionFactor = (double) converter2.Convert(1f);
    wellbore.DisplayUnits.Diameter.Symbol = UnitsHelper.GetDisplaySymbol(unit3.Symbol);
  }

  protected void BeginInvoke(Action method, DispatcherPriority priority)
  {
    if (ViewModel.CurrentDispatcher != null)
      ViewModel.CurrentDispatcher.BeginInvoke((Delegate) method, priority);
    else
      method();
  }

  private void DrawWellHeadImpl()
  {
    if (this._wellHead == (Slb.Production.Engineering.Model.StandardDomain.WellHead) null || !this._wellHead.IsGood || this._wellHead.Boreholes.Count == 0)
      return;
    if (!this._wellboreSchematic.Dispatcher.CheckAccess())
    {
      this._wellboreSchematic.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new StingrayWellboreAdapter.DrawDelegate(this.DrawWellHeadImpl));
    }
    else
    {
      this.ClearWatches();
      Wellbore wellbore = this._wellboreSchematic.Wellbore;
      this.SetupDisplayUnits(wellbore);
      wellbore.BeginUpdate();
      try
      {
        List<BaseWellboreItem> source1 = new List<BaseWellboreItem>();
        List<BaseWellboreItem> source2 = new List<BaseWellboreItem>();
        Slb.Ocean.UI.WellboreSchematic.WellHead wellheadUi = this._wellheadUI;
        foreach (TubularString tubularString in (Collection<TubularString>) wellbore.TubularStrings)
        {
          List<BaseWellboreItem> list = tubularString.Items.Where<BaseWellboreItem>((Func<BaseWellboreItem, bool>) (o => o.Tag != null)).ToList<BaseWellboreItem>();
          source1.AddRange((IEnumerable<BaseWellboreItem>) list);
          source2.AddRange(tubularString.Items.Where<BaseWellboreItem>((Func<BaseWellboreItem, bool>) (o => o.Tag == null)));
        }
        wellbore.Clear();
        this._modelUiMap.Clear();
        this._wellheadUI = (Slb.Ocean.UI.WellboreSchematic.WellHead) null;
        if (this._wellHe
