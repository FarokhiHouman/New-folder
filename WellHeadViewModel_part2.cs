IActiveItemNotifier,
  IWellViewNavigationService,
  IRecalculateLayout
{
  private readonly IPluginService _pluginService;
  private readonly Func<ContextTabDefinition> _contextTabFactory;
  private ContextTabDefinition _contextTabDefinitionDownhole;
  private ContextTabDefinition _contextTabDefinitionSurface;
  private TabDefinition _insertDownholeTabDefinition;
  private TabDefinition _insertSurfaceTabDefinition;
  private TabDefinition _formatTabDefinition;
  private BoreholeArtificialLiftViewModel _boreholeArtificialLiftViewModel;
  private BoreholeCompletionsViewModel _boreholeCompletionsViewModel;
  private BoreholeDownholeEquipmentViewModel _boreholeDownholeEquipmentViewModel;
  private BoreholeViewModel _boreholeViewModel;
  private readonly HashSet<IWellRefresh> _refreshViewModels;
  private IRibbonService _ribbonService;
  private ModelItem _activeItem;
  private int _selectedIndex;
  private readonly Dictionary<Type, Func<ValidationIssue, bool>> _isGasliftIssueMap;
  private readonly ObservableCollection<WellType> _twoOptionsWellTypes;
  private readonly ObservableCollection<WellType> _threeOptionsWellTypes;
  private readonly Dictionary<Type, IWellViewNavigateFromValidation> _navigators;
  private readonly ConventionalWellButtonCommand currentNodalPointCommand;
  private readonly AdvancedWellButtonCommand currentFcvButtonCommand;
  private readonly TailPipeCommand currentTailPipeCommand;
  private List<IDisposable> _disposables;

  private static bool IsGasliftIssueDesign(ValidationIssue issue)
  {
    return issue.Property == "AssociatedFluidNull";
  }

  private static bool IsGasliftIssueWellhead(ValidationIssue issue)
  {
    Slb.Production.Engineering.Model.StandardDomain.WellHead wellHead = issue.PropertyOwner as Slb.Production.Engineering.Model.StandardDomain.WellHead;
    return issue.Path.Contains(CoreResourceStrings.Validation_ArtificialLiftEquipment) || issue.Property == Slb.Production.Engineering.Model.Infr
