// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellEditorValidationUpdate
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Helpers;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using Slb.Production.Engineering.UI;
using Slb.Production.Engineering.UI.Grid;
using Slb.Production.Engineering.Views.Well.Tubulars;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

[ExcludeFromCodeCoverage]
public class WellEditorValidationUpdate : UserControl, IWellEditorValidationUpdate
{
  protected CustomDataGrid _grid;
  private IValidationService _validationService;

  protected void OnUnloaded(object sender, RoutedEventArgs e)
  {
    this.TryFindParent<WellHeadView>()?.SubscribeToValidationUpdate((IWellEditorValidationUpdate) this, false);
  }

  protected void OnLoaded(object sender, RoutedEventArgs e)
  {
    this.TryFindParent<WellHeadView>()?.SubscribeToValidationUpdate((IWellEditorValidationUpdate) this, true);
  }

  private void ValidationService_OnValidationCompleted(object sender, ValidateArgs e)
  {
    InvokeMethodHelper.BeginInvoke(new Action(this.ValidateControls), DispatcherPriority.Background);
  }

  public virtual void ValidateControls() => this._grid?.BindingGroup?.CommitEdit();

  public virtual string HeaderLabel => CoreStrings.Tubulars;

  protected void Bore
