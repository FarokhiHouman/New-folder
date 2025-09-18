// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellSelectionViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common.Extension;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using Slb.Production.Engineering.UI;
using Slb.Production.Engineering.UI.Ribbon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class WellSelectionViewModel : 
  SelectionTraversalDefinition<NamedItemViewModel>,
  IInputContextFilter
{
  private static readonly string[] PropertyNamesUsedInSort = new string[1]
  {
    "Name"
  };
  private readonly IStateService _stateService;
  private readonly IDomainObjectHost _domainObjectHost;
  private bool _refreshPending;
  private bool _sortPending;

  public WellSelectionViewModel()
    : this(ServiceDirectory.GetService<IStateService>(), ServiceDirectory.GetService<IDomainObjectHost>())
  {
  }

  public WellSelectionViewModel(IStateService stateService, IDomainObjectHost domainObjectHost)
    : base(CoreStrings.Wells)
  {
    if (stateService == null)
      throw new ArgumentNullException(nam
