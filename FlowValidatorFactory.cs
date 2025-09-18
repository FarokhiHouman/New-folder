// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder.FlowValidatorFactory
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes;
using System.Collections.Generic;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder;

internal class FlowValidatorFactory
{
  public static FlowValidation CreateValidator(
    List<Equipment> equipments,
    FlowSection flowSection,
    TubingSection startTubingSection,
    TubingSection endTubingSection,
    FlowPathNode startNode,
    FlowPathNode endNode,
    Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes.FlowPath flowPath,
    bool isInjection)
  {
    FlowValidation validator = !flowSection.IsFlowHorizontal ? (FlowValidation) new VerticalFlowValidation((IEnumerable<Equipment>) equipments) : (FlowValidation) new HorizontalFlowValidation((IEnumerable<Equipment>) equipments);
    validator.FlowSection = flowSection;
    validator.EndTubingSection = endTubingSection;
    validator.StartTubingSection = startTubingSection;
    validator.FirstNode = startNode;
    validator.SecondNode = endNode;
    validator.FlowPath = flowPath;
    validator.IsInjection = isInjection;
    return validator;
  }
}
