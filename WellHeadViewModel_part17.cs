eTabDefinition);
        this._insertSurfaceTabDefinition = this.RegisterContent<TabDefinition>(this.SetupInsertSurfaceTab(this._ribbonService));
        this._insertSurfaceTabDefinition.ElementClicked += new EventHandler<DataEventArgs<object>>(this.InsertTabDefinition_ElementClicked);
        this._ribbonService.Register(this._insertSurfaceTabDefinition);
      }
      else
      {
        this._ribbonService.UnRegister(this._insertSurfaceTabDefinition);
        this._insertDownholeTabDefinition = this.RegisterContent<TabDefinition>(this.SetupInsertDownholeTab(this._pluginService));
        this._ribbonService.Register(this._insertDownholeTabDefinition);
      }
      this._ribbonService.Update();
      this._ribbonService.UnRegister(this._formatTabDefinition);
      this._formatTabDefinition = this.RegisterContent<TabDefinition>(this.SetupFormatTab(WellCommands.WellStateChanged));
      this._ribbonService.Register(this._formatTabDefinition);
      this._ribbonService.Update();
    }
  }

  private TabDefinition SetupInsertDownholeTab(IPluginService pluginService)
  {
    TabDefinition tabDefinition1 = new TabDefinition(CoreStrings.RibbonTab_Insert);
    tabDefinition1.KeyTipAccessText = "WI";
    TabDefinition tabDefinition2 = tabDefinition1;
    tabDefinition2.ElementDragged += new EventHandler<DataEventArgs<object>>(this.InsertElementDragged);
    TabGroupDefinition tabGroupDefinition1 = new TabGroupDefinition(CoreStrings.Tubulars, ImageKey.Tubulars);
    tabGroupDefinition1.Elements.Add((object) new ButtonDefinition(CoreStrings.EquipmentDataType_Casing, (ICommand) null, (object) new CasingItemFactory(), ImageKey.Casing, CoreStrings.EquipmentDataType_Casing_Tooltip, true));
    tabGroupDefinition1.Elements.Add((object) new ButtonDefinition(CoreStrings.EquipmentDataType_Tubing, (ICommand) null, (object) new TubingItemFactory(), ImageKey.Tubing, CoreStrings.EquipmentDataType_Tubing_Tooltip, true));
    tabGroupDefinition1.Elements.Add(
