eturn;
    if (this._ribbonService == ServiceDirectory.GetService<IRibbonService>())
    {
      if ((ElementDefinition) this._contextTabDefinitionDownhole == (object) null && (ElementDefinition) this._contextTabDefinitionSurface == (object) null)
      {
        this._formatTabDefinition = this.RegisterContent<TabDefinition>(this.SetupFormatTab(WellCommands.WellStateChanged));
        this._insertDownholeTabDefinition = this.RegisterContent<TabDefinition>(this.SetupInsertDownholeTab(this._pluginService));
        this._insertSurfaceTabDefinition = this.RegisterContent<TabDefinition>(this.SetupInsertSurfaceTab(this._ribbonService));
        this._insertSurfaceTabDefinition.ElementClicked += new EventHandler<DataEventArgs<object>>(this.InsertTabDefinition_ElementClicked);
        this._contextTabDefinitionDownhole = this.RegisterContent<ContextTabDefinition>(this._contextTabFactory());
        this._contextTabDefinitionDownhole.Tabs.Add(this._insertDownholeTabDefinition);
        this._contextTabDefinitionDownhole.Tabs.Add(this._formatTabDefinition);
        this._contextTabDefinitionDownhole.RegisterElementClickedCallback(new EventHandler<DataEventArgs<object>>(this.InsertTabDefinition_ElementClicked));
        this._contextTabDefinitionSurface = this.RegisterContent<ContextTabDefinition>(this._contextTabFactory());
        this._contextTabDefinitionSurface.RegisterElementClickedCallback(new EventHandler<DataEventArgs<object>>(this.InsertTabDefinition_ElementClicked));
        this._contextTabDefinitionSurface.Tabs.Add(this._insertSurfaceTabDefinition);
        this._contextTabDefinitionSurface.Tabs.Add(this._formatTabDefinition);
      }
      this._ribbonService.Register(this.IsSurfaceEquipmentSelected ? this._contextTabDefinitionSurface : this._contextTabDefinitionDownhole);
      this._ribbonService.Update();
    }
    else
    {
      if (this.IsSurfaceEquipmentSelected)
      {
        this._ribbonService.UnRegister(this._insertDownhol
