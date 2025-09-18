ns, new NotifyCollectionChangedEventHandler(this.Connections_CollectionChanged)));
      this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) network.Connections, new NotifyCollectionChangedEventHandler(this.Connections_CollectionChanged)));
    }
    this.RegisterSubscription((ISubscription) new UnitSettingsChangedSubscription(unitServiceSettings, new EventHandler<UnitSettingsEventArgs>(this.UnitSettings_SettingsChanged)));
    this.DeleteSelectedItemCommand = (ICommand) new RelayCommand(new Action<object>(this.DeleteSelectedWellboreItem), new Predicate<object>(this.CanDeleteSelectedWellboreItem));
    this.ToggleSelectedItemLabelVisibilityCommand = (ICommand) new RelayCommand(new Action<object>(this.ToggleSelectedItemLabelVisibility), new Predicate<object>(this.CanToggleSelectedItemLabelVisibility));
  }

  public StingrayWellboreAdapter WellboreAdapter
  {
    get => this._wellboreAdapter;
    set
    {
      this._wellboreAdapter = this._wellboreAdapter == null ? value : throw new InvalidOperationException("Cannot set WellboreAdapter after it has already been set");
      this._wellboreAdapter.IsItemValidForSelection = new Func<object, bool>(this._activeWellItemNotifier.IsItemInTheCurrentTab);
      this._wellItemSelectedSubscription = this.RegisterSubscription((ISubscription) new StandardEventSubscription<WellboreSchematicCanvas, WellboreEventArgs>(this._wellboreAdapter.WellboreSchematic, new EventHandler<WellboreEventArgs>(this.WellBoreAdapter_WellboreItemSelected), (Action<WellboreSchematicCanvas, EventHandler<WellboreEventArgs>>) ((x, y) => x.WellboreItemSelected += y), (Action<WellboreSchematicCanvas, EventHandler<WellboreEventArgs>>) ((x, y) => x.WellboreItemSelected -= y)));
      this.RegisterSubscription((ISubscription) new StandardEventSubscription<StingrayWellboreAdapter, NamedItemEventArgs>(this._wellboreAdapter, new EventHandler<NamedItemEventArgs>(this.WellBoreAdapter_SurfaceEquipmen
