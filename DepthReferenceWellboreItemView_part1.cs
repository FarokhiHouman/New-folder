// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.DepthReferenceWellboreItemView
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using System.Windows.Media;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic;

public class DepthReferenceWellboreItemView : DepthReference, ICreateWellStringItem
{
  private readonly Pen casingBorderPen = new Pen((Brush) Brushes.RoyalBlue, 1.0);
  private readonly Pen tubingBorderPen = new Pen((Brush) Brushes.LightSkyBlue, 1.0);
  private readonly Brush tubingBorderBrush = (Brush) Brushes.LightSkyBlue;
  private readonly Brush casingBorderBursh = (Brush) Brushes.RoyalBlue;

  public DepthReferenceWellboreItemView() => this.OD = 0.0;

  protected override void OnRender(DrawingContext drawingContext)
  {
    if (this.Bounds.Height < 0.1)
      return;
    if (this.SnapsToDevicePixels)
      this.AddGuidelineSet(drawingContext);
    drawingContext.DrawDrawing(this.RenderedDrawing);
  }

  protected override void InitDockingDiameters()
  {
    if (this.TubularString == null)
      return;
    BaseTubularItem upperItem;
    BaseTubularItem lowerItem;
    this.TubularString.TubularItems.GetItemAtDepth(this.TopDepth, out upperItem, out lowerItem);
    if (lowerItem != null)
    {
      this.OD = lowerItem.OD;
      this.ID = 0.0;
    }
    else
    {
      if (upperItem == null)
        return;
      this.OD = upperItem.OD;
      this.ID = 0.0;
    }
  }

  protected overri
