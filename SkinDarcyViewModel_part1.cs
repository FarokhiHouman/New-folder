// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.SkinDarcyViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Extension;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using Slb.Production.Engineering.UI.Converters;
using Slb.Production.Simulation.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class SkinDarcyViewModel : 
  DomainObjectPropertyBagViewModel<DarcyCompletionModel>,
  ISkinViewModel,
  INotifyPropertyChanged,
  IDisposable
{
  private static readonly Dictionary<PointCompletionType, List<SkinComponentType>> _skinSupportMappings = new Dictionary<PointCompletionType, List<SkinComponentType>>();
  private static readonly Dictionary<FluidLinkType, List<PointCompletionType>> _fluidLinkTypeMappings;
  private bool _skinCalculationPending = true;
  private readonly bool _performCalculation;
  private ISubscription _fluidLinkSubscription;
  private IFluidLinkViewModel _fluidLinkViewModel;
  private string _displayUnitMeasurement;
  private string _rateDe
