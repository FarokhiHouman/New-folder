is._wellboreAdapter = (StingrayWellboreAdapter) null;
    }
    base.Dispose(disposing);
  }

  protected override bool OnValidate() => true;

  private bool CanToggleSelectedItemLabelVisibility(object parameter)
  {
    return !this.IsDisposed && this._wellboreAdapter.WellboreSchematic.SelectedItem != null;
  }

  private bool CanDeleteSelectedWellboreItem(object parameter)
  {
    if (this.IsDisposed)
      return false;
    BaseWellboreItem selectedItem = this._wellboreAdapter.WellboreSchematic.SelectedItem;
    if (selectedItem is Casing)
    {
      TubingSection tag = selectedItem.Tag as TubingSection;
      if ((object) tag != null)
        return tag.WellString.Sections.Count > 1;
    }
    return selectedItem != null && !(selectedItem is FlowPath) && !(selectedItem is Slb.Ocean.UI.WellboreSchematic.WellHead);
  }

  private void DeleteSelectedWellboreItem(object parameter)
  {
    BaseWellboreItem selectedItem = this._wellboreAdapter.WellboreSchematic.SelectedItem;
    if (selectedItem == null || !this._viewService.Warn(CoreStrings.Delete, string.Format(CoreStrings.DeleteItemName, (object) selectedItem.Label)))
      return;
    selectedItem.Delete();
    ZoneLink tag = selectedItem.Tag as ZoneLink;
    if (tag != (ZoneLink) null)
      this.DeleteSelectedModelItem((ModelItem) tag);
    this._activeWellItemNotifier.Refresh((object) this);
  }

  private void DeleteSelectedModelItem(ModelItem item)
  {
    ZoneLink facadeObject = item as ZoneLink;
    if (facadeObject == (ZoneLink) null)
      return;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      nuTransaction.Lock((object) facadeObject);
      FacadeAccessor.Delete<ZoneLink>(facadeObject);
      nuTransaction.Commit();
    }
    this._wellboreAdapter.SelectItem((ModelItem) null);
  }

  private void ToggleSelectedItemLabelVisibility(object parameter)
  {
    BaseWellboreItem selectedItem = this._wellboreAdapter.Wel
