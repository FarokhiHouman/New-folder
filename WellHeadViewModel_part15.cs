de void Dispose(bool disposing)
  {
    if ((ElementDefinition) this._contextTabDefinitionDownhole != (object) null)
    {
      this._contextTabDefinitionDownhole.UnRegisterElementClickedCallback(new EventHandler<DataEventArgs<object>>(this.InsertTabDefinition_ElementClicked));
      this._contextTabDefinitionDownhole.Dispose();
    }
    if ((ElementDefinition) this._contextTabDefinitionSurface != (object) null)
    {
      this._contextTabDefinitionSurface.UnRegisterElementClickedCallback(new EventHandler<DataEventArgs<object>>(this.InsertTabDefinition_ElementClicked));
      this._contextTabDefinitionSurface.Dispose();
    }
    if ((ElementDefinition) this._insertSurfaceTabDefinition != (object) null)
      this._insertSurfaceTabDefinition.ElementClicked -= new EventHandler<DataEventArgs<object>>(this.InsertTabDefinition_ElementClicked);
    if (this._ribbonService != null)
    {
      this._ribbonService.UnRegister(this._insertDownholeTabDefinition);
      this._ribbonService.UnRegister(this._insertSurfaceTabDefinition);
      this._ribbonService.UnRegister(this._formatTabDefinition);
      this._ribbonService.UnRegister(this._contextTabDefinitionDownhole);
      this._ribbonService.UnRegister(this._contextTabDefinitionSurface);
    }
    if (this._pluginService != null)
      this._pluginService.PluginsCollectionChanged -= new EventHandler<NotifyCollectionChangedEventArgs>(this.PluginService_PluginsCollectionChanged);
    foreach (IDisposable disposable in this._disposables)
      disposable?.Dispose();
    this._disposables.Clear();
    base.Dispose(disposing);
  }

  private void InvokeRefreshLayout()
  {
    if (!this.IsSurfaceEquipmentSelected || !this.NeedRecalculateLayout)
      return;
    this.NeedRecalculateLayout = false;
    this.BeginInvoke((Action) (() => this.BranchViewModel.RecalcLayout()), DispatcherPriority.Background);
  }

  private void UpdateRibbon()
  {
    if (this._ribbonService == null)
      r
