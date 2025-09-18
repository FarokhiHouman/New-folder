// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellTemplateDisplay
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Model.StandardDomain;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class WellTemplateDisplay
{
  private WellHead _templateWell;
  private string _displayName;

  public WellHead TemplateWell
  {
    get => this._templateWell;
    set => this._templateWell = value;
  }

  public string DisplayName
  {
    get => this._displayName;
    set => this._displayName = value;
  }

  public WellTemplateDisplay(WellHead templateWell, string displayName)
  {
    this._templateWell = templateWell;
    this._displayName = displayName;
  }
}
