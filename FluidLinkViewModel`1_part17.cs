s._model) : this.AssociatedZone.GetAssociatedFluid(this._model);
    if (!(fluid != (Fluid) null))
      return;
    this._fluidChangesSubscriptions.Add(this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) fluid, new EventHandler<DomainObjectChangeEventArgs>(this.GlobalFluid_DataChanged))));
    this._validationStatusDictionary.TryAdd((ModelItem) fluid, false);
    if (this.validationService == null)
      return;
    foreach (IValidation key in (IEnumerable<ModelItem>) this._validationStatusDictionary.Keys)
      this.validationService.QueueInToBeValidatedItems(key);
  }

  private void GlobalFluid_DataChanged(object sender, DomainObjectChangeEventArgs args)
  {
    if (!args.PropertyNames.Any<string>((Func<string, bool>) (propName => ((IEnumerable<string>) this._blackOilProperties).Contains<string>(propName))))
      return;
    this.OnPropertyChanged((string) null);
  }

  private void SetupValidation()
  {
    this.UpdateIPRValidationStatusDictionary();
    if (this.validationService == null)
      return;
    this.RegisterSubscription((ISubscription) new ValidationCompletedSubscription(this.validationService, new EventHandler<ValidateArgs>(this.ValidationService_Validated)));
    foreach (IValidation key in (IEnumerable<ModelItem>) this._validationStatusDictionary.Keys)
      this.validationService.QueueInToBeValidatedItems(key);
  }

  private void ValidationService_Validated(object sender, ValidateArgs e)
  {
    foreach (ModelItem key in (IEnumerable<ModelItem>) this._validationStatusDictionary.Keys)
      this._validationStatusDictionary[key] = this.CheckItemStatusWithIssues(key, e.Issues);
    if (!this.NeedIprUpdate)
      return;
    this.BeginInvoke((Action) (() => this.UpdateIPR(this.OnValidate())), DispatcherPriority.Normal);
  }

  private void RecalculateCompletionModelValue()
  {
    if ((FluidLink) this.DataSource == (FluidLink) null || this.DataSource.CompModel 
