llectionChanged(
    object sender,
    NotifyCollectionChangedEventArgs e)
  {
    GalleryDefinition equipmentGallery1 = this.FindUserEquipmentGallery(CoreStrings.ArtificialLift);
    GalleryDefinition equipmentGallery2 = this.FindUserEquipmentGallery(CoreStrings.DownholeEquipment);
    if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null)
    {
      foreach (Plugin plugin in e.NewItems.Cast<object>().Where<object>((Func<object, bool>) (item => item is Plugin)).Cast<Plugin>().Where<Plugin>((Func<Plugin, bool>) (item => item.PluginType == PluginType.UserEquipment)))
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"{CoreStrings.Provider}: {plugin.ProviderName}");
        stringBuilder.AppendLine($"{CoreStrings.Plugin}: {plugin.DisplayName}");
        foreach (UserEquipmentEntryPoint userEquipmentEntryPoint in plugin.EntryPoints.Cast<UserEquipmentEntryPoint>().Where<UserEquipmentEntryPoint>((Func<UserEquipmentEntryPoint, bool>) (entryPoint => entryPoint.EntryPointType == UserEquipmentEntryPointType.ArtificialLift || entryPoint.EntryPointType == UserEquipmentEntryPointType.Downhole)))
        {
          if (userEquipmentEntryPoint.EntryPointType == UserEquipmentEntryPointType.ArtificialLift && (ElementDefinition) equipmentGallery1 != (object) null)
          {
            ButtonDefinition buttonDefinition = new ButtonDefinition(userEquipmentEntryPoint.DisplayName, (ICommand) null, (object) new UserEquipmentItemFactory(userEquipmentEntryPoint, UserEquipmentType.ArtificialLift), ImageKey.UserArtificialLiftEquipment, stringBuilder.ToString(), true);
            equipmentGallery1.AddItem((object) buttonDefinition);
          }
          else if (userEquipmentEntryPoint.EntryPointType == UserEquipmentEntryPointType.Downhole && (ElementDefinition) equipmentGallery2 != (object) null)
          {
            ButtonDefinition buttonDefinition = new ButtonDefinition(userEquipmentEntry
