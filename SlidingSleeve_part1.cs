// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.SlidingSleeve
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using System;
using System.Windows;
using System.Windows.Media;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class SlidingSleeve : GenericDownholeItem, IDragItem, ICreateWellStringItem
{
  private readonly ColorCode color;
  private bool isOpen;

  public bool IsOpen
  {
    get => this.isOpen;
    set
    {
      this.isOpen = value;
      this.DrawIcon(this.color);
    }
  }

  public SlidingSleeve(ColorCode itemColor)
  {
    this.color = itemColor;
    this.Name = CoreResourceStrings.EquipmentDataType_SlidingSleeve_SN;
    this.IsKeepAspectRatio = true;
    this.DrawIcon(itemColor);
    this.IsExcludeFromDepthMapping = false;
  }

  private void DrawIcon(ColorCode itemColor)
  {
    DrawingGroup drawingGroup = new DrawingGroup();
    Pen pen = this.isOpen ? new Pen((Brush) Brushes.Black, BaseWellboreItem.BorderThickness) : new Pen((Brush) Brushes.Red, BaseWellboreItem.BorderThickness);
    Brush brush = this.isOpen ? (Brush) Brushes.White : (Brush) Brushes.DarkGray;
    double num = (double) Math.Min(6, 4) / 4.0;
    Point center = new Point(3.0, 2.0);
    GeometryDrawing geometryDrawing1 = (GeometryDrawing) null;
    switch (itemColor)
    {
      case ColorCode.Red:
        geometryDrawing1 = new GeometryDrawing((Brush) Brushes.Red, pen, (Geometry) new RectangleGeometry(new System.Windows.Rect(new Size(
