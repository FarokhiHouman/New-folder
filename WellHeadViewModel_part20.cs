ift_Label, (ICommand) null, (object) new GasLiftInjectionItemFactory(), ImageKey.GasLiftInjection, CoreStrings.GasLiftInjection_Tooltip, true));
    tabGroupDefinition3.Elements.Add((object) new ButtonDefinition(CoreStrings.ESP, (ICommand) null, (object) new ESPItemFactory(), ImageKey.ESP, CoreStrings.ESP_Tooltip, true));
    tabGroupDefinition3.Elements.Add((object) new ButtonDefinition(CoreStrings.PCP, (ICommand) null, (object) new PCPItemFactory(), ImageKey.PCP, CoreStrings.PCP_Tooltip, true));
    tabGroupDefinition3.Elements.Add((object) new ButtonDefinition(CoreStrings.RodPump, (ICommand) null, (object) new RodPumpItemFactory(), ImageKey.RodPump, CoreStrings.RodPump_Tooltip, true));
    GalleryDefinition galleryDefinition2 = new GalleryDefinition(CoreStrings.EquipmentDataType_UserEquipment, (ICommand) null, (object) null, dataTemplateUri, dataTemplateKey, ImageKey.UserArtificialLiftEquipment, CoreStrings.EquipmentDataType_UserEquipment_Tooltip, false, (string) null, ButtonSize.Large);
    foreach (Plugin plugin in pluginService.GetPlugins(PluginType.UserEquipment))
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendLine($"{CoreStrings.Provider}: {plugin.ProviderName}");
      stringBuilder.AppendLine($"{CoreStrings.Plugin}: {plugin.DisplayName}");
      foreach (EntryPoint entryPoint in (IEnumerable<EntryPoint>) plugin.EntryPoints)
      {
        UserEquipmentEntryPoint userEquipmentEntryPoint = (UserEquipmentEntryPoint) entryPoint;
        if (userEquipmentEntryPoint.EntryPointType == UserEquipmentEntryPointType.ArtificialLift || userEquipmentEntryPoint.EntryPointType == UserEquipmentEntryPointType.Downhole)
        {
          if (userEquipmentEntryPoint.EntryPointType == UserEquipmentEntryPointType.Downhole)
          {
            ButtonDefinition buttonDefinition = new ButtonDefinition(entryPoint.DisplayName, (ICommand) null, (object) new UserEquipmentItemFactory(userEquipmentEntryPoint, UserEquipmen
