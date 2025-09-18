.Italic : FontStyles.Normal;
    FontWeight weight = bold ? FontWeights.Bold : FontWeights.Medium;
    return TextWrapper.CreateFormattedText(text, CultureInfo.GetCultureInfo("en-us"), System.Windows.FlowDirection.LeftToRight, new Typeface(fontFamily, style, weight, FontStretches.Normal), fontSize, (Brush) Brushes.Black).BuildGeometry(origin);
  }

  private static ModelItemType GetModelItemType(BaseWellboreItem item)
  {
    ModelItemType modelItemType = ModelItemType.Undefined;
    switch (item)
    {
      case Casing _:
        modelItemType = ModelItemType.CasingSection;
        break;
      case Tubing _:
        modelItemType = ModelItemType.TubingSection;
        break;
      case PackerWellboreItemView _:
        modelItemType = ModelItemType.Packer;
        break;
      case TubingPlugWellboreItemView _:
        modelItemType = ModelItemType.TubingPlug;
        break;
      case Slb.Ocean.UI.WellboreSchematic.Perforation _:
        modelItemType = ModelItemType.Perforation;
        break;
      case FCVWellboreItemView _:
        modelItemType = ModelItemType.FlowControlValve;
        break;
      case SlidingSleeve _:
        modelItemType = ModelItemType.SlidingSleeve;
        break;
      case DownholeSeparator _:
        modelItemType = ModelItemType.SinglePhaseSeparator;
        break;
      case SSSVWellboreItemView _:
        modelItemType = ModelItemType.SSSV;
        break;
      case FloatCollar _:
        modelItemType = ModelItemType.Choke;
        break;
      case DepthReferenceWellboreItemView _:
        modelItemType = ModelItemType.NodalPoint;
        break;
      case ESPWellboreItemView _:
        modelItemType = ModelItemType.ESP;
        break;
      case PCPWellboreItemView _:
        modelItemType = ModelItemType.PCP;
        break;
      case RodPumpWellboreItemView _:
        modelItemType = ModelItemType.RodPump;
        break;
      case GasLiftInjectionWellboreItemView _:
    
