// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder.WellboreSchematicFlowSectionBuilder
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Media;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder;

internal class WellboreSchematicFlowSectionBuilder
{
  private readonly ISchematicUiElementProvider _modelUiMap;
  private readonly Slb.Production.Engineering.Model.StandardDomain.WellHead _wellHead;
  private readonly bool _showText;
  private List<Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes.FlowPath> _flowPaths;
  private readonly bool _isFlowing;

  public WellboreSchematicFlowSectionBuilder(
    Slb.Production.Engineering.Model.StandardDomain.WellHead well,
    ISchematicUiElementProvider modelUiMap,
    bool showLabels)
  {
    this._modelUiMap = modelUiMap;
    this._showText = showLabels;
    this._wellHead = well;
    this._isFlowing = this._wellHead.WellType != WellType.Advanced;
  }

  public IEnumerable<PipesimFlowPath> DrawWellFlowPaths(TubularString tubularCasingString)
  {
    List<PipesimFlowPath> pipesimFlowPathList = new List<PipesimFlowPath>();
    bool isSolvable = this._wellHead.DefaultBorehole.IsSolvable;
    this._flowPaths = FlowPathDrawi
