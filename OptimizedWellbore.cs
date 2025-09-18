// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellboreSchematic.OptimizedWellbore
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using System.Collections.Specialized;
using System.Windows;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.WellboreSchematic;

public class OptimizedWellbore : Wellbore
{
  private Size previousConstraint = Size.Empty;
  private Size previousMeasure = Size.Empty;
  private Size previousBounds = Size.Empty;
  private Size previousArrange = Size.Empty;

  public OptimizedWellbore()
  {
    this.TubularStrings.CollectionChanged += new NotifyCollectionChangedEventHandler(this.TubularStrings_CollectionChanged);
  }

  protected override Size MeasureOverride(Size constraint)
  {
    if (!constraint.Equals(this.previousConstraint) || !this.IsMeasureValid && this.IsLoaded)
    {
      this.previousConstraint = constraint;
      this.previousMeasure = base.MeasureOverride(constraint);
      this.previousBounds = Size.Empty;
    }
    return this.previousMeasure;
  }

  protected override Size ArrangeOverride(Size arrangeBounds)
  {
    if (!arrangeBounds.Equals(this.previousBounds))
    {
      this.previousBounds = arrangeBounds;
      this.previousArrange = base.ArrangeOverride(arrangeBounds);
    }
    return this.previousArrange;
  }

  private void TubularStrings_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    this.previousBounds = Size.Empty;
  }
}
