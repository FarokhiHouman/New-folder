   return defaultReturnValue;
    return current.WorkspaceType != WorkspaceType.Well || !wellHead.IsAdvancedType();
  }

  private static DurableId[] GetSelectedItems()
  {
    if (NuSystem.State == NuSystemState.Running)
    {
      IStateService service = ServiceDirectory.GetService<IStateService>();
      if (service != null && service.InputContext != null)
        return service.InputContext.ToArray<DurableId>();
    }
    return new List<DurableId>().ToArray();
  }
}

