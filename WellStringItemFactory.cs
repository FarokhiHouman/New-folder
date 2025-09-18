// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellStringItemFactory
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using System;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class WellStringItemFactory
{
  private readonly Func<WellString, double, ModelItem> _action;
  private readonly string _rootName;

  public WellStringItemFactory(string rootName, Func<WellString, double, ModelItem> action)
  {
    this._action = action;
    this._rootName = rootName;
  }

  public override string ToString() => this._rootName;

  public ModelItem CreateWellStringItem(WellString wellString, double topDepth)
  {
    ModelItem wellStringItem;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      wellStringItem = this._action(wellString, topDepth);
      nuTransaction.Commit();
    }
    return wellStringItem;
  }
}
