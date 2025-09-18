ObjectChangedSubscription((OdtDomainObjectBase) this.DataSource.FluidLink.Location, new EventHandler<DomainObjectChangeEventArgs>(this.PerforationLocation_Changed)));
    this.DeleteSelectedPermeabilityItemsCommand = (ICommand) new RelayCommand(new Action<object>(this.DeleteSelectedPermeabilityItems), new Predicate<object>(this.CanDeleteSelectedPermeabilityItems));
    this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) this.DataSource.FluidLink.WellString.Sections, new NotifyCollectionChangedEventHandler(this.Sections_CollectionChanged)));
    this.RegisterCasingSubscription();
  }

  public ReservoirShapeOption ReservoirShapeOption
  {
    get
    {
      return !this.DataSource.UseDrainageRadius ? ReservoirShapeOption.ShapeFactor : ReservoirShapeOption.DrainageRadius;
    }
    set
    {
      bool flag = value == ReservoirShapeOption.DrainageRadius;
      if (this.DataSource.UseDrainageRadius == flag)
        return;
      this.SetValue("UseDrainageRadius", (object) flag);
      this.OnPropertyChanged(nameof (ReservoirShapeOption));
    }
  }

  public bool CanSetWellboreDiameter
  {
    get
    {
      return this.DataSource.DownholeLocation != (DownholeLocation) null && this.DataSource.DownholeLocation.TopMeasuredDepth.IsNotNaN();
    }
  }

  public string BoreholeDiameterToolTip
  {
    get
    {
      return !this.CanSetWellboreDiameter ? CoreResourceStrings.BoreholeDiameterDisabledTooTip : (string) null;
    }
  }

  public bool IsVogelBelowBubblePoint
  {
    get => !this.DataSource.IsGasCompletion && this.DataSource.UseVogelBelowBubblepoint;
  }

  public GridItemCollection<ViewModelGridItem<RelativePermeabilityPoint>> RelativePermeabilityPoints { get; }

  public ICommand DeleteSelectedPermeabilityItemsCommand { get; }

  protected override bool UpdateCurveRequired(string property)
  {
    return property == "UseVogelBelowBubblepoint" || property == "UseV
