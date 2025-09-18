// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellHeadIssueNavigator
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common.Services;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.StandardDomain;
using System;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class WellHeadIssueNavigator : IValidationIssueNavigator
{
  private readonly IStateService _stateService;

  public WellHeadIssueNavigator()
    : this(ServiceDirectory.GetService<IStateService>())
  {
  }

  public WellHeadIssueNavigator(IStateService stateService)
  {
    this._stateService = stateService ?? throw new ArgumentNullException(nameof (stateService));
  }

  public bool Navigate(ValidationIssue issue)
  {
    if ((object) (issue.RedirectTo as Slb.Production.Engineering.Model.StandardDomain.Model) != null)
      return false;
    WellHead wellHead1 = issue.RedirectTo as WellHead;
    if ((object) wellHead1 == null)
      wellHead1 = issue.RootItem as WellHead;
    WellHead wellHead2 = wellHead1;
    if (!(wellHead2 != (WellHead) null))
      return false;
    this._stateService.SetInputContext(wellHead2.DurableId, (object) this);
    WellCommands.Launch.Execute((object) issue);
    return true;
  }
}
