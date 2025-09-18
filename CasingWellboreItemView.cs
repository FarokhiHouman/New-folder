// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.CasingWellboreItemView
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Common.Extension;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic;

public class CasingWellboreItemView : Casing, ICreateWellStringItem
{
  public ModelItem CreateWellStringItem(WellString wellString)
  {
    ModelItem wellStringItem;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      TubingSection casingSection = wellString.CreateCasingSection(this.TopDepth);
      casingSection.InitializeTubularSection(wellString);
      wellStringItem = (ModelItem) casingSection;
      nuTransaction.Commit();
    }
    return wellStringItem;
  }

  public bool CanCreateItem(WellString wellString) => true;

  public Slb.Production.Engineering.Model.StandardDomain.WellHead WellHead { get; set; }
}
