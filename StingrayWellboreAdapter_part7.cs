nsionChange(WellboreView dimension)
  {
    WellSettings.Dimension = dimension;
    this.WellboreSchematic.Wellbore.View = dimension;
  }

  public void HandleSectionalChange(WellboreItemView sectional) => this.SectionalStyle = sectional;

  public void SelectItem(ModelItem item)
  {
    try
    {
      FrameworkElement frameworkElement;
      if (item != (ModelItem) null && this._modelUiMap.TryGetValue(item, out frameworkElement))
      {
        if (!(frameworkElement is BaseWellboreItem baseWellboreItem))
          return;
        this._wellboreSchematic.SelectedItem = baseWellboreItem;
        if (baseWellboreItem.TubularString == null || baseWellboreItem.TubularString.Tag == null)
          return;
        StateMessageDisplayHelper.DisplayStateMessage(CoreStrings.SelectedItemTypeName, (object) this.GetDownholeEquipmentType(baseWellboreItem), (object) baseWellboreItem.Label);
      }
      else
        this._wellboreSchematic.SelectedItem = (BaseWellboreItem) null;
    }
    catch (Exception ex)
    {
    }
  }

  public Slb.Ocean.UI.WellboreSchematic.WellHead CreateWellHead(double od)
  {
    if (this._wellheadUI == null)
    {
      this._wellheadUI = new Slb.Ocean.UI.WellboreSchematic.WellHead();
      this._wellheadUI.Name = "Wellhead";
      this._wellheadUI.OD = od + od / 100.0 * 10.0;
      if (this._wellheadUI.OD.AlmostEqual(0.0, double.Epsilon))
        this._wellheadUI.OD = 0.244475;
      this._wellheadUI.TopDepth = this.GetAValidWellHeadDepth(true);
      this._wellheadUI.Length = 10.0;
      this._wellheadUI.ToolTip = (object) string.Empty;
      if (!this.ShowText)
        this._wellheadUI.IsLabelVisible = false;
      OurWellhead wellheadShape = new OurWellhead();
      Network network;
      IEnumerable<NamedItem> nodeWithNodalPoints;
      if (this._wellHead == (Slb.Production.Engineering.Model.StandardDomain.WellHead) null || (network = this._wellHead.Network) == (Network) null || (nodeWithNodalPoi
