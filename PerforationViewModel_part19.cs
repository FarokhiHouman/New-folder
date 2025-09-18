pe>());
      this.OnPropertyChanged("GeometryProfileTypeOptions");
      this.OnPropertyChanged("FluidEntry");
      this.UpdateIPROptions();
    }
    else if (e.PropertyName == "GeometryProfileType")
    {
      this.OnPropertyChanged("FluidEntry");
      this.OnPropertyChanged("FluidEntryTypeOptions");
      this.UpdateIPROptions();
    }
    else
    {
      if (!(e.PropertyName == "CompModel"))
        return;
      this.IPRModelType = this.DataSource.GetIPRModelType();
      this.OnPropertyChanged("IPRModelType");
    }
  }

  private void Model_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    if (!e.PropertyNames.Contains<string>("DefaultErosionModel"))
      return;
    this.OnPropertyChanged("HasSandConfiguration");
  }

  private void PerforationChanged(object sender, DomainObjectChangeEventArgs e)
  {
    if (!e.PropertyNames.Contains<string>("CompModel"))
      return;
    this.OnPropertyChanged("Type");
  }

  private void SetupValidation()
  {
    if (this.validationService == null)
      return;
    this.RegisterSubscription((ISubscription) new ValidationCompletedSubscription(this.validationService, new EventHandler<ValidateArgs>(this.ValidationService_Validated)));
  }

  private void ValidationService_Validated(object sender, ValidateArgs e)
  {
    bool flag = this._propertyErrors.Count > 0;
    this._propertyErrors.Clear();
    this.Errors.Clear();
    foreach (ValidationIssue validationIssue in e.Issues.Where<ValidationIssue>((Func<ValidationIssue, bool>) (x => (object) x.PropertyOwner == (object) this.DataSource)))
    {
      string key = validationIssue.Property;
      if (key == "Name")
        key = "ItemName";
      if (PerforationViewModel._viewModelProperties.Contains(key))
        this._propertyErrors[key] = validationIssue.Message;
    }
    if (!flag && this._propertyErrors.Count <= 0)
      return;
    this.BeginInvoke(new Action(this.TriggerValidationErrors), Dispa
