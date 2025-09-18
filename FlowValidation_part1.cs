// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder.FlowValidation
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder;

internal abstract class FlowValidation
{
  public FlowValidation(IEnumerable<Equipment> modelItems) => this.ValidModelItems = modelItems;

  public FlowSection FlowSection { get; set; }

  public TubingSection StartTubingSection { get; set; }

  public TubingSection EndTubingSection { get; set; }

  public Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes.FlowPath FlowPath { get; set; }

  public FlowPathNode FirstNode { get; set; }

  public FlowPathNode SecondNode { get; set; }

  public bool IsInjection { get; set; }

  protected IEnumerable<Equipment> ValidModelItems { get; }

  protected IEnumerable<double> EquipmentDepths<T>() where T : Equipment
  {
    return (IEnumerable<double>) this.ValidModelItems.OfType<T>().Select<T, DownholeLocation>((Func<T, DownholeLocation>) (t => t.Location as DownholeLocation)).Where<DownholeLocation>((Func<DownholeLocation, bool>) (l => l != (DownholeLocation) null)).Select<DownholeLocation, double>((Func<DownholeLocation, double>) (l => l.TopMeasuredDepth)).OrderBy<double, double>((Func<double, double>) (l => l));
  }

  protected bool HasTubingPlugInSection(TubingSection section)
  {
    return this.HasEquipmentInRange<TubingPl
