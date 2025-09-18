bject, WellEditorTabs>) (o => WellEditorTabs.ArtificialLiftTab)
    },
    {
      typeof (CableCatalogData),
      (Func<object, WellEditorTabs>) (o => WellEditorTabs.ArtificialLiftTab)
    },
    {
      typeof (ESPSeabedImpl),
      (Func<object, WellEditorTabs>) (o => WellEditorTabs.ArtificialLiftTab)
    },
    {
      typeof (PCP),
      (Func<object, WellEditorTabs>) (o => WellEditorTabs.ArtificialLiftTab)
    },
    {
      typeof (PCPSeabedImpl),
      (Func<object, WellEditorTabs>) (o => WellEditorTabs.ArtificialLiftTab)
    },
    {
      typeof (RodPump),
      (Func<object, WellEditorTabs>) (o => WellEditorTabs.ArtificialLiftTab)
    },
    {
      typeof (TrajectoryMeasurement),
      (Func<object, WellEditorTabs>) (o => WellEditorTabs.DeviationSurvey)
    },
    {
      typeof (WellTrajectory),
      (Func<object, WellEditorTabs>) (o => WellEditorTabs.DeviationSurvey)
    },
    {
      typeof (BoreholeGeothermalSurvey),
      (Func<object, WellEditorTabs>) (o => WellEditorTabs.HeatTransfer)
    },
    {
      typeof (Borehole),
      (Func<object, WellEditorTabs>) (o => WellEditorTabs.HeatTransfer)
    },
    {
      typeof (GLResponseOperation),
      (Func<object, WellEditorTabs>) (o => WellEditorTabs.ArtificialLiftTab)
    }
  };

  private static WellEditorTabs Choke(object item)
  {
    return !DataHelper.IsNullObject((IDomainObject) (item as Slb.Production.Engineering.Model.StandardDomain.Choke).WellString) ? WellEditorTabs.DownholeEquipmentTab : WellEditorTabs.SurfaceEquipmentTab;
  }

  private static WellEditorTabs Injector(object item)
  {
    return !DataHelper.IsNullObject((IDomainObject) (item as Slb.Production.Engineering.Model.StandardDomain.Injector).WellString) ? WellEditorTabs.DownholeEquipmentTab : WellEditorTabs.SurfaceEquipmentTab;
  }

  private static WellEditorTabs NodalMeasurementPoint(object item)
  {
    return !DataHelper.IsNullObject((IDomainObject) (item as Slb.Prod
