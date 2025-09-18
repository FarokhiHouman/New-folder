// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellStatusButtonCommand
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Helpers;
using System;
using System.Windows.Input;
using System.Windows.Threading;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class WellStatusButtonCommand : ICommand, IDisposable
{
  private bool _previousCanExecute;
  private readonly WellHead _wellHead;
  private readonly ISubscription _stateChangedEventSubscription;
  private readonly WellStatusButtonCommand.SupportedStatusType _supportedStatusType;

  private event EventHandler _canExecuteChanged = (_param1, _param2) => { };

  public WellStatusButtonCommand(
    WellHead wellHead,
    WellStatusButtonCommand.SupportedStatusType statusType)
  {
    this._wellHead = wellHead;
    IStateService service = ServiceDirectory.GetService<IStateService>();
    if (service != null)
      this._stateChangedEventSubscription = (ISubscription) new StateChangedSubscription<ActionEventArgs<string, object, object>>(service, new Action<ActionEventArgs<string, object, object>>(this.OnStateChanged));
    this._supportedStatusType = statusType;
  }

  private bool IsSupported
  {
    get
    {
      return this._supportedStatusType != WellStatusButtonCommand.SupportedStatusType.Conventional ? this._wellHead.WellType == WellType.Advanced : this._wellHead.WellType != WellType.Advanced;
    }
  }

  public bool CanExecute(object parameter)
  {
    boo
