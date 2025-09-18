  if (this._validationErrors.ContainsKey(propertyName))
      propertyError = this._validationErrors[propertyName];
    else if (propertyName.Equals("WellboreDiameter", StringComparison.Ordinal))
    {
      foreach (TubingSection section in (IEnumerable<TubingSection>) this.DataSource.FluidLink.WellString.Sections)
      {
        string str = section.ValidateBoreholeDiameterAndCasingOD();
        if (str != null)
        {
          propertyError = str;
          break;
        }
      }
    }
    else
      propertyError = base.GetPropertyError(propertyName);
    if (string.IsNullOrWhiteSpace(propertyError))
      this._propertyErrors.Remove(propertyName);
    else
      this._propertyErrors.Add(propertyName);
    return propertyError;
  }

  protected virtual void ValidationService_ValidationCompleted(object sender, ValidateArgs e)
  {
    this._validationErrors.Clear();
    if (e.Issues == null)
      return;
    foreach (ValidationIssue validationIssue in e.Issues.Where<ValidationIssue>((Func<ValidationIssue, bool>) (x =>
    {
      if ((object) x.PropertyOwner == (object) this.DataSource)
        return true;
      foreach (TubingSection section in (IEnumerable<TubingSection>) this.DataSource.FluidLink.WellString.Sections)
      {
        if ((object) x.PropertyOwner == (object) section)
          return true;
      }
      return false;
    })))
    {
      string key = validationIssue.Property;
      if (key.Equals("BoreholeDiameter", StringComparison.Ordinal))
        key = "WellboreDiameter";
      this._validationErrors[key] = validationIssue.Message;
    }
    this.BeginInvoke(new Action(this.TriggerValidationErrors), DispatcherPriority.Background);
  }

  protected void TriggerValidationErrors()
  {
    foreach (string key in IPRModelHydraulicFractureViewModel.HydraulicFractureCompletionModelProperties.Keys)
      this.OnPropertyChanged(key);
  }

  private void DataSource_Changed(object sender, Do
