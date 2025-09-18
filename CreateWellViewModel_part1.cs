// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.CreateWellViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Common.Services;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using Slb.Production.Engineering.UI;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class CreateWellViewModel : ViewModel
{
  private readonly string _commandType;
  private WellTemplateDisplay _selectedTemplate;
  private readonly Network _network;
  private WellTemplateDisplay _noneOption = new WellTemplateDisplay((WellHead) null, CoreStrings.None);
  private string _importWellPath;

  public CreateWellViewModel(Slb.Production.Engineering.Model.StandardDomain.Model model, string commandType, bool canImportWell = true)
  {
    this._commandType = commandType;
    this._network = model.DefaultNetwork;
    this.CanImportWell = canImportWell;
    this.Templates = new ObservableCollection<WellTemplateDisplay>();
    this.Templates.Add(this._noneOption);
    foreach (WellHead templateWell in model.TemplateWells.Where<WellHead>((Func<WellHead, bool>) (tw => !tw.IsAdvancedType())))
      this.Templates.Add(new WellTemplateDisplay(templateWell, templateWell.Name));
    
