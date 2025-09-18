FluidEntryGeometryProfileMode _completionFluidEntryGeometryProfileMode;
  private int selectedIndex;
  private static readonly Dictionary<PerforationViewModel.CompletionFluidEntryGeometryProfileMode, List<IPRModelType>> _IPRModelTypeModeMappings;
  private static readonly Dictionary<FluidEntryType, List<GeometryProfileType>> _fluidEntryGeometryProfileMappings;
  private static readonly HashSet<string> _viewModelProperties;
  private readonly Dictionary<string, string> _propertyErrors = new Dictionary<string, string>();
  private static IEnumerable<FluidEntryType> _fluidEntryOptions;

  static PerforationViewModel()
  {
    Dictionary<string, PerforationViewModel.TabNumbers> dictionary = new Dictionary<string, PerforationViewModel.TabNumbers>();
    dictionary.Add("Pressure", PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add("ReservoirPressure", PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add("Temperature", PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add("ReservoirTemperature", PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<PIModel, double>((Expression<Func<PIModel, double>>) (m => m.GasPI)), PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<PIModel, double>((Expression<Func<PIModel, double>>) (m => m.LiquidPI)), PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<VogelModel, double>((Expression<Func<VogelModel, double>>) (m => m.AbsoluteOpenFlowPotential)), PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<VogelModel, double>((Expression<Func<VogelModel, double>>) (m => m.VogelCoefficient)), PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add(S
