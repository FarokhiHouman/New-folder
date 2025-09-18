// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder.PipesimFlowPath
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Model.StandardDomain;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder;

public class PipesimFlowPath : BaseDownholeItem
{
  private Pen pen;
  private const int spacing = 8;
  private GuidelineSet guidelineSet;

  public List<FlowSection> FlowSectionCollection { get; } = new List<FlowSection>();

  public Pen Pen
  {
    get => this.pen ?? (this.pen = this.CreateDefaultPen());
    set => this.pen = value;
  }

  private double FlowPathThickness => 1.0;

  public PipesimFlowPath() => this.ZIndex = 9000;

  protected override Drawing CalculateDrawing()
  {
    GeometryGroup geometryGroup = new GeometryGroup();
    this.guidelineSet = new GuidelineSet();
    foreach (FlowSection flowSection in this.FlowSectionCollection)
    {
      this.AddFlowSectionToGeometry(flowSection, geometryGroup, PipesimFlowPath.FlowLinePosition.Left);
      this.AddFlowSectionToGeometry(flowSection, geometryGroup, PipesimFlowPath.FlowLinePosition.Right);
    }
    return (Drawing) new DrawingGroup()
    {
      Children = {
        (Drawing) new GeometryDrawing(this.Background, this.Pen, (Geometry) geometryGroup)
      },
      GuidelineSet = this.guidelineSet
    };
  }

  private void AddFlowSectionToGeometry(
    FlowSection flowSection,
    GeometryGroup geometryGroup,
    PipesimFlowPath.FlowLinePosition flowLineP
