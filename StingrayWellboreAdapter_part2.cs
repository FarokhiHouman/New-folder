

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class StingrayWellboreAdapter : ISchematicUiElementProvider, ISchematicActions
{
  private static readonly Pen InactivePen = new Pen((Brush) Brushes.Red, 1.0);
  private static readonly ScaleTransform ScaleTransform = new ScaleTransform(1.0, 3.0);
  private readonly IStateService _stateService;
  private readonly IUnitServiceSettings _unitServiceSettings;
  private readonly IDomainObjectHost _domainObjectHost;
  private readonly IPresentationService _presentationService;
  private readonly IViewService _viewService;
  private readonly WellboreSchematicCanvas _wellboreSchematic;
  private readonly XamlShapeLoader _xamlShapeLoader;
  private readonly Dictionary<object, object> _watchedObjects = new Dictionary<object, object>();
  private readonly Dictionary<ModelItem, FrameworkElement> _modelUiMap = new Dictionary<ModelItem, FrameworkElement>();
  private readonly ICommand _selectSurfaceEquipmentCommand;
  private Slb.Production.Engineering.Model.StandardDomain.WellHead _wellHead;
  private List<NamedItem> _watchedBranchItems;
  private bool _showValidation;
  private bool _showText;
  private WellboreItemView _sectionalStyle = WellboreItemView.NONE;
  private ColorCode _itemColor = ColorCode.Default;
  private Slb.Ocean.UI.WellboreSchematic.WellHead _wellheadUI;
  private bool _wellboreChangingInProgress;

  public event EventHandler<NamedItemEventArgs> SurfaceEquipmentSelected;

  public StingrayWellboreAdapter(WellboreSchematicCanvas wellboreSchematicCanvas)
    : this(wellboreSchematicCanvas, ServiceDirectory.GetService<IStateService>(), ServiceDirectory.GetService<IUnitServiceSettings>(), ServiceDirectory.GetService<IDomainObjectHost>(), ServiceDirectory.GetService<IPresentationService>(), ServiceDirectory.GetService<IViewService>())
  {
  }

  public StingrayWellboreAdapter(
    WellboreSchematicCanvas wellboreSchematicCanvas,
    IStateService stateS
