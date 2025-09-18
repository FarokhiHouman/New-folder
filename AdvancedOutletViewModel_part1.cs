// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.AdvancedOutletViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class AdvancedOutletViewModel : ViewModel
{
  private readonly WellString _wellString;
  private readonly Collection<ISubscription> _gasLiftInjectionSubscriptions = new Collection<ISubscription>();

  public AdvancedOutletViewModel(WellString wellString)
  {
    this._wellString = wellString;
    this.StreamOutletViewModel = this.RegisterContent<SourceViewModel>(new SourceViewModel(this._wellString.StreamOutlet, this._wellString.Borehole.WellHead.Network.Model, this._wellString));
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) this._wellString.Borehole.WellHead, (EventHandler<DomainObjectChangeEventArgs>) ((sender, args) => this.RefreshFlowDirection())));
    if (this._wellString.TubingSectionsType != TubingSectionsType.Casing)
      return;
    foreach (OdtDomainObjectBase gasliftInjection in this._wellString.Borehole.WellHead.AllGasliftInjections)
      this._gasLiftInjectionSubscriptions.Add(this.RegisterSu
