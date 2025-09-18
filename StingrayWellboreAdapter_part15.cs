b.Production.Engineering.Model.StandardDomain.WellHead.FlowPathOpenTypes.TubingOne) ? (DrawingGroup) advancedWellhead.FindResource((object) "WellHeadSingleStringAndAnnulus") : (DrawingGroup) advancedWellhead.FindResource((object) "EmptyWellHead");
    }
  }

  private void DoSurfaceEquipmentSelected(NamedItem selectedItem)
  {
    if (this.SurfaceEquipmentSelected == null)
      return;
    this.SurfaceEquipmentSelected((object) this, new NamedItemEventArgs(selectedItem));
  }

  private string GetDownholeEquipmentType(BaseWellboreItem obj)
  {
    if (obj == null || obj.Tag == null)
      return "Equipment";
    return (object) (obj.Tag as GasLiftInjection) != null ? CoreStrings.Gaslift_Label : obj.Tag.GetType().Name;
  }

  private void AddWatch(ModelItem item)
  {
    if (this._watchedObjects.ContainsKey((object) item))
      return;
    this._watchedObjects.Add((object) item, (object) null);
    item.Changed += new EventHandler<DomainObjectChangeEventArgs>(this.DataItemChanged);
  }

  private void RemoveWatch(ModelItem item)
  {
    if (!this._watchedObjects.ContainsKey((object) item))
      return;
    this._watchedObjects.Remove((object) item);
    item.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.DataItemChanged);
  }

  private void AddWatch(INotifyCollectionChanged collection)
  {
    if (this._watchedObjects.ContainsKey((object) collection))
      return;
    this._watchedObjects.Add((object) collection, (object) null);
    collection.CollectionChanged += new NotifyCollectionChangedEventHandler(this.CollectionChanged);
  }

  private void ClearWatches()
  {
    if (this._watchedBranchItems != null)
    {
      foreach (NamedItem watchedBranchItem in this._watchedBranchItems)
      {
        watchedBranchItem.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.EquipmentChanged);
        if ((object) (watchedBranchItem as Equipment) != null)
        {
          Connection connecti
