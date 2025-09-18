Func<object>>) (() => this.DataSource.Name)) : viewModelPropertyName;
  }

  protected override string GetValidationPropertyNameFromViewModelPropertyName(
    string propertyName,
    out ModelItem propertyOwner)
  {
    propertyOwner = (ModelItem) this.DataSource;
    return this.GetValidationPropertyNameFromViewModelPropertyName(propertyName);
  }

  protected override string GetPropertyError(string propertyName)
  {
    if (!PerforationViewModel._viewModelProperties.Contains(propertyName))
      return base.GetPropertyError(propertyName);
    return this._propertyErrors.ContainsKey(propertyName) ? this._propertyErrors[propertyName] : string.Empty;
  }

  private void UpdateIPROptions()
  {
    this._completionFluidEntryGeometryProfileMode = this.DataSource.FluidEntryType != FluidEntryType.SinglePoint ? (this.DataSource.GeometryProfileType == GeometryProfileType.Vertical ? PerforationViewModel.CompletionFluidEntryGeometryProfileMode.DistributedVertical : PerforationViewModel.CompletionFluidEntryGeometryProfileMode.DistributedHorizontal) : (this.DataSource.GeometryProfileType == GeometryProfileType.Vertical ? PerforationViewModel.CompletionFluidEntryGeometryProfileMode.SinglePointVertical : PerforationViewModel.CompletionFluidEntryGeometryProfileMode.SinglePointHorizontal);
    this.OnPropertyChanged("IPRModelTypeOptions");
    if (this.IPRModelTypeOptions == null || !this.IPRModelTypeOptions.Any<IPRModelType>() || this.IPRModelTypeOptions.Contains<IPRModelType>(this.IPRModelType))
      return;
    this.IPRModelType = this.IPRModelTypeOptions.First<IPRModelType>();
  }

  private void PerforationViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
  {
    if (e.PropertyName == "FluidEntryType")
    {
      if (!this.GeometryProfileTypeOptions.Contains<GeometryProfileType>(this.DataSource.GeometryProfileType))
        this.SetValue("GeometryProfileType", (object) this.GeometryProfileTypeOptions.First<GeometryProfileTy
