// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.TubingWellboreItemView
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Common.Extension;
using Slb.Production.Engineering.Model.Infrastructure;
using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.Model.Infrastructure.Transaction;
using Slb.Production.Engineering.Model.StandardDomain;
using System;
using System.Collections.Generic;
using System.Windows;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic;

public class TubingWellboreItemView : BaseTubingWellboreItemView
{
  private double _topDepth;

  private bool HasTailPipe
  {
    get
    {
      return this.WellHead != (Slb.Production.Engineering.Model.StandardDomain.WellHead) null && this.WellHead.DefaultBorehole.TubingWellString.FirstTailPipe != (TubingSection) null;
    }
  }

  public override double TopDepth
  {
    get => this._topDepth;
    set
    {
      if (this.IsDragged)
        return;
      this._topDepth = value;
    }
  }

  protected override void UpdateDragLocation(Point ptMouse)
  {
    base.UpdateDragLocation(ptMouse);
    this.Length = 600.0;
    this._topDepth = this.Wellbore.Transform.ToDepth(ptMouse.Y);
  }

  private void EnableDisableTubingStrings(bool enable)
  {
    using (IEnumerator<BaseWellboreItem> enumerator = this.Wellbore.GetEnumerator())
    {
      while (enumerator.MoveNext())
      {
        if (enumerator.Current != null && enumerator.Current.TubularString != null)
          enumerator.Current.TubularString.IsEnabled = enable;
      }
    }
  }

  privat
