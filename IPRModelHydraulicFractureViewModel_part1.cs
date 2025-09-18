// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.IPRModelHydraulicFractureViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.StandardDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Threading;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class IPRModelHydraulicFractureViewModel : IPRModelViewModel<HydraulicFractureCompletionModel>
{
  private static readonly Dictionary<string, PropertyInfo> HydraulicFractureCompletionModelProperties = new Dictionary<string, PropertyInfo>();
  private readonly HashSet<string> _propertyErrors = new HashSet<string>();
  private readonly Dictionary<string, string> _validationErrors = new Dictionary<string, string>();

  static IPRModelHydraulicFractureViewModel()
  {
    foreach (PropertyInfo property in typeof (HydraulicFractureCompletionModel).GetProperties())
      IPRModelHydraulicFractureViewModel.HydraulicFractureCompletionModelProperties[property.Name] = property;
  }

  public IPRModelHydraulicFractureViewModel(
    HydraulicFractureCompletionModel model,
    IFluidLinkViewModel link,
    bool performCalculation = true)
    : base(model, link, performCalculation: performCalculation)
  {
    this.RegisterSubscription((ISubscription) new ValidationCompletedSubscription(this.validationService, new EventHandler<ValidateArgs>(this.ValidationService_ValidationCompleted)));
