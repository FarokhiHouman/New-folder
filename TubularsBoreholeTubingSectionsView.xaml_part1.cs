// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.Tubulars.BoreholeTubingSectionsView
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Model.StandardDomain.Properties;
using Slb.Production.Engineering.UI.Grid;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.Tubulars;

[ExcludeFromCodeCoverage]
public partial class BoreholeTubingSectionsView : WellEditorValidationUpdate, IComponentConnector
{
  internal CustomDataGrid DetailedViewTubingGrid;
  private bool _contentLoaded;

  public BoreholeTubingSectionsView()
  {
    this.InitializeComponent();
    this._grid = this.DetailedViewTubingGrid;
    this.DataContextChanged += new DependencyPropertyChangedEventHandler(((WellEditorValidationUpdate) this).BoreholeTubingView_DataContextChanged);
    this.Loaded += new RoutedEventHandler(((WellEditorValidationUpdate) this).OnLoaded);
    this.Unloaded += new RoutedEventHandler(((WellEditorValidationUpdate) this).OnUnloaded);
  }

  public override string HeaderLabel => CoreStrings.Tubulars;

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/Slb.Production.Engineering.Views;component/well/tubulars/boreholetubingsectionsview.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsab
