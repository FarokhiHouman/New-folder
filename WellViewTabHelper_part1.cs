// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellViewTabHelper
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Common.Primitives;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.StandardDomain;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class WellViewTabHelper
{
  private static readonly Dictionary<Type, Func<object, WellEditorTabs>> ModelItemDictionary = new Dictionary<Type, Func<object, WellEditorTabs>>()
  {
    {
      typeof (Slb.Production.Engineering.Model.StandardDomain.Choke),
      new Func<object, WellEditorTabs>(WellViewTabHelper.Choke)
    },
    {
      typeof (Slb.Production.Engineering.Model.StandardDomain.Injector),
      new Func<object, WellEditorTabs>(WellViewTabHelper.Injector)
    },
    {
      typeof (Slb.Production.Engineering.Model.StandardDomain.NodalMeasurementPoint),
      new Func<object, WellEditorTabs>(WellViewTabHelper.NodalMeasurementPoint)
    },
    {
      typeof (Slb.Production.Engineering.Model.StandardDomain.EngineKeywords),
      new Func<object, WellEditorTabs>(WellViewTabHelper.EngineKeywords)
    },
    {
      typeof (Slb.Production.Engineering.Model.StandardDomain.SpotReport),
      new Func<object, WellEditorTabs>(WellViewTabHelper.SpotReport)
    },
    {
      typeof (Slb.Production.Engineering.Model.StandardD
