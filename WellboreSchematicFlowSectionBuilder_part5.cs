(ModelItem) tubingAtDepth1) ? (BaseWellboreItem) null : (BaseWellboreItem) this._modelUiMap.GetElement((ModelItem) tubingAtDepth1);
      flowPoint1.MD = firstNode.MD;
      flowPoint1.ExtendsOutside = firstNode.ParentObject is Slb.Production.Engineering.Model.StandardDomain.Perforation;
      FlowPoint flowPoint2 = new FlowPoint();
      TubingSection tubingAtDepth2 = secondNode.ParentString.GetTubingAtDepth(secondNode.MD, false);
      flowPoint2.ParentItem = DataHelper.IsNullObject((IDomainObject) tubingAtDepth2) || !this._modelUiMap.ContainsKey((ModelItem) tubingAtDepth2) ? (BaseWellboreItem) null : (BaseWellboreItem) this._modelUiMap.GetElement((ModelItem) tubingAtDepth2);
      if (WellboreSchematicFlowSectionBuilder.IsCrossingOverTheGap(flowPoint1, flowPoint2, tubingAtDepth1, tubingAtDepth2))
      {
        if (this.CanAddCrossingOverTheGap(flowPoint1, flowPoint2, secondNode, path))
          sections.AddNewSection(flowPoint1, flowPoint2);
      }
      else
      {
        flowPoint2.MD = secondNode.MD;
        flowPoint2.ExtendsOutside = false;
        bool flag = false;
        double num = double.NaN;
        foreach (double depth in (IEnumerable<double>) depths)
        {
          if (flowPoint2.MD < depth && depth < flowPoint1.MD)
          {
            num = depth;
            flag = true;
            break;
          }
        }
        if (flag && !firstNode.IsVirtualNode)
        {
          FlowPoint flowPoint3 = new FlowPoint();
          flowPoint3.MD = num;
          double sectionIdAtDepth1 = WellboreSchematicFlowSectionBuilder.GetSectionIDAtDepth(firstNode.ParentString, flowPoint1.MD);
          double sectionIdAtDepth2 = WellboreSchematicFlowSectionBuilder.GetSectionIDAtDepth(secondNode.ParentString, flowPoint2.MD);
          if (!double.IsNaN(sectionIdAtDepth1) && !double.IsNaN(sectionIdAtDepth2))
          {
            flowPoint3.ParentItem = sectionIdAtDepth2 < sectionIdAtDepth1 ? flowPoint2.ParentItem
