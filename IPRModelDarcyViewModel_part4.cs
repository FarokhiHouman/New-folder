ogelWaterCutCorrection" || property == "UsePseudoPressureMethod" || property == "ReservoirThickness" || property == "WellboreDiameter" || property == "ReservoirPermeability" || property == "UseRelativePermeability" || property == "UseDrainageRadius" || property == "DrainageRadius" || property == "ShapeFactor" || property == "ReservoirArea" || property == "IsTransient" || property == "Time" || property == "Porosity" || property == "Compressibility" || property == "RateDependentGasSkin" || property == "RateDependentLiquidSkin" || property == "MechanicalSkin";
  }

  protected override string GetPropertyError(string propertyName)
  {
    string propertyError = this._validationErrors.ContainsKey(propertyName) ? this._validationErrors[propertyName] : base.GetPropertyError(propertyName);
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
    List<ValidationIssue> list = e.Issues.Where<ValidationIssue>((Func<ValidationIssue, bool>) (x => (object) x.PropertyOwner == (object) this.DataSource)).ToList<ValidationIssue>();
    foreach (ValidationIssue validationIssue in this.AddBoreholeDiameterToValidationIssues(e, list))
    {
      string key = validationIssue.Property;
      if (key == IPRModelDarcyViewModel.boreHolePropertyName)
        key = Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<DarcyCompletionModel, double>((Expression<Func<DarcyCompletionModel, double>>) (d => d.WellboreDiameter));
      this._validationErrors[key] = validationIssue.Message;
    }
    this.BeginInvoke(new Action(this.TriggerValidationErrors), DispatcherPriority.Background);
  }

  protected void TriggerValidationErrors()
  {
    forea
