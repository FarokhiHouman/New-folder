ue();
    }
  }

  public IIPRModelViewModel IPRModelViewModel
  {
    get => this._iprModel;
    private set
    {
      if (this._iprModel != null)
        this._iprModel.Dispose();
      this._iprModel = value;
      this.SubscribeToIprModelChange();
      this.OnPropertyChanged(nameof (IPRModelViewModel));
      this.OnPropertyChanged("IsConditionalIPRCalculationBasis");
      this.OnPropertyChanged("HasSkinConfiguration");
      this.OnPropertyChanged("HasFractureConfiguration");
    }
  }

  private void SubscribeToIprModelChange()
  {
    this.UnregisterSubscription(this._IprModelChangedSubscription);
    if (this.IPRModelViewModel == null || this.IPRModelViewModel.Model == (CompletionModel) null)
      return;
    this._IprModelChangedSubscription = this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) this.IPRModelViewModel.Model, new EventHandler<DomainObjectChangeEventArgs>(this.OnPerforationChanged)));
  }

  public bool IsConditionalIPRCalculationBasis
  {
    get
    {
      return this.IPRModelViewModel != null && this.IPRModelViewModel.IsConditionalIPRCalculationBasis;
    }
  }

  [UnitMeasurement("Deviation")]
  public double CompletionDeviationCalculated
  {
    get
    {
      if (this._completionDeviationCalculatedNeedsUpdate)
      {
        this._completionDeviationCalculated = this.DataSource.GetDeviationAngleAtLocation();
        this._completionDeviationCalculatedNeedsUpdate = false;
      }
      return this._completionDeviationCalculated;
    }
  }

  [UnitMeasurement("Inside_Diameter")]
  public double CasingIdCalculated => this.DataSource.GetAssociatedCasingID();

  public FluidMode FluidMode => this._model.FluidType;

  public GridItemCollection<ViewModelGridItem<CompletionTestPoint>> TestPoints { get; private set; }

  public FluidLinkFluidSourceViewModel FluidSourceViewModel { get; private set; }

  public ICommand DeleteSelectedI
