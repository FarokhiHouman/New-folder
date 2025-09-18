// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellCommands
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using ActiproSoftware.Windows.Controls.Ribbon.Input;
using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Common.Extension;
using Slb.Production.Engineering.Common.Primitives;
using Slb.Production.Engineering.Common.Services;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Logger;
using Slb.Production.Engineering.Model.Infrastructure.Plugins;
using Slb.Production.Engineering.Model.Infrastructure.System;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Export;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using Slb.Production.Engineering.UI.Infrastructure;
using Slb.Production.Engineering.UI.Infrastructure.ViewModelContexts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class WellCommands
{
  public const string CommandType_InputTree = "CommandType_InputTree";
  public const string CommandType_Toolbar = "CommandType_Toolbar";
  public const string CommandType_Other = "CommandType_Other";
  private static readonly Dictionary<int, ModelItemPort> wellPortsMap = new Dictionary<int
