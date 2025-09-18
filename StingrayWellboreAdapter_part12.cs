    modelItemType = ModelItemType.GasLiftInjection;
        break;
      case InjectorWellboreItemView _:
        modelItemType = ModelItemType.InjectionPoint;
        break;
      case UserEquipmentWellboreItemView _:
        modelItemType = ModelItemType.UserEquipment;
        break;
      case EngineKeywordsWellboreItemView _:
        modelItemType = ModelItemType.EngineKeywords;
        break;
      case SpotReportWellboreItemView _:
        modelItemType = ModelItemType.SpotReport;
        break;
    }
    return modelItemType;
  }

  private static void SetLabelControl(
    BaseWellboreItem equip,
    NamedItem item,
    bool showText,
    bool showValidation)
  {
    if ((object) (item as MeasurementPoint) != null)
      return;
    equip.Label.ContentControl = (Control) new LabelControl();
    equip.Label.ContentControl.DataContext = (object) new LabelControlViewModel(item, showText, showValidation);
    equip.Label.ShadowBrush = (Brush) Brushes.Transparent;
  }

  private static TubularString GetOutsideTubularStringAtDepth(
    Wellbore wellbore,
    double depth,
    TubularString stringToIgnore)
  {
    TubularString tubularStringAtDepth = (TubularString) null;
    double d = double.NaN;
    foreach (TubularString tubularString in wellbore.TubularStrings.Where<TubularString>((Func<TubularString, bool>) (i => i.Visibility == Visibility.Visible)))
    {
      BaseTubularItem upperItem;
      BaseTubularItem lowerItem;
      if (tubularString != stringToIgnore && tubularString.TubularItems.GetItemAtDepth(depth, out upperItem, out lowerItem))
      {
        if (upperItem != null && (double.IsNaN(d) || upperItem.ID > d))
        {
          tubularStringAtDepth = upperItem.TubularString;
          d = upperItem.ID;
        }
        if (lowerItem != null && (double.IsNaN(d) || lowerItem.ID > d))
        {
          tubularStringAtDepth = lowerItem.TubularString;
          d = lowerItem.ID;
        }
      
