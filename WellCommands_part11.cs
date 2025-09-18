) wellHead1 != null && wellHead1.DefaultBorehole.WellStrings.Any<WellString>((Func<WellString, bool>) (ws => !(ws.OutletEquipment is WellHead))))
      return true;
    if (wellString == (WellString) null)
      return false;
    return wellString.OutletEquipment == (Equipment) null || wellString.OutletEquipment.DurableId != equipment.DurableId;
  }

  private static void OnDeleteWellSelected(object parameter)
  {
    DurableId[] durableIdArray = parameter is DurableId[] ? parameter as DurableId[] : WellCommands.GetSelectedItems();
    if (durableIdArray == null || !((IEnumerable<DurableId>) durableIdArray).Any<DurableId>())
      return;
    string message = string.Format(CoreStrings.DeleteItemsCount, (object) durableIdArray.Length);
    if (durableIdArray.Length == 1)
    {
      NamedItem namedItem = FacadeAccessor.Resolve<ModelItem>(durableIdArray[0]) as NamedItem;
      if (namedItem != (NamedItem) null && string.IsNullOrWhiteSpace(namedItem.Name))
        message = string.Format(CoreStrings.DeleteItemName, (object) namedItem.Name);
    }
    if (!ServiceDirectory.GetService<IViewService>().Warn(CoreStrings.Delete, message))
      return;
    ServiceDirectory.GetService<IPresentationService>().Delete(durableIdArray);
  }

  private static bool CanDeleteWell(object parameter)
  {
    return WellCommands.CanOperationBasedOnWellType(false);
  }

  private static bool CanOperationBasedOnWellType(bool defaultReturnValue)
  {
    WorkspaceDataRoot current = WorkspaceDataRoot.Current;
    if (current == (WorkspaceDataRoot) null || NuSystem.State != NuSystemState.Running)
      return defaultReturnValue;
    IStateService service = ServiceDirectory.GetService<IStateService>();
    if (service == null || service.InputContext == null || service.ActiveContext == (DurableId) null)
      return defaultReturnValue;
    WellHead wellHead = service.ActiveContext.TryResolveAs<ModelItem>() as WellHead;
    if ((object) wellHead == null)
   
