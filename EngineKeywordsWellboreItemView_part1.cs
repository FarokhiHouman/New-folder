// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.EngineKeywordsWellboreItemView
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using System.Windows;
using System.Windows.Media;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic;

public class EngineKeywordsWellboreItemView : ExtendedGenericDownholeItem, ICreateWellStringItem
{
  public EngineKeywordsWellboreItemView(WellboreItemView view = WellboreItemView.NONE, bool active = true)
  {
    this.VerticalAlignment = VerticalAlignment.Top;
    this.DockVolumeType = DockVolumeType.Tubular;
    this.View = view;
    if (view == WellboreItemView.NONE)
    {
      this.StencilName = "Wellbore Schematic Stencils";
      this.ShapeName = active ? "EngineKW Downhole Active" : "EngineKW Downhole Inactive";
      this.Shape = this.GetShapeFromStencilNameAndShapeName();
      this.VerticalAlignment = VerticalAlignment.Center;
    }
    else
    {
      this.ShapeName = "CT Pump";
      this.StencilName = "Submersible Pumps";
      this.Shape = this.GetShapeFromStencilNameAndShapeName();
      if (active)
        return;
      this.Background = (Brush) new SolidColorBrush(Color.FromRgb(byte.MaxValue, (byte) 0, (byte) 0));
    }
  }

  public ModelItem CreateWellStringItem(WellString wellString)
  {
    ModelItem engineKeywords;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      engineKeywords = (ModelItem) wellString.CreateEngineKe
