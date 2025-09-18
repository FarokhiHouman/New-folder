// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematicViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Ocean.Units;
using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Common.Services;
using Slb.Production.Engineering.Common.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using System;
using System.Collections.Specialized;
using System.Windows.Input;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class WellboreSchematicViewModel : ViewModel, IWellRefresh
{
  private readonly IStateService _stateService;
  private readonly IViewService _viewService;
  private readonly object _showWellLock = new object();
  private readonly ITabbedActiveItemNotifier _activeWellItemNotifier;
  private readonly ISubscription _itemSelectedSubscription;
  private readonly Slb.Production.Engineering.Model.StandardDomain.WellHead _wellHead;
  private StingrayWellboreAdapter _wellboreAdapter;
  private ISubscription _wellItemSelectedSubscription;

  public WellboreSchematicViewModel(
    Slb.Production.Engineering.Model.StandardDomain.WellHead wellHead,
    ITabbedActiveItemNotifier activeWellItemNotifier)
    : this(wellHead, activeWellItemNotifier, ServiceDirectory.GetService<
