// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.IIPRModelViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.UI.Chart;
using System;
using System.Windows.Media;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public interface IIPRModelViewModel : IDisposable
{
  ISkinViewModel SkinViewModel { get; }

  IFluidLinkViewModel FluidLinkViewModel { get; }

  ChartAreaDefinition ChartAreaViewModel { get; }

  bool CanUseTestDataForIPRCalulation { get; }

  bool IsConditionalIPRCalculationBasis { get; }

  IPRCalculationBasis IPRCalculationBasis { get; }

  int DefaultNumberOfTestPoints { get; }

  int MinTestPoints { get; }

  void Update(bool valid);

  bool UpdatePending { get; }

  bool IsValid { get; }

  ImageSource Image { get; }

  bool IsSupportedByOS { get; }

  bool IsCurveSupported { get; }

  bool HasFractureConfiguration { get; }

  CompletionModel Model { get; }
}
