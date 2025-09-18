headDepth - num : 0.0;
  }

  private static double GetSectionIDAtDepth(WellString wellString, double depth)
  {
    TubingSection tubingAtDepth = wellString.GetTubingAtDepth(depth, false);
    return !(tubingAtDepth != (TubingSection) null) ? double.NaN : tubingAtDepth.InnerDiameter;
  }

  private static bool IsCrossingOverTheGap(
    FlowPoint start,
    FlowPoint end,
    TubingSection startTubingSection,
    TubingSection endTubingSection)
  {
    if (startTubingSection == (TubingSection) null || endTubingSection == (TubingSection) null || start == null || end == null || start.ParentItem == null || end.ParentItem == null)
      return false;
    if (startTubingSection.IsTubing && endTubingSection.IsTailPipe)
      return true;
    return startTubingSection.IsTailPipe && endTubingSection.IsTubing;
  }

  private WellboreSchematicFlowSectionBuilder.FlowSectionsUnique CreateProductionFlowPathSections(
    Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes.FlowPath path,
    IList<double> depths)
  {
    WellString parentString = path.ParentString;
    WellboreSchematicFlowSectionBuilder.FlowSectionsUnique sections = new WellboreSchematicFlowSectionBuilder.FlowSectionsUnique(this._isFlowing);
    if (parentString == (WellString) null)
      return sections;
    List<Equipment> list = path.Where<FlowPathNode>((Func<FlowPathNode, bool>) (n => n.ParentObject is Equipment)).Select<FlowPathNode, NamedItem>((Func<FlowPathNode, NamedItem>) (n => n.ParentObject)).OfType<Equipment>().ToList<Equipment>();
    for (int index = 0; index < path.Count - 1; ++index)
    {
      FlowPoint flowPoint1 = new FlowPoint();
      FlowPathNode firstNode = path[index];
      FlowPathNode secondNode = path[index + 1];
      TubingSection tubingAtDepth1 = firstNode.ParentString.GetTubingAtDepth(firstNode.MD, false);
      flowPoint1.ParentItem = DataHelper.IsNullObject((IDomainObject) tubingAtDepth1) || !this._modelUiMap.ContainsKey(
