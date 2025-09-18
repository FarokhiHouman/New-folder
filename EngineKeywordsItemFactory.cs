// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.EngineKeywordsItemFactory
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Views.Well.WellboreSchematic;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class EngineKeywordsItemFactory : WellboreItemFactory
{
  public override BaseWellboreItem CreateWellboreItem()
  {
    return (BaseWellboreItem) new EngineKeywordsWellboreItemView();
  }
}
