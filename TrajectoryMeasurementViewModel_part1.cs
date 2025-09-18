// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.TrajectoryMeasurementViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class TrajectoryMeasurementViewModel : DomainObjectPropertyBagViewModel<TrajectoryMeasurement>
{
  private bool _isFirstRow;
  private readonly BoreholeDeviationSurveysViewModel _parent;

  public TrajectoryMeasurementViewModel(TrajectoryMeasurement model)
    : this(model, false, (BoreholeDeviationSurveysViewModel) null)
  {
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) model, new EventHandler<DomainObjectChangeEventArgs>(this.DataSource_Changed)));
  }

  public TrajectoryMeasurementViewModel(
    TrajectoryMeasurement model,
    bool isFirstRow,
    BoreholeDeviationSurveysViewModel parent)
    : base(model)
  {
    this._isFirstRow = isFirstRow;
    this._parent = parent;
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) model, new EventHandler<DomainObjectChangeEventArgs>(this.DataSource_Changed)));
  }

  internal void RefreshHorizontalDistance()
  {
    this.OnPropertyChanged("HorizontalDisplacement");
    this.OnProperty
