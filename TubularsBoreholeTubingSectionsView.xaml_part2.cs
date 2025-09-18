le(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
      this.DetailedViewTubingGrid = (CustomDataGrid) target;
    else
      this._contentLoaded = true;
  }
}

