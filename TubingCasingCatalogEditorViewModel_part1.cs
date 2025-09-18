// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.TubingCasingCatalogEditorViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Catalogs;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using Slb.Production.Engineering.Views.Catalog;
using System;
using System.Linq;
using System.Linq.Expressions;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class TubingCasingCatalogEditorViewModel : CatalogEditorViewModelBase
{
  private readonly ICatalogDataService _catalogDataService;
  private readonly bool _isCasing;

  public TubingCasingCatalogEditorViewModel(
    ICatalogDataService catalogDataService,
    int? tubingID,
    bool isCasing)
  {
    this._catalogDataService = catalogDataService != null ? catalogDataService : throw new ArgumentNullException(nameof (catalogDataService));
    Tubing tubing1;
    if (!tubingID.HasValue)
      tubing1 = (Tubing) null;
    else
      tubing1 = this._catalogDataService.Get<Tubing>((Expression<Func<Tubing, bool>>) (i => (int?) i.ID == tubingID)).FirstOrDefault<Tubing>();
    Tubing tubing2 = tubing1;
    this._isCasing = isCasing;
    if (tubing2 == null)
      throw new ArgumentNullException($"Tubing with ID {tubingID} could not be found in the catalog database.");
    this.ID = tubingID.Value;
    this.Name = tubing2.Name;
    this.InsideDiameter = tubing2.InsideDiameter ?? double.NaN;
    double? nullable = tubing2.OutsideDiameter;
    this.OutsideDiameter = nullable ?? double.NaN;
    nullable = tubing2.Weight;
    this.Weight = nullable ?? double.NaN;
    this.Grade = tubing2.Grade;
    this.Catalog = tubing2.Catalog;
    nullable = tubing2.Roughness;
