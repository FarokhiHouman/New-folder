// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.Tubulars.BoreholeTubingDetailView
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.UI.Primitives;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.Tubulars;

[ExcludeFromCodeCoverage]
public partial class BoreholeTubingDetailView : UserControl, IComponentConnector
{
  internal CollectionContentItem CboAnnulusMaterialType;
  private bool _contentLoaded;

  public BoreholeTubingDetailView() => this.InitializeComponent();

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/Slb.Production.Engineering.Views;component/well/tubulars/boreholetubingdetailview.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
      this.CboAnnulusMaterialType = (CollectionContentItem) target;
    else
      this._contentLoaded = true;
  }
}
