// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.PerforationViewModel
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
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Threading;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class PerforationViewModel : FluidLinkViewModel<Perforation>
{
  private string _activeTabHeader = string.Empty;
  private static readonly Dictionary<PerforationViewModel.TabNumbers, string> _tabsHeaderMap = new Dictionary<PerforationViewModel.TabNumbers, string>()
  {
    {
      PerforationViewModel.TabNumbers.Reservoir,
      CoreStrings.Reservoir
    },
    {
      PerforationViewModel.TabNumbers.Sand,
      CoreStrings.SandTabLabel
    },
    {
      PerforationViewModel.TabNumbers.Skin,
      CoreStrings.Skin
    },
    {
      PerforationViewModel.TabNumbers.Fluid,
      CoreStrings.FluidModel
    },
    {
      PerforationViewModel.TabNumbers.Fracture,
      CoreStrings.FractureTabLabel
    }
  };
  private static readonly Dictionary<string, PerforationViewModel.TabNumbers> _propertyToTab;
  private PerforationViewModel.Completion
