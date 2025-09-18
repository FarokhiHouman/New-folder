ingDetailViewModel.TubingSectionProperties[property.Name] = property;
    BoreholeTubingDetailViewModel.ViewModelproperties = ((IEnumerable<PropertyInfo>) typeof (BoreholeTubingDetailViewModel).GetProperties()).Select<PropertyInfo, string>((Func<PropertyInfo, string>) (p => p.Name)).ToList<string>();
  }

  public BoreholeTubingDetailViewModel(TubingSection tubing)
    : this(ServiceDirectory.GetService<IViewService>(), tubing)
  {
  }

  public BoreholeTubingDetailViewModel(IViewService viewService, TubingSection tubing)
    : base(tubing)
  {
    if (viewService == null)
      throw new ArgumentNullException(nameof (viewService));
    if (this.DataSource == (TubingSection) null)
      throw new NullReferenceException("DataSource should not be null.");
    this.RegisterSubscription((ISubscription) new ValidationCompletedSubscription(this.validationService, new EventHandler<ValidateArgs>(this.ValidationService_ValidationCompleted)));
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) this.DataSource, new EventHandler<DomainObjectChangeEventArgs>(this.DataSource_Changed)));
    ObservableCollection<string> observableCollection1 = new ObservableCollection<string>();
    observableCollection1.Add("13CR80");
    observableCollection1.Add("B");
    observableCollection1.Add("C75");
    observableCollection1.Add("C90");
    observableCollection1.Add("C95");
    observableCollection1.Add("D0075");
    observableCollection1.Add("D01");
    observableCollection1.Add("D015");
    observableCollection1.Add("E0075");
    observableCollection1.Add("E01");
    observableCollection1.Add("E015");
    observableCollection1.Add("H40");
    observableCollection1.Add("J55");
    observableCollection1.Add("K01");
    observableCollection1.Add("K015");
    observableCollection1.Add("K55");
    observableCollection1.Add("L0075");
    observableCollection1.Add("L01");
    observableCollection1.Add("L0
