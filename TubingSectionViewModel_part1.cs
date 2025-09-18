// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.Tubulars.TubingSectionViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Common.Extension;
using Slb.Production.Engineering.Common.Primitives;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.Tubulars;

public class TubingSectionViewModel : DomainObjectPropertyBagViewModel<TubingSection>
{
  private readonly BoreholeTubingViewModel parentBorehole;
  private static readonly Dictionary<string, string> _viewModelPropertiesMap = new Dictionary<string, string>()
  {
    {
      "TopMeasuredDepth",
      nameof (TopMD)
    },
    {
      "BottomMeasuredDepth",
      nameof (BottomMD)
    },
    {
      "InnerDiameter",
      nameof (InD)
    },
    {
      "OuterDiameter",
      nameof (OutD)
    },
    {
      nameof (WallThickness),
      nameof (WallThickness)
    },
    {
      "Roughness",
      nameof (SectionRoughness)
    }
  };
  private static Dictionary<string, string> _viewModelPropertiesMapInverse;
  private BoreholeTubingDetailViewModel _detailViewModel;

  private static Dictionary<string,
