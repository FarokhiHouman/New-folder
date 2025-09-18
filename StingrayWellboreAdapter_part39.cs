oleLocation = tag2.Location as DownholeLocation;
        if (downholeLocation != (DownholeLocation) null)
        {
          nuTransaction.Lock((object) downholeLocation);
          Slb.Production.Engineering.Model.StandardDomain.Perforation tag3 = baseWellboreItem.Tag as Slb.Production.Engineering.Model.StandardDomain.Perforation;
          if (tag3 != (Slb.Production.Engineering.Model.StandardDomain.Perforation) null)
            downholeLocation.BottomMeasuredDepth = tag3.FluidEntryType != FluidEntryType.Distributed ? baseWellboreItem.TopDepth : baseWellboreItem.TopDepth + Math.Abs(baseWellboreItem.Length);
        }
      }
      else
      {
        object tag4 = baseWellboreItem.Tag;
        MeasurementPoint measurementPoint = tag4 as MeasurementPoint;
        if ((object) measurementPoint == null)
        {
          ZoneLink zoneLink = tag4 as ZoneLink;
          if ((object) zoneLink != null)
          {
            nuTransaction.Lock((object) zoneLink);
            zoneLink.ZoneTopMeasuredDepth = baseWellboreItem.TopDepth;
            zoneLink.ZoneBottomMeasuredDepth = baseWellboreItem.TopDepth + baseWellboreItem.Length;
          }
        }
        else
        {
          downholeLocation = measurementPoint.Location as DownholeLocation;
          if (tag1 != (WellString) null && measurementPoint.WellString != tag1)
          {
            nuTransaction.Lock((object) measurementPoint, (object) measurementPoint.WellString);
            measurementPoint.WellString = tag1;
            flag = true;
          }
        }
      }
      if (downholeLocation != (DownholeLocation) null)
      {
        nuTransaction.Lock((object) downholeLocation);
        downholeLocation.TopMeasuredDepth = baseWellboreItem.TopDepth;
      }
      nuTransaction.Commit();
      this._wellHead?.RefreshFlowPath();
    }
    if (flag)
      ServiceDirectory.GetService<IStateService>()?.FireStateChangedEvent(new ActionEventArgs<string, obje
