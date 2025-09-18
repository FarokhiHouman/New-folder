// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.PerforationWellboreItemView
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic;

public class PerforationWellboreItemView : Slb.Ocean.UI.WellboreSchematic.Perforation, ICreateWellStringItem
{
  protected override void TryDocking()
  {
    BaseTubularItem baseTubularItem = this.TryDockingAtTubularItem(TubularType.Casing);
    if (baseTubularItem != null)
    {
      this.OD = baseTubularItem.OD;
      this.ID = baseTubularItem.ID;
    }
    else
      base.TryDocking();
  }

  public ModelItem CreateWellStringItem(WellString wellString)
  {
    ModelItem perforation;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      perforation = (ModelItem) wellString.CreatePerforation(this.TopDepth);
      nuTransaction.Commit();
    }
    return perforation;
  }

  public bool CanCreateItem(WellString wellString)
  {
    return wellString.TubingSectionsType == TubingSectionsType.Casing;
  }

  public Slb.Production.Engineering.Model.StandardDomain.WellHead WellHead { get; set; }
}
