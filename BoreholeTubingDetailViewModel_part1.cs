// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.Tubulars.BoreholeTubingDetailViewModel
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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Threading;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.Tubulars;

public class BoreholeTubingDetailViewModel : DomainObjectPropertyBagViewModel<TubingSection>
{
  private static readonly Dictionary<string, PropertyInfo> TubingSectionProperties = new Dictionary<string, PropertyInfo>();
  private static readonly List<string> ViewModelproperties;
  private readonly Dictionary<string, string> _propertyErrors = new Dictionary<string, string>();
  private readonly ObservableCollection<string> _casingGrades;
  private readonly ObservableCollection<string> _tubingGrades;
  private string _dummyEmptyString = string.Empty;

  static BoreholeTubingDetailViewModel()
  {
    foreach (PropertyInfo property in typeof (TubingSection).GetProperties())
      BoreholeTub
