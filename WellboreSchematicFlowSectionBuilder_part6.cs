 : flowPoint1.ParentItem;
            flowPoint3.ExtendsOutside = false;
            sections.AddNewSection(flowPoint1, flowPoint3);
            sections.AddNewSection(flowPoint3, flowPoint2);
          }
        }
        else
          this.AddFlowSectionIfFlowIsValid(path, sections, flowPoint1, flowPoint2, list, tubingAtDepth1, tubingAtDepth2, firstNode, secondNode, false);
      }
    }
    return sections;
  }

  private bool CanAddCrossingOverTheGap(
    FlowPoint start,
    FlowPoint end,
    FlowPathNode secondNode,
    Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes.FlowPath path)
  {
    if (!path.ParentString.IsValidTubing || !path.CanTailPipeFlow)
      return false;
    end.MD = secondNode.MD;
    end.ExtendsOutside = false;
    FlowPathNode flowPathNode = path.FirstOrDefault<FlowPathNode>((Func<FlowPathNode, bool>) (f => f.ParentString != (WellString) null && !f.ParentString.IsValidTubing));
    if (flowPathNode == null)
      return false;
    TubingSection tubingAtDepth = flowPathNode.ParentString.GetTubingAtDepth(start.MD, false);
    if (tubingAtDepth == (TubingSection) null)
      return false;
    start.ParentItem = (BaseWellboreItem) this._modelUiMap.GetElement((ModelItem) tubingAtDepth);
    end.ParentItem = (BaseWellboreItem) this._modelUiMap.GetElement((ModelItem) tubingAtDepth);
    return true;
  }

  private WellboreSchematicFlowSectionBuilder.FlowSectionsUnique CreateInjectionFlowPathSections(
    Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes.FlowPath path)
  {
    WellboreSchematicFlowSectionBuilder.FlowSectionsUnique sections = new WellboreSchematicFlowSectionBuilder.FlowSectionsUnique(this._isFlowing);
    if (path.ParentString == (WellString) null)
      return sections;
    List<Equipment> list = path.Where<FlowPathNode>((Func<FlowPathNode, bool>) (n => n.ParentObject is Equipment)).Select<FlowPathNode, NamedItem>((Func<FlowPathNode, NamedItem>)
