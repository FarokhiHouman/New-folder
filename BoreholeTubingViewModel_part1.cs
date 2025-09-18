// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.Tubulars.BoreholeTubingViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Common.Extension;
using Slb.Production.Engineering.Common.Primitives;
using Slb.Production.Engineering.Common.Services;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.Tubulars;

public class BoreholeTubingViewModel : 
  DomainObjectPropertyBagViewModel<Borehole>,
  IWellViewNavigateFromValidation
{
  private readonly IViewService _viewService;
  private readonly IDomainObjectHost _domainObjectHost;
  private readonly AggregateSubscription _aggregateSubscription;
  private readonly ISubscription _wellActiveItemSubscription;
  private readonly ITabbedActiveItemNotifier _activeWellItemNotifier;
  private readonly ISubscription _selectedDetailedCasingsChangedSubscription;
  private readonly ISubscription _selectedDetailedTubing
