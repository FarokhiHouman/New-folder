astructure.Expressions.GetPropertyName((Expression<Func<object>>) (() => (object) wellHead.GasSpecificGravity));
  }

  private bool NeedRecalculateLayout { get; set; }

  static WellHeadViewModel()
  {
    ObservableCollection<TubingConfigType> observableCollection = new ObservableCollection<TubingConfigType>();
    observableCollection.Add(TubingConfigType.SingleString);
    WellHeadViewModel.TubingTypes = observableCollection;
  }

  public WellHeadViewModel(Slb.Production.Engineering.Model.StandardDomain.WellHead wellHead)
    : this(wellHead, (Func<ContextTabDefinition>) (() => new ContextTabDefinition(CoreStrings.Well, typeof (WellHeadView))))
  {
  }

  public WellHeadViewModel(Slb.Production.Engineering.Model.StandardDomain.WellHead wellHead, Func<ContextTabDefinition> contextTabFactory)
    : this(wellHead, ServiceDirectory.GetService<IStateService>(), ServiceDirectory.GetService<IPluginService>(), contextTabFactory)
  {
  }

  private WellHeadViewModel(
    Slb.Production.Engineering.Model.StandardDomain.WellHead wellHead,
    IStateService stateService,
    IPluginService pluginService,
    Func<ContextTabDefinition> contextTabFactory)
  {
    ObservableCollection<WellType> observableCollection1 = new ObservableCollection<WellType>();
    observableCollection1.Add(WellType.Production);
    observableCollection1.Add(WellType.Injection);
    this._twoOptionsWellTypes = observableCollection1;
    ObservableCollection<WellType> observableCollection2 = new ObservableCollection<WellType>();
    observableCollection2.Add(WellType.Production);
    observableCollection2.Add(WellType.Injection);
    observableCollection2.Add(WellType.Advanced);
    this._threeOptionsWellTypes = observableCollection2;
    this._navigators = new Dictionary<Type, IWellViewNavigateFromValidation>();
    this._disposables = new List<IDisposable>();
    // ISSUE: explicit constructor call
    base.\u002Ector(wellHead);
    if (wellHead == (Slb.Pro
