 string> ViewModelPropertiesMapInverse
  {
    get
    {
      Dictionary<string, string> propertiesMapInverse = TubingSectionViewModel._viewModelPropertiesMapInverse;
      if (propertiesMapInverse != null)
        return propertiesMapInverse;
      Dictionary<string, string> modelPropertiesMap = TubingSectionViewModel._viewModelPropertiesMap;
      return TubingSectionViewModel._viewModelPropertiesMapInverse = modelPropertiesMap.ToDictionary<KeyValuePair<string, string>, string, string>((Func<KeyValuePair<string, string>, string>) (pair => pair.Value), (Func<KeyValuePair<string, string>, string>) (pair => pair.Key));
    }
  }

  static TubingSectionViewModel()
  {
    ObservableCollection<SectionType> observableCollection1 = new ObservableCollection<SectionType>();
    observableCollection1.Add(SectionType.Casing);
    observableCollection1.Add(SectionType.Liner);
    observableCollection1.Add(SectionType.OpenHole);
    TubingSectionViewModel.CasingLinerOpenHoleSectionTypes = observableCollection1;
    ObservableCollection<SectionType> observableCollection2 = new ObservableCollection<SectionType>();
    observableCollection2.Add(SectionType.Casing);
    observableCollection2.Add(SectionType.OpenHole);
    TubingSectionViewModel.CasingOpenHoleSectionTypes = observableCollection2;
    ObservableCollection<SectionType> observableCollection3 = new ObservableCollection<SectionType>();
    observableCollection3.Add(SectionType.OpenHole);
    TubingSectionViewModel.OpenHoleOnlySectionTypes = observableCollection3;
    ObservableCollection<SectionType> observableCollection4 = new ObservableCollection<SectionType>();
    observableCollection4.Add(SectionType.Casing);
    TubingSectionViewModel.CasingOnlySectionTypes = observableCollection4;
  }

  public TubingSectionViewModel(TubingSection model, BoreholeTubingViewModel parent)
    : base(model)
  {
    this.parentBorehole = parent;
    this.RegisterSubscription((ISubscription) new Doma
