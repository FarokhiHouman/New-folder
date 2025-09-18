// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder.VerticalFlowValidation
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes;
using System;
using System.Collections.Generic;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder;

internal class VerticalFlowValidation(IEnumerable<Equipment> modelItems) : FlowValidation(modelItems)
{
  public override bool CanAddFlowSection()
  {
    if (this.FlowSection.IsFlowHorizontal)
      throw new ArgumentException("");
    return !this.NeedToCheckFlowDirection() || this.FlowSection.FlowSource.MD < this.FlowSection.FlowSink.MD == this.IsInjection;
  }

  private bool NeedToCheckFlowDirection()
  {
    return this.IsFirstNodeSlidingSleeve && this.IsSecondNodeSlidingSleeve;
  }

  private bool IsFirstNodeSlidingSleeve
  {
    get
    {
      return this.FirstNode.FlowPathNodeType == FlowPathNodeType.SlidingSleeve && this.FirstNode.IsVirtualNode;
    }
  }

  private bool IsSecondNodeSlidingSleeve
  {
    get
    {
      return this.SecondNode.FlowPathNodeType == FlowPathNodeType.SlidingSleeve && this.SecondNode.IsVirtualNode;
    }
  }
}
