// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.BaseTubingWellboreItemView
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Model.StandardDomain;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic;

public abstract class BaseTubingWellboreItemView : Tubing, ICreateWellStringItem
{
  protected const int InitialTubingDragLength = 600;

  public abstract ModelItem CreateWellStringItem(WellString wellString);

  public abstract bool CanCreateItem(WellString wellString);

  public Slb.Production.Engineering.Model.StandardDomain.WellHead WellHead { get; set; }
}
