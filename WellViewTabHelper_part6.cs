uction.Engineering.Model.StandardDomain.NodalMeasurementPoint).WellString) ? WellEditorTabs.DownholeEquipmentTab : WellEditorTabs.SurfaceEquipmentTab;
  }

  private static WellEditorTabs EngineKeywords(object item)
  {
    return !DataHelper.IsNullObject((IDomainObject) (item as Slb.Production.Engineering.Model.StandardDomain.EngineKeywords).WellString) ? WellEditorTabs.DownholeEquipmentTab : WellEditorTabs.SurfaceEquipmentTab;
  }

  private static WellEditorTabs SpotReport(object item)
  {
    return !DataHelper.IsNullObject((IDomainObject) (item as Slb.Production.Engineering.Model.StandardDomain.SpotReport).WellString) ? WellEditorTabs.DownholeEquipmentTab : WellEditorTabs.SurfaceEquipmentTab;
  }

  private static WellEditorTabs UserEquipment(object o)
  {
    switch ((o as Slb.Production.Engineering.Model.StandardDomain.UserEquipment).UserEquipmentType)
    {
      case UserEquipmentType.Surface:
        return WellEditorTabs.SurfaceEquipmentTab;
      case UserEquipmentType.ArtificialLift:
        return WellEditorTabs.ArtificialLiftTab;
      case UserEquipmentType.Downhole:
        return WellEditorTabs.DownholeEquipmentTab;
      default:
        return WellEditorTabs.SurfaceEquipmentTab;
    }
  }

  public static int GetSelectedTabIndex(object newValue, int currentIndex)
  {
    if (newValue is ValidationIssue validationIssue)
    {
      if (validationIssue.Message == CoreResourceStrings.Validation_Well_Looped_Branches)
        return 7;
      newValue = (object) validationIssue.PropertyOwner;
    }
    if (newValue == null)
      return currentIndex;
    DownholeLocation downholeLocation = newValue as DownholeLocation;
    if (downholeLocation != (DownholeLocation) null)
    {
      INuDataSource dataSource = downholeLocation.DataSource;
      EquipmentAccessor.QueryCriteria criteria = new EquipmentAccessor.QueryCriteria();
      criteria.Location = (QueryConstraint<EquipmentLocation>) (EquipmentLocation) down
