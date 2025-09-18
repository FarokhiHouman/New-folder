// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.PackerWellboreItemView
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using System;
using System.Linq;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic;

public class PackerWellboreItemView : Slb.Ocean.UI.WellboreSchematic.Packer, ICreateWellStringItem
{
  protected override void TryDocking()
  {
    this.TryDockingAtTubularItem(TubularType.Casing);
    if (!this.IsDocked)
    {
      this.ID = 0.0;
      this.OD = this.Wellbore.Transform.ToRadialDistance(this.Wellbore.Transform.ViewRect.Height / 75.0);
    }
    else
      this.OD = this.ID = 0.0;
  }

  protected override void InitDockingDiameters()
  {
    if (this.TubularString == null || this.TopDepth < 0.0)
      return;
    BaseTubularItem baseTubularItem = this.TubularString.TubularItems.GetItemsAtDepth(this.TopDepth).OrderBy<BaseTubularItem, double>((Func<BaseTubularItem, double>) (i => i.ID)).FirstOrDefault<BaseTubularItem>();
    VolumeInfo upperVolume = (VolumeInfo) null;
    VolumeInfo lowerVolume = (VolumeInfo) null;
    baseTubularItem?.GetVolumeAtDepth(this.TopDepth, out upperVolume, out lowerVolume);
    if (upperVolume == null)
      return;
    this.OD = upperVolume.OuterRadius * 2.0;
    this.ID = upperVolume.InnerRadius * 2.0;
  }

  public ModelItem CreateWellStringItem(WellString wellString)
  {
    ModelItem packer;
    using (INuTransaction nuTransaction = NuDataManager.NewTra
