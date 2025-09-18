"4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
      this.DetailedViewTailTubingGrid = (CustomDataGrid) target;
    else
      this._contentLoaded = true;
  }
}

