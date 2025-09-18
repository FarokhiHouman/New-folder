    this._fluidLinkSubscription.Dispose();
      this._fluidLinkViewModel = value;
      this._fluidLinkSubscription = (ISubscription) null;
      if (this._fluidLinkViewModel != null)
      {
        this.UpdateCompletionDeviation();
        this.UpdateCompletionType();
        this._fluidLinkSubscription = this.RegisterSubscription((ISubscription) new NotifyPropertyChangedSubscription((INotifyPropertyChanged) this._fluidLinkViewModel, new PropertyChangedEventHandler(this.FluidLinkViewModel_PropertyChanged)));
      }
      this.OnPropertyChanged(nameof (FluidLinkViewModel));
    }
  }

  public GravelPackViewModel GravelPackViewModel { get; private set; }

  public IEnumerable<PointCompletionType> CompletionTypeMethods
  {
    get
    {
      return this.FluidLinkViewModel == null ? (IEnumerable<PointCompletionType>) null : (IEnumerable<PointCompletionType>) SkinDarcyViewModel._fluidLinkTypeMappings[this.FluidLinkViewModel.Type];
    }
  }

  public bool IsOpenHoleWellCompletionType
  {
    get
    {
      return this.DataSource.WellCompletionType == PointCompletionType.OpenHole || this.DataSource.WellCompletionType == PointCompletionType.OpenHoleGravelPack;
    }
  }

  public bool IsSkinDamagedZoneSupported
  {
    get
    {
      return SkinDarcyViewModel._skinSupportMappings[this.DataSource.WellCompletionType].Contains(SkinComponentType.DamagedZone);
    }
  }

  public bool IsSkinCompactedZoneSupported
  {
    get
    {
      return SkinDarcyViewModel._skinSupportMappings[this.DataSource.WellCompletionType].Contains(SkinComponentType.CompactedZone);
    }
  }

  public bool IsSkinPartialPenetrationSupported
  {
    get
    {
      return SkinDarcyViewModel._skinSupportMappings[this.DataSource.WellCompletionType].Contains(SkinComponentType.PartialPenetration);
    }
  }

  public bool IsSkinGravelPackSupported
  {
    get
    {
      return SkinDarcyViewModel._skinSupportMappings[this.DataSource.WellCo
