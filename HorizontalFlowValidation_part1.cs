// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder.HorizontalFlowValidation
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder;

internal class HorizontalFlowValidation(IEnumerable<Equipment> modelItems) : FlowValidation(modelItems)
{
  public override bool CanAddFlowSection()
  {
    if (this.FlowPath.ParentString == (WellString) null || this.EndTubingSection == (TubingSection) null || this.StartTubingSection == (TubingSection) null)
      return false;
    return !this.FlowPath.ParentString.IsValidTubing ? this.CanAddCasingFlowSection() : this.CanAddTubingFlowSection();
  }

  private bool CanAddTubingFlowSection()
  {
    bool flag = !this.IsInjection;
    if (!this.FlowSection.IsFlowHorizontal || this.StartTubingSection == (TubingSection) null || !(this.FirstNode is SlidingSleevePathNode firstNode) || !(this.SecondNode is SlidingSleevePathNode secondNode) || firstNode.ParentString == (WellString) null || secondNode.ParentString == (WellString) null || firstNode.VirtualNodeType != secondNode.VirtualNodeType || firstNode.VirtualNodeType == SlidingSleevePathNode.SlidingSleeveVirtualNodeTypes.Esp)
      return true;
    switch (firstNode.VirtualNodeType)
    {
      case SlidingSleevePathNode.SlidingSleeveVirtualNodeTypes.TubingBottom:
        if (this.FlowPath.FlowType == FlowPathType.EmptyCasingTubingFlow)
          return firstNode.ParentString.Flow
