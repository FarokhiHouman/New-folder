// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.BoreholeDeviationSurveysViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Common.Primitives;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using Slb.Production.Engineering.UI.Chart;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class BoreholeDeviationSurveysViewModel : DomainObjectPropertyBagViewModel<WellTrajectory>
{
  private readonly BoreholeViewModel _parent;
  private Task _initializeTask;
  private TrajectoryMeasurementAccessor _measurementsAccessor;
  private readonly List<ISubscription> _measurementSubscriptions = new List<ISubscription>();
  private ISubscription _recalulateTrajectoryValuesSubscription;
  private CollectionChangedSubscription collectionChangedSubscription;
  private bool _requiresRecalculation;
  private IWellViewNavigationService _wellViewNavigationService
