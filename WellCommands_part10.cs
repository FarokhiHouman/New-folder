treamOutlet(
    object parameter,
    out WellHead wellHead,
    out Equipment equipment,
    out WellString wellString)
  {
    wellHead = (WellHead) null;
    equipment = parameter as Equipment;
    wellString = (WellString) null;
    if (equipment == (Equipment) null || !equipment.IsGood)
      return false;
    WellHead wellHead1 = equipment as WellHead;
    return ((object) wellHead1 == null || !wellHead1.IsAdvancedType() || wellHead1.GetConnections().Any<Connection>()) && WellCommands.FindWellHead(equipment, out wellHead, out wellString) && WellCommands.CanSetAsWellStreamOutlet(wellHead, equipment, wellString);
  }

  private static void OnWellStateChanged(object parameter)
  {
    if (parameter == null)
      return;
    IStateService service = ServiceDirectory.GetService<IStateService>();
    if (service == null)
      return;
    if (parameter is KeyValuePair<string, object> keyValuePair)
      service.FireStateChangedEvent(new ActionEventArgs<string, object, object>("topic://WellBoreEditorStateChanged", (object) keyValuePair.Key, keyValuePair.Value));
    else
      service.FireStateChangedEvent(new ActionEventArgs<string, object, object>("topic://WellBoreEditorStateChanged", (object) parameter.ToString(), (object) null));
  }

  private static bool CanSetAsWellStreamOutlet(
    WellHead wellHead,
    Equipment equipment,
    WellString wellString)
  {
    if (wellHead == (WellHead) null || equipment == (Equipment) null || (object) (equipment as Junction) != null || (object) (equipment as Source) != null || (object) (equipment as Sink) != null)
      return false;
    if (!wellHead.IsAdvancedType())
      return wellHead.WellOutletEquipment == (Equipment) null || wellHead.WellOutletEquipment.DurableId != equipment.DurableId;
    string reason;
    if (!wellHead.IsSolvable(out reason) && reason == CoreResourceStrings.NoFlowPathFound)
      return false;
    WellHead wellHead1 = equipment as WellHead;
    if ((object
