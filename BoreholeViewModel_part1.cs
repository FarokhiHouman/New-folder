// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.BoreholeViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Common.Primitives;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Views.Well.HeatTransfer;
using Slb.Production.Engineering.Views.Well.Tubulars;
using System;
using System.Collections.ObjectModel;
using System.Linq;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class BoreholeViewModel : DomainObjectPropertyBagViewModel<Borehole>
{
  private readonly ITabbedActiveItemNotifier _activeWellItemNotifier;
  private BoreholeTubingViewModel _boreholeTubingViewModel;
  private BoreholeDeviationSurveysViewModel _boreholeDeviationSurveysViewModel;
  private BoreholeHeatTransferViewModel _boreholeHeatTransferViewModel;
  private IWellViewNavigationService _wellViewNavigationService;

  public BoreholeViewModel(
    Borehole borehole,
    ITabbedActiveItemNotifier activeWellItemNotifier,
    IWellViewNavigationService wellViewNavigationService = null)
    : base(borehole)
  {
    if (borehole == (Borehole) null)
      throw new ArgumentNullException(nameof (borehole));
    if (activeWellItemNotifier == null)
      throw new ArgumentNullException(nameof (activeWellItemNotifier));
    this._wellViewNavigationService = wellViewNavigationService;
    this._activeWellItemNotifier = activeWellItemNotifier;
  }

  public BoreholeTubingViewModel Boreho
