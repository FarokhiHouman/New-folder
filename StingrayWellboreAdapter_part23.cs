    {
      foreach (PerforationFlowPathNode perforationFlowPathNode in nodesToAdd)
      {
        PerforationFlowPathNode node = perforationFlowPathNode;
        if (!nodes.Any<PerforationFlowPathNode>((Func<PerforationFlowPathNode, bool>) (n => n.PerforationName.Equals(node.PerforationName))))
          nodes.Add(node);
      }
    }
  }

  private void DrawZones(Wellbore wellbore, Borehole borehole)
  {
    wellbore.FormationLeftMargin = 5.0;
    wellbore.FormationRightMargin = 5.0;
    this.AddWatch((INotifyCollectionChanged) borehole.ZoneLinks);
    foreach (ZoneLink zoneLink in (IEnumerable<ZoneLink>) borehole.ZoneLinks)
    {
      this.AddWatch((ModelItem) zoneLink);
      if (borehole.ShowZones && zoneLink.AssociatedZone.IsActive && !double.IsNaN(zoneLink.ZoneTopMeasuredDepth) && !double.IsNaN(zoneLink.ZoneBottomMeasuredDepth))
      {
        FormationLayer element = new FormationLayer();
        element.Name = zoneLink.AssociatedZone.Name;
        this.AssociateModelObject((FrameworkElement) element, (ModelItem) zoneLink);
        element.TopDepth = zoneLink.ZoneTopMeasuredDepth;
        if (double.IsNaN(element.TopDepth))
          element.TopDepth = 0.0;
        element.Length = zoneLink.ZoneBottomMeasuredDepth - zoneLink.ZoneTopMeasuredDepth;
        element.LabelTrackIndex = 0;
        switch (zoneLink.AssociatedZone.Material)
        {
          case ZoneMaterial.shale:
            element.Background = MaterialBrushes.Shale;
            break;
          case ZoneMaterial.sand:
            element.Background = MaterialBrushes.Sand;
            break;
          case ZoneMaterial.water:
            element.Background = MaterialBrushes.Water;
            break;
          default:
            element.Background = MaterialBrushes.Sand;
            break;
        }
        wellbore.FormationLayers.Add((BaseDownholeItem) element);
      }
    }
  }

  private bool GetDisplaySettings(string key)
  {
    retur
