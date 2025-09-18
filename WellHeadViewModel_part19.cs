ngPlug, CoreStrings.EquipmentDataType_TubingPlug_Tooltip, true));
    tabGroupDefinition2.Elements.Add((object) new ButtonDefinition(CoreStrings.EquipmentDataType_Injector, (ICommand) null, (object) new InjectorItemFactory(), ImageKey.Injector, CoreStrings.EquipmentDataType_Injector_Tooltip, true));
    tabGroupDefinition2.Elements.Add((object) new ButtonDefinition(CoreStrings.EquipmentDataType_Completion, (ICommand) null, (object) new PerforationItemFactory(), ImageKey.Completion, CoreStrings.EquipmentDataType_Completion_Tooltip, true));
    tabGroupDefinition2.Elements.Add((object) new NodalPointButtonDefinition(CoreStrings.NodalAnalysisPoint, (ICommand) this.currentNodalPointCommand, (object) new NodalPointItemFactory(), ImageKey.NodalAnalysisPoint, CoreStrings.NodalAnalysisPoint_Tooltip, true));
    tabGroupDefinition2.Elements.Add((object) new ButtonDefinition(CoreStrings.EquipmentDataType_SpotReport, (ICommand) null, (object) new SpotReportItemFactory(), ImageKey.SpotReport, CoreStrings.EquipmentDataType_SpotReport_Tooltip, true));
    tabGroupDefinition2.Elements.Add((object) new ButtonDefinition(CoreStrings.EquipmentDataType_EngineKeywords, (ICommand) null, (object) new EngineKeywordsItemFactory(), ImageKey.EngineKeywordsDownhole, CoreStrings.EquipmentDataType_EngineKeywords_Tooltip, true));
    string dataTemplateUri = "/Slb.Production.Engineering.Desktop;component/DataTemplates.xaml";
    object dataTemplateKey = (object) typeof (ButtonDefinition);
    GalleryDefinition galleryDefinition1 = new GalleryDefinition(CoreStrings.EquipmentDataType_UserEquipment, (ICommand) null, (object) null, dataTemplateUri, dataTemplateKey, ImageKey.UserDownholeEquipment, CoreStrings.EquipmentDataType_UserEquipment_Tooltip, false, (string) null, ButtonSize.Large);
    TabGroupDefinition tabGroupDefinition3 = new TabGroupDefinition(CoreStrings.ArtificialLift, ImageKey.ArtificialLift);
    tabGroupDefinition3.Elements.Add((object) new ButtonDefinition(CoreStrings.Gasl
