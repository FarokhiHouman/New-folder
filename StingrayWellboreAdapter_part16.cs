on1 = ((Equipment) watchedBranchItem).ConnectionsFrom.FirstOrDefault<Connection>();
          Connection connection2 = ((Equipment) watchedBranchItem).ConnectionsTo.FirstOrDefault<Connection>();
          if (connection1 != (Connection) null)
            connection1.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.ConnectionChanged);
          if (connection2 != (Connection) null)
            connection2.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.ConnectionChanged);
        }
      }
    }
    foreach (object key in this._watchedObjects.Keys)
    {
      ModelItem modelItem = key as ModelItem;
      if (modelItem != (ModelItem) null)
        modelItem.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.DataItemChanged);
      else if (key is INotifyCollectionChanged)
        ((INotifyCollectionChanged) key).CollectionChanged -= new NotifyCollectionChangedEventHandler(this.CollectionChanged);
    }
    this._watchedObjects.Clear();
  }

  private void SetupDisplayUnits(Wellbore wellbore)
  {
    IUnitMeasurement unitMeasurement1 = this._unitServiceSettings.CurrentCatalog.GetUnitMeasurement("Distance");
    IUnit unit1 = this._unitServiceSettings.CurrentUISystem.GetUnit(unitMeasurement1);
    IUnit unit2 = this._unitServiceSettings.InvariantSystem.GetUnit(unitMeasurement1);
    IUnitConverter converter1 = this._unitServiceSettings.CurrentCatalog.GetConverter(unitMeasurement1, unit2, unit1);
    wellbore.DisplayUnits.Depth.ConversionFactor = (double) converter1.Convert(1f);
    wellbore.DisplayUnits.Depth.Symbol = UnitsHelper.GetDisplaySymbol(unit1.Symbol);
    IUnitMeasurement unitMeasurement2 = this._unitServiceSettings.CurrentCatalog.GetUnitMeasurement("Inside_Diameter");
    IUnit unit3 = this._unitServiceSettings.CurrentUISystem.GetUnit(unitMeasurement2);
    IUnit unit4 = this._unitServiceSettings.InvariantSystem.GetUnit(unitMeasurement2);
    IUnitConverter converter2 = this._unitServiceSet
