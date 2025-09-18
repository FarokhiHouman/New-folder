[]) null).Dispose();
      this.IsBuiltInTemplate = wellHead.IsBuiltinTemplate;
      WellboreSchematicViewModel content = new WellboreSchematicViewModel(wellHead, (ITabbedActiveItemNotifier) this);
      this._refreshViewModels.Add((IWellRefresh) content);
      this.WellboreSchematicViewModel = this.RegisterContent<WellboreSchematicViewModel>(content);
      if (!wellHead.IsTemplate)
      {
        this.BranchViewModel = this.RegisterContent<LogicalNetworkViewModel>(new LogicalNetworkViewModel(wellHead));
        this.WellStreamOutletViewModel = this.RegisterContent<SourceViewModel>(new SourceViewModel(wellHead.WellStreamOutlet, wellHead.Network.Model, true));
        this.CasingOutletView = this.RegisterContent<AdvancedOutletViewModel>(new AdvancedOutletViewModel(wellHead.DefaultBorehole.CasingWellString));
        this.TubingOutletView = this.RegisterContent<AdvancedOutletViewModel>(new AdvancedOutletViewModel(wellHead.DefaultBorehole.TubingWellString));
      }
      this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) this.DataSource, new EventHandler<DomainObjectChangeEventArgs>(this.DataSource_Changed)));
      this.RegisterSubscription((ISubscription) new StateChangedSubscription<ActionEventArgs<string, object, object>>(stateService, new Action<ActionEventArgs<string, object, object>>(this.StateService_OnStateChanged)));
    }
    this._pluginService = pluginService;
    this._pluginService.PluginsCollectionChanged += new EventHandler<NotifyCollectionChangedEventArgs>(this.PluginService_PluginsCollectionChanged);
    this._disposables.Add((IDisposable) (this.currentNodalPointCommand = new ConventionalWellButtonCommand(wellHead)));
    this._disposables.Add((IDisposable) (this.currentFcvButtonCommand = new AdvancedWellButtonCommand(wellHead)));
    this._disposables.Add((IDisposable) (this.currentTailPipeCommand = new TailPipeCommand(wellHead)));
  }

  private void PluginService_PluginsCo
