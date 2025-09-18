r)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
      this.DetailedViewCasingGrid = (CustomDataGrid) target;
    else
      this._contentLoaded = true;
  }
}

