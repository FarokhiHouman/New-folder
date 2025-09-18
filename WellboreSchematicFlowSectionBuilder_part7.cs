 (n => n.ParentObject)).OfType<Equipment>().ToList<Equipment>();
    for (int index = path.Count - 1; index > 0; --index)
    {
      FlowPathNode firstNode = path[index];
      FlowPathNode secondNode = path[index - 1];
      FlowPoint flowPoint1 = new FlowPoint();
      TubingSection tubingAtDepth1 = firstNode.ParentString.GetTubingAtDepth(firstNode.MD, false);
      flowPoint1.ParentItem = !(tubingAtDepth1 != (TubingSection) null) ? (BaseWellboreItem) null : (this._modelUiMap.ContainsKey((ModelItem) tubingAtDepth1) ? (BaseWellboreItem) this._modelUiMap.GetElement((ModelItem) tubingAtDepth1) : (BaseWellboreItem) null);
      flowPoint1.ExtendsOutside = false;
      flowPoint1.MD = firstNode.MD;
      FlowPoint flowPoint2 = new FlowPoint();
      TubingSection tubingAtDepth2 = secondNode.ParentString.GetTubingAtDepth(secondNode.MD, false);
      flowPoint2.ParentItem = !(tubingAtDepth2 != (TubingSection) null) ? (BaseWellboreItem) null : (this._modelUiMap.ContainsKey((ModelItem) tubingAtDepth2) ? (BaseWellboreItem) this._modelUiMap.GetElement((ModelItem) tubingAtDepth2) : (BaseWellboreItem) null);
      flowPoint2.ExtendsOutside = secondNode.ParentObject is Slb.Production.Engineering.Model.StandardDomain.Perforation;
      flowPoint2.MD = secondNode.MD;
      if (WellboreSchematicFlowSectionBuilder.IsCrossingOverTheGap(flowPoint1, flowPoint2, tubingAtDepth1, tubingAtDepth2))
      {
        if (this.CanAddCrossingOverTheGap(flowPoint1, flowPoint2, secondNode, path))
          sections.AddNewSection(flowPoint1, flowPoint2);
      }
      else
        this.AddFlowSectionIfFlowIsValid(path, sections, flowPoint1, flowPoint2, list, tubingAtDepth1, tubingAtDepth2, firstNode, secondNode, true);
    }
    return sections;
  }

  private void AddFlowSectionIfFlowIsValid(
    Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes.FlowPath path,
    WellboreSchematicFlowSectionBuilder.FlowSectionsUnique sections,
    FlowPoint sta
