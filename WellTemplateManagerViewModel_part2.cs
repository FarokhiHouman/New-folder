ervice>(), ServiceDirectory.GetService<IDomainObjectHost>())
  {
  }

  public WellTemplateManagerViewModel(Slb.Production.Engineering.Model.StandardDomain.Model model)
    : this(model, ServiceDirectory.GetService<IStateService>(), ServiceDirectory.GetService<IViewService>(), ServiceDirectory.GetService<IDomainObjectHost>())
  {
  }

  public WellTemplateManagerViewModel(
    Slb.Production.Engineering.Model.StandardDomain.Model model,
    IStateService stateService,
    IViewService viewService,
    IDomainObjectHost domainObjectHost)
  {
    if (stateService == null)
      throw new ArgumentNullException(nameof (stateService));
    if (viewService == null)
      throw new ArgumentNullException(nameof (viewService));
    if (domainObjectHost == null)
      throw new ArgumentNullException(nameof (domainObjectHost));
    this._stateService = stateService;
    this._viewService = viewService;
    this._domainObjectHost = domainObjectHost;
    this._model = model;
    this.SetupCommands();
    this.PopulateWellDisplaysList();
    this._dispatcher = Dispatcher.CurrentDispatcher;
    this.OpenWellTemplateCommand = (ICommand) new RelayCommand(new Action<object>(this.ViewOrEditWellTemplate), new Predicate<object>(this.CanViewOrEditEnable));
    this._stateService = ServiceDirectory.GetService<IStateService>();
    this._collectionChangedSubscription = this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) this._model.TemplateWells, new NotifyCollectionChangedEventHandler(this.TemplateWellsChangedHandler)));
    this.RegisterSubscription((ISubscription) new StateChangedSubscription<ActionEventArgs<string, object, object>>(this._stateService, new Action<ActionEventArgs<string, object, object>>(this.StateService_StateChanged)));
  }

  public override string Title => CoreStrings.WellTemplateCatalog;

  public override ImageSource Image
  {
    get => ImageKey.WellTemplateCatalog.ToImageSour
