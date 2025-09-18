Point.DisplayName, (ICommand) null, (object) new UserEquipmentItemFactory(userEquipmentEntryPoint, UserEquipmentType.Downhole), ImageKey.UserDownholeEquipment, stringBuilder.ToString(), true);
            equipmentGallery2.AddItem((object) buttonDefinition);
          }
        }
      }
    }
    else
    {
      if (e.Action != NotifyCollectionChangedAction.Remove || e.OldItems == null)
        return;
      foreach (Plugin plugin in e.OldItems.Cast<object>().Where<object>((Func<object, bool>) (item => item is Plugin)).Cast<Plugin>().Where<Plugin>((Func<Plugin, bool>) (item => item.PluginType == PluginType.UserEquipment)))
      {
        foreach (UserEquipmentEntryPoint equipmentEntryPoint in plugin.EntryPoints.Cast<UserEquipmentEntryPoint>().Where<UserEquipmentEntryPoint>((Func<UserEquipmentEntryPoint, bool>) (entryPoint => entryPoint.EntryPointType == UserEquipmentEntryPointType.ArtificialLift || entryPoint.EntryPointType == UserEquipmentEntryPointType.Downhole)))
        {
          if (equipmentEntryPoint.EntryPointType == UserEquipmentEntryPointType.ArtificialLift && (ElementDefinition) equipmentGallery1 != (object) null)
          {
            foreach (ButtonDefinition buttonDefinition in (Collection<object>) equipmentGallery1.Items)
            {
              if (buttonDefinition.Label == equipmentEntryPoint.DisplayName)
              {
                equipmentGallery1.RemoveItem((object) buttonDefinition);
                break;
              }
            }
          }
          else if (equipmentEntryPoint.EntryPointType == UserEquipmentEntryPointType.Downhole && (ElementDefinition) equipmentGallery2 != (object) null)
          {
            foreach (ButtonDefinition buttonDefinition in (Collection<object>) equipmentGallery2.Items)
            {
              if (buttonDefinition.Label == equipmentEntryPoint.DisplayName)
              {
                equipmentGallery2.RemoveItem((object) buttonDefinition);
          
