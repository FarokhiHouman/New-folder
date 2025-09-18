temsCommand { get; private set; }

  private bool NeedIprUpdate { get; set; }

  private bool IsActiveView { get; set; }

  public void SetActiveView(bool isActive)
  {
    this.IsActiveView = isActive;
    this.NeedIprUpdate = true;
    this.BeginInvoke((Action) (() => this.UpdateIPR(this.OnValidate())), DispatcherPriority.Normal);
  }

  protected override string GetPropertyError(string propertyName)
  {
    if ((propertyName == "Pressure" || propertyName == "Temperature") && this.DataSource.GetAssociatedZone() != (Zone) null)
      return string.Empty;
    switch (propertyName)
    {
      case "Pressure":
        return base.GetPropertyError("ReservoirPressure");
      case "Temperature":
        return base.GetPropertyError("ReservoirTemperature");
      default:
        return propertyName.Equals("ItemName", StringComparison.Ordinal) && NameValidator.IsNameInvalid(this.DataSource.Name) ? CoreResourceStrings.Validation_NameCannotContainSpecialcharacter : base.GetPropertyError(propertyName);
    }
  }

  protected override string GetValidationPropertyNameFromViewModelPropertyName(
    string viewModelPropertyName)
  {
    return viewModelPropertyName;
  }

  protected override bool OnValidate()
  {
    return this.validationService == null || this._validationStatusDictionary.All<KeyValuePair<ModelItem, bool>>((Func<KeyValuePair<ModelItem, bool>, bool>) (x => x.Value));
  }

  private IDisposable SuspendViewModelCreation()
  {
    Action disposeAction = (Action) (() => this.creatingViewModel = false);
    this.creatingViewModel = true;
    return (IDisposable) new DisposableToken(disposeAction);
  }

  private void UpdateIPRModelViewModel()
  {
    if (this.creatingViewModel)
      return;
    using (this.SuspendViewModelCreation())
    {
      switch (this.IPRModelType)
      {
        case IPRModelType.WellPI:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelPIViewModel>(
