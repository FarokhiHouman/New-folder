ervice,
    IUnitServiceSettings unitServiceSettings,
    IDomainObjectHost domainObjectHost,
    IPresentationService presentationService,
    IViewService viewService)
  {
    this._wellboreSchematic = wellboreSchematicCanvas ?? throw new ArgumentNullException(nameof (wellboreSchematicCanvas));
    this._stateService = stateService ?? throw new ArgumentNullException(nameof (stateService));
    this._unitServiceSettings = unitServiceSettings ?? throw new ArgumentNullException(nameof (unitServiceSettings));
    this._domainObjectHost = domainObjectHost ?? throw new ArgumentNullException(nameof (domainObjectHost));
    this._presentationService = presentationService ?? throw new ArgumentNullException(nameof (presentationService));
    this._viewService = viewService ?? throw new ArgumentNullException(nameof (viewService));
    this._xamlShapeLoader = new XamlShapeLoader();
    this._selectSurfaceEquipmentCommand = (ICommand) new RelayCommand((Action<object>) (x => this.DoSurfaceEquipmentSelected((NamedItem) x)));
    this.ShowText = true;
    this._wellboreSchematic.Wellbore.Margin = new Thickness(10.0, 20.0, 20.0, 20.0);
    this._wellboreSchematic.Wellbore.LabelTrackPadding = 0.0;
  }

  public bool ShowToScaleChecked { get; set; }

  public bool ShowFlowPathChecked
  {
    get => this.GetDisplaySettings("FlowLineVisible");
    set => this.SaveDisplaySettings("FlowLineVisible", value);
  }

  public bool ShowLabelChecked
  {
    get => this.GetDisplaySettings("LabelVisible");
    set => this.SaveDisplaySettings("LabelVisible", value);
  }

  public bool ShowDepthReferenceChecked
  {
    get => this.GetDisplaySettings("DepthVisible");
    set => this.SaveDisplaySettings("DepthVisible", value);
  }

  private Slb.Production.Engineering.Model.StandardDomain.Model CurrentModel
  {
    get => DataHelper.GetCurrentWorkspaceModel();
  }

  public WellboreItemView SectionalStyle
  {
    get => this._sectionalStyle;
    set => 
