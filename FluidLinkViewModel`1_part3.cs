nkViewModel) this, model));
    this.IPRModelType = link.GetIPRModelType();
    this.AssociatedZone = link.GetAssociatedZone();
    this.RegisterSubscription((ISubscription) new NotifyPropertyChangedSubscription((INotifyPropertyChanged) this, new PropertyChangedEventHandler(this.FluidLinkViewModel_PropertyChanged)));
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) link, new EventHandler<DomainObjectChangeEventArgs>(this.DataSource_Changed)));
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) model, new EventHandler<DomainObjectChangeEventArgs>(this.Model_Changed)));
    this.UpdateListeners();
    this.SetupValidation();
    this.DeleteSelectedItemsCommand = (ICommand) new RelayCommand(new Action<object>(this.DeleteSelectedItems), new Predicate<object>(this.CanDeleteSelectedItems));
  }

  private void OnPerforationChanged(object sender, DomainObjectChangeEventArgs e)
  {
    this.NeedIprUpdate = true;
  }

  public bool EngineIsCalculating
  {
    get => this._engineIsCalculating;
    set
    {
      this._engineIsCalculating = value;
      this.OnPropertyChanged(nameof (EngineIsCalculating));
    }
  }

  public override string Title => this.DataSource.Name;

  public abstract FluidLinkType Type { get; }

  public virtual FluidEntryType FluidEntry => FluidEntryType.SinglePoint;

  public int RefreshTestPointsValidation
  {
    get => this.refreshTestPointsValidation;
    set
    {
      this.refreshTestPointsValidation = value;
      this.OnPropertyChanged(nameof (RefreshTestPointsValidation));
    }
  }

  public Zone AssociatedZone
  {
    get => this._associatedZone;
    private set
    {
      if (this._associatedZone != (Zone) null && this._associatedZoneChanged != null)
        this._associatedZoneChanged.Dispose();
      this._associatedZone = value;
      if (this._associatedZone != (Zone) null)
  
