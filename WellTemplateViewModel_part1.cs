// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellTemplateViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Common.Services;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using Slb.Production.Engineering.UI;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class WellTemplateViewModel : DomainObjectPropertyBagViewModel<WellHead>
{
  private readonly IViewService _viewService;
  private readonly IDomainObjectHost _domainObjectHost;
  private string _name;

  public WellTemplateViewModel(WellHead wellHead)
    : this(wellHead, ServiceDirectory.GetService<IViewService>(), ServiceDirectory.GetService<IDomainObjectHost>())
  {
  }

  public WellTemplateViewModel(
    WellHead wellHead,
    IViewService viewService,
    IDomainObjectHost domainObjectHost)
    : base(wellHead)
  {
    if (viewService == null)
      throw new ArgumentNullException(nameof (viewService));
    if (domainObjectHost == null)
      throw new ArgumentNullException(nameof (domainObjectHost));
    this._v
