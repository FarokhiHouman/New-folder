// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellheadForWellPerspectiveViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Common.Primitives;
using Slb.Production.Engineering.Common.Services;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using Slb.Production.Engineering.UI.Infrastructure;
using Slb.Production.Engineering.UI.Ribbon;
using System;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class WellheadForWellPerspectiveViewModel : ViewModel, IContextRestorer
{
  private readonly IStateService _stateService;
  private readonly IRibbonService _ribbonService;
  private WellEditorTabs _selectedTab;
  private WellHeadViewModel _wellHeadViewModel;

  public WellheadForWellPerspectiveViewModel()
    : this(ServiceDirectory.GetService<IStateService>(), ServiceDirectory.GetService<IRibbonService>(), ServiceDirectory.GetService<IWellImportService>())
  {
  }

  public WellheadForWellPerspectiveViewModel(
    IStateService stateService,
    IRibbonService ribbonService,
    IWellImportService wellImportService)
  {
    if (stateService == null)
      throw new ArgumentNullException(nameof (stateService));
    if (ribbonService == null)
      throw new ArgumentNullException(nameof (ribbonService));
    this._stateService = stateService;
    this._ribbonService = ribbonService;
    this.RegisterSubscription((I
