// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.FluidLinkViewModel`1
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Common.Primitives;
using Slb.Production.Engineering.Model.Infrastructure;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Simulation.Operation;
using Slb.Production.Engineering.Model.StandardDomain.Validators;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public abstract class FluidLinkViewModel<T> : 
  DomainObjectPropertyBagViewModel<T>,
  IFluidLinkViewModel,
  INotifyPropertyChanged
  where T : FluidLink
{
  private readonly ConcurrentDictionary<ModelItem, bool> _validationStatusDictionary = new ConcurrentDictionary<ModelItem, bool>();
  private readonly ConcurrentBag<ISubscription> _fluidChangesSubscriptions = new ConcurrentBag<ISubscription>();
  private readonly string[
