ewModel<RelativePermeabilityPoint>(permeabilityPoint)));
      this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) permeabilityPoint, new EventHandler<DomainObjectChangeEventArgs>(this.Point_Changed)));
    }
  }

  private bool CanDeleteSelectedPermeabilityItems(object parameter)
  {
    return parameter is IList source && source.OfType<ViewModelGridItem<RelativePermeabilityPoint>>().Any<ViewModelGridItem<RelativePermeabilityPoint>>();
  }

  private void DeleteSelectedPermeabilityItems(object parameter)
  {
    this.DeleteSelectedPermeabilityItems((IEnumerable<ViewModelGridItem<RelativePermeabilityPoint>>) ((IEnumerable) parameter).OfType<ViewModelGridItem<RelativePermeabilityPoint>>().ToList<ViewModelGridItem<RelativePermeabilityPoint>>(), true);
    this.OnPropertyChanged("RelativePermeabilityPoints");
  }

  private void DeleteSelectedPermeabilityItems(
    IEnumerable<ViewModelGridItem<RelativePermeabilityPoint>> gridList,
    bool updateRelativePermeabilityPoints = false)
  {
    if (this.IsTransactionPending())
      return;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      foreach (ViewModelGridItem<RelativePermeabilityPoint> grid in gridList)
      {
        if (grid != null)
        {
          RelativePermeabilityPoint data = grid.Data;
          data.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.Point_Changed);
          nuTransaction.Lock((object) this.DataSource, (object) this.DataSource.RelativePermeabilityData, (object) data);
          FacadeAccessor.Delete<RelativePermeabilityPoint>(data);
          if (updateRelativePermeabilityPoints)
            this.RelativePermeabilityPoints.Remove(grid);
        }
      }
      nuTransaction.Commit();
      this.UpdatePending = true;
    }
  }

  private void RegisterCasingSubscription()
  {
    if (this._casingSubscription != null)
      this.UnregisterSubscription(
