// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.TubingCasingCatalogSelectorViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Catalogs;
using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Input;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class TubingCasingCatalogSelectorViewModel : ViewModel
{
  private readonly TubingSection _domainObject;
  private readonly ICatalogDataService _catalogDataService;
  private readonly bool _isCasing;
  private IEnumerable<Tubing> _tubings;
  private Tubing _selectedTubing;

  public TubingCasingCatalogSelectorViewModel(TubingSection domainObject)
    : this(ServiceDirectory.GetService<ICatalogDataService>(), domainObject)
  {
  }

  public TubingCasingCatalogSelectorViewModel(
    ICatalogDataService catalogDataService,
    TubingSection domainObject)
  {
    this._domainObject = !(domainObject == (TubingSection) null) ? domainObject : throw new ArgumentNullException(nameof (domainObject));
    this._catalogDataService = catalogDataService;
    this.ApplySelectionCommand = (ICommand) new RelayCommand(new Action<object>(this.ApplySelection), new Predicate<object>(this.CanApplySelection));
    this._isCasing = domainObject.SectionType == SectionType.Casing || 
