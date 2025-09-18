(object) new TailPipeButtonDefinition(CoreStrings.EquipmentDataType_TailPipe, (ICommand) this.currentTailPipeCommand, (object) new TailPipeItemFactory(), ImageKey.TailPipe, CoreStrings.EquipmentDataType_TailPipe_Tooltip, true));
    tabDefinition2.Groups.Add(tabGroupDefinition1);
    TabGroupDefinition tabGroupDefinition2 = new TabGroupDefinition(CoreStrings.DownholeEquipment, ImageKey.DownholeEquipment);
    tabGroupDefinition2.Elements.Add((object) new ButtonDefinition(CoreStrings.EquipmentDataType_Choke, (ICommand) null, (object) new ChokeItemFactory(), ImageKey.Choke, CoreStrings.EquipmentDataType_Choke_Tooltip, true));
    tabGroupDefinition2.Elements.Add((object) new ButtonDefinition(CoreStrings.EquipmentDataType_Packer, (ICommand) null, (object) new PackerItemFactory(), ImageKey.Packer, CoreStrings.EquipmentDataType_Packer_Tooltip, true));
    tabGroupDefinition2.Elements.Add((object) new ButtonDefinition(CoreStrings.EquipmentDataType_Separator, (ICommand) null, (object) new SeparatorItemFactory(), ImageKey.Separator, CoreStrings.EquipmentDataType_Separator_Tooltip, true));
    tabGroupDefinition2.Elements.Add((object) new ButtonDefinition(CoreStrings.EquipmentDataType_SlidingSleeve, (ICommand) null, (object) new SlidingSleeveItemFactory(), ImageKey.SlidingSleeve, CoreStrings.EquipmentDataType_SlidingSleeve_Tooltip, true));
    tabGroupDefinition2.Elements.Add((object) new FcvButtonDefinition(CoreStrings.EquipmentDataType_FCV, (ICommand) this.currentFcvButtonCommand, (object) new FCVItemFactory(), ImageKey.FCV, CoreStrings.EquipmentDataType_FCV_Tooltip, true));
    tabGroupDefinition2.Elements.Add((object) new ButtonDefinition(CoreStrings.EquipmentDataType_SSSV, (ICommand) null, (object) new SSSVItemFactory(), ImageKey.SSSV, CoreStrings.EquipmentDataType_SSSV_Tooltip, true));
    tabGroupDefinition2.Elements.Add((object) new ButtonDefinition(CoreStrings.EquipmentDataType_TubingPlug, (ICommand) null, (object) new TubingPlugItemFactory(), ImageKey.Tubi
