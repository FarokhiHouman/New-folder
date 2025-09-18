elItemPort>>((Func<KeyValuePair<int, ModelItemPort>, bool>) (kvp => well.GetConnections(kvp.Key).Any<Connection>((Func<Connection, bool>) (c => branchEquipments.Contains<Equipment>(c.StartEquipment) || branchEquipments.Contains<Equipment>(c.EndEquipment)))));
    if (!source.Any<KeyValuePair<int, ModelItemPort>>())
      return (WellString) null;
    switch (source.First<KeyValuePair<int, ModelItemPort>>().Value)
    {
      case ModelItemPort.OutletTop:
        return well.DefaultBorehole.TubingWellString;
      case ModelItemPort.OutletMiddle:
        throw new NotImplementedException("Dual String/Concentric not implemented yet");
      case ModelItemPort.OutletBottom:
        return well.DefaultBorehole.CasingWellString;
      default:
        return (WellString) null;
    }
  }

  static WellCommands()
  {
    WellCommands.RegisterViews();
    WellCommands.Launch = (ICommand) new RelayCommand(new Action<object>(WellCommands.OnLaunch));
    WellCommands.CreateNewWithTemplateAndLaunch = (ICommand) new RelayCommand(new Action<object>(WellCommands.OnCreateNewWithTemplateAndLaunch), new Predicate<object>(WellCommands.CanCreateWell));
    WellCommands.CreateNewWithoutTemplateAndLaunch = (ICommand) new RelayCommand(new Action<object>(WellCommands.OnCreateNewWithoutTemplateAndLaunch));
    WellCommands.SaveAsTemplate = (ICommand) new RelayCommand(new Action<object>(WellCommands.OnSaveAsTemplate), new Predicate<object>(WellCommands.CanSaveAsTemplate));
    WellCommands.SetEquipmentAsWellStreamOutlet = (ICommand) new RelayCommand(new Action<object>(WellCommands.OnSetEquipmentAsWellStreamOutlet), new Predicate<object>(WellCommands.OnCanSetEquipmentAsWellStreamOutlet));
    WellCommands.WellStateChanged = (ICommand) new RelayCommand(new Action<object>(WellCommands.OnWellStateChanged));
    WellCommands.ExportWellCommand = (ICommand) new RelayCommand(new Action<object>(WellCommands.OnExportWell), new Predicate<object>(WellCommands.CanExportWell));
 
