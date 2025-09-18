void WellItemSelectionChanged(object sender, EventArgs eventArgs)
  {
    this.SetWellboreAdapterSelectItem();
  }

  private void SetWellboreAdapterSelectItem()
  {
    if (this._wellboreAdapter == null || this._wellItemSelectedSubscription == null)
      return;
    using (this._wellItemSelectedSubscription.Suspend())
      this._wellboreAdapter.SelectItem(this._activeWellItemNotifier.ActiveItem);
  }

  private void WellBoreAdapter_WellboreItemSelected(object sender, WellboreEventArgs e)
  {
    this.SetActiveWellItem(e.Item != null ? e.Item.Tag as ModelItem : (ModelItem) null);
  }

  private void SetActiveWellItem(ModelItem modelItem)
  {
    using (this._itemSelectedSubscription.Suspend())
      this._activeWellItemNotifier.ActiveItem = modelItem;
  }

  private void WellBoreAdapter_SurfaceEquipmentSelected(object sender, NamedItemEventArgs e)
  {
    if (!(e.AssociatedNamedItem != (NamedItem) null))
      return;
    ModelItem associatedNamedItem = (ModelItem) e.AssociatedNamedItem;
    if (associatedNamedItem != (ModelItem) null)
      this.SetActiveWellItem(associatedNamedItem);
    this._stateService.FireStateChangedEvent(new ActionEventArgs<string, object, object>("topic://WellBoreEditorStateChanged", (object) this._activeWellItemNotifier.ActiveItem, (object) this));
  }

  private void Connections_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    if (this._wellboreAdapter == null)
      return;
    this._wellboreAdapter.RedrawWell();
  }

  private void UnitSettings_SettingsChanged(object sender, UnitSettingsEventArgs e)
  {
    if (this._wellboreAdapter == null)
      return;
    this._wellboreAdapter.RedrawWell();
  }

  public override string Title => CoreStrings.WellboreViewer;

  protected override bool OnCommit() => true;

  protected override void Dispose(bool disposing)
  {
    if (this._wellboreAdapter != null)
    {
      this._wellboreAdapter.Detach();
      th
