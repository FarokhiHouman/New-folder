// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.DownholeSeparator
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
namespace Slb.Production.Engineering.Views.Well;

public class DownholeSeparator : GenericDownholeItem, IDragItem, ICreateWellStringItem
{
  private readonly bool isActive = true;

  public DownholeSeparator(ColorCode itemColor, bool active = true)
  {
    this.isActive = active;
    this.Name = CoreResourceStrings.EquipmentDataType_Separator_SN;
    this.IsKeepAspectRatio = true;
    this.DrawIcon(itemColor);
    this.IsExcludeFromDepthMapping = false;
  }

  private void DrawIcon(ColorCode itemColor)
  {
    DrawingGroup drawingGroup = new DrawingGroup();
    Pen pen = this.isActive ? new Pen((Brush) Brushes.Black, BaseWellboreItem.BorderThickness) : new Pen((Brush) Brushes.Red, BaseWellboreItem.BorderThickness);
    PathGeometry pathGeometry = new PathGeometry();
    PathFigureCollectionConverter collectionConverter = new PathFigureCollectionConverter();
    pathGeometry.Figures = collectionConverter.ConvertFromString("M200,200 C200,200 200,160, 240,160, 270,160, 263, 159.33296 264,159.33296 L264,130.33326 304.00032,130.00026 304.00032,160.00013 328.00041,159.6668 C328.00041,159.6668 367.33389,160.00013 368.00056,200 368.66723,239.99987 328.00042,239.99987 328.00042,239.99987 L304.00041,239.99987 304.33375,269.99975 264.00025,269.66642 263.66692,240.33321 240.00016,239.99988 C240.0
