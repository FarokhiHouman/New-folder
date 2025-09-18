// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellSettings
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Ocean.UI.WellboreSchematic;
using Slb.Production.Engineering.Model.StandardDomain;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class WellSettings
{
  private static Slb.Production.Engineering.Model.StandardDomain.Model CurrentModel
  {
    get => DataHelper.GetCurrentWorkspaceModel();
  }

  public static void SetVertical() => WellSettings.Dimension = WellboreView.Vertical;

  public static WellboreView Dimension
  {
    get => !WellSettings.GetDisplaySettings("1D") ? WellboreView.Trajectory : WellboreView.Vertical;
    set
    {
      if (WellSettings.Dimension == value)
        return;
      WellSettings.SaveDisplaySettings("1D", value == WellboreView.Vertical);
    }
  }

  private static bool GetDisplaySettings(string key)
  {
    return !(WellSettings.CurrentModel != (Slb.Production.Engineering.Model.StandardDomain.Model) null) || WellSettings.CurrentModel.GetBoolOption(key, true);
  }

  private static void SaveDisplaySettings(string key, bool val)
  {
    if (!(WellSettings.CurrentModel != (Slb.Production.Engineering.Model.StandardDomain.Model) null))
      return;
    bool? boolOption = WellSettings.CurrentModel.GetBoolOption(key);
    if (boolOption.HasValue && boolOption.Value == val)
      return;
    WellSettings.CurrentModel.SetBoolOption(key, val);
  }
}
