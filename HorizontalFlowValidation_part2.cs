DirectionType == FlowDirectionType.Injection;
        if (firstNode.ParentString.IsValidTubing)
          return this.IsInjection;
        return !this.HasTubingPlugInSection(this.EndTubingSection) ? flag : this.HasEquipmentInRange<Slb.Production.Engineering.Model.StandardDomain.SlidingSleeve>(this.EquipmentDepths<TubingPlug>().Last<double>(), this.EndTubingSection.BottomMeasuredDepth);
      case SlidingSleevePathNode.SlidingSleeveVirtualNodeTypes.TailTop:
        if (this.FlowPath.FlowType == FlowPathType.EmptyCasingTubingFlow)
          return false;
        return firstNode.ParentString.IsValidTubing ? flag : this.IsInjection;
      default:
        return true;
    }
  }

  private bool CanAddCasingFlowSection()
  {
    bool flag = !this.IsInjection;
    if (!this.FlowSection.IsFlowHorizontal || this.StartTubingSection == (TubingSection) null || !(this.FirstNode is SlidingSleevePathNode firstNode) || !(this.SecondNode is SlidingSleevePathNode secondNode) || firstNode.ParentString == (WellString) null || secondNode.ParentString == (WellString) null || firstNode.VirtualNodeType != secondNode.VirtualNodeType)
      return true;
    switch (firstNode.VirtualNodeType)
    {
      case SlidingSleevePathNode.SlidingSleeveVirtualNodeTypes.TubingBottom:
        if (firstNode.ParentString.IsValidTubing)
          return false;
        return secondNode.ParentString.IsValidTubing ? !this.FlowPath.ParentString.Borehole.FlowPaths.Any<FlowPath>((Func<FlowPath, bool>) (f => f.ParentString.IsValidTubing)) || secondNode.ParentString.FlowDirectionType == FlowDirectionType.Production : (this.HasTubingPlugInSection(this.StartTubingSection) ? this.HasEquipmentInRange<Slb.Production.Engineering.Model.StandardDomain.SlidingSleeve>(this.EquipmentDepths<TubingPlug>().Last<double>(), this.EndTubingSection.BottomMeasuredDepth) : secondNode.ParentString.FlowDirectionType == FlowDirectionType.Injection);
      case SlidingSleevePathNode.SlidingSleeveVirtualNodeTypes
