);
          break;
      }
      SkinDarcyViewModel._skinSupportMappings.Add(key, skinComponentTypeList);
      SkinDarcyViewModel._fluidLinkTypeMappings = new Dictionary<FluidLinkType, List<PointCompletionType>>();
      SkinDarcyViewModel._fluidLinkTypeMappings.Add(FluidLinkType.OpenHole, new List<PointCompletionType>()
      {
        PointCompletionType.OpenHole,
        PointCompletionType.OpenHoleGravelPack
      });
      SkinDarcyViewModel._fluidLinkTypeMappings.Add(FluidLinkType.Perforation, new List<PointCompletionType>()
      {
        PointCompletionType.Perforated,
        PointCompletionType.GravelPackedAndPerforated,
        PointCompletionType.FracPack
      });
    }
  }

  public SkinDarcyViewModel(
    DarcyCompletionModel model,
    IFluidLinkViewModel link,
    bool performCalculation = true)
    : base(model)
  {
    this.FluidLinkViewModel = link;
    this._performCalculation = performCalculation;
    this.RegisterSubscription((ISubscription) new NotifyPropertyChangedSubscription((INotifyPropertyChanged) this, new PropertyChangedEventHandler(this.SkinDarcyViewModel_PropertyChanged)));
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) this.DataSource, new EventHandler<DomainObjectChangeEventArgs>(this.DataSource_Changed)));
    this.InitializeGravelPack();
    this.DisplayUnitMeasurement = this.DataSource.IsGasCompletion ? "Inverse_Gas_Flowrate" : "Inverse_Flowrate";
    this.RateDependentGasLiquidSkin = this.DataSource.IsGasCompletion ? "RateDependentGasSkin" : "RateDependentLiquidSkin";
  }

  public override string Title
  {
    get
    {
      return $"{CoreStrings.IPRModelType_DarcyEquation}-{new EnumResource((Enum) this.DataSource.WellCompletionType).DisplayValue}";
    }
  }

  public IFluidLinkViewModel FluidLinkViewModel
  {
    get => this._fluidLinkViewModel;
    private set
    {
      if (this._fluidLinkSubscription != null)
    
