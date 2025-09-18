if (this._refreshPending)
    {
      this._refreshPending = this._sortPending = false;
      this.BeginRefresh();
    }
    else
    {
      if (!this._sortPending)
        return;
      this._sortPending = false;
      this.Sort();
    }
  }

  private void WellHeadAccessor_Created(object sender, DomainObjectEventGroup e)
  {
    this._refreshPending = this._sortPending = true;
  }

  private void WellHeadAccessor_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    if (this._sortPending || ((WellHead) e.AffectedObject).IsTemplate || !e.PropertyNames.Intersect<string>((IEnumerable<string>) WellSelectionViewModel.PropertyNamesUsedInSort).Any<string>())
      return;
    this._sortPending = true;
  }

  private void WellHeadAccessor_Deleted(object sender, DomainObjectEventGroup e)
  {
    this._refreshPending = this._sortPending = true;
    this.BeginInvoke(new Action(((SelectionTraversalDefinition<NamedItemViewModel>) this).ForceRefresh), DispatcherPriority.ApplicationIdle);
  }
}

