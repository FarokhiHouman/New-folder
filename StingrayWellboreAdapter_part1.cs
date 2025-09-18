// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.StingrayWellboreAdapter
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Ocean.Units;
using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Common.Extension;
using Slb.Production.Engineering.Common.Primitives;
using Slb.Production.Engineering.Common.Services;
using Slb.Production.Engineering.Common.Units;
using Slb.Production.Engineering.Model.Infrastructure;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.System;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using Slb.Production.Engineering.UI.Expander;
using Slb.Production.Engineering.UI.Utility;
using Slb.Production.Engineering.Views.Well.WellboreSchematic;
using Slb.Production.Engineering.Views.Well.WellboreSchematic.FlowSectionBuilder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
