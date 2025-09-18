ssue>((Func<ValidationIssue, bool>) (x => (object) x.PropertyOwner == (object) this.DataSource)))
      this._propertyErrors[validationIssue.Property] = validationIssue.Message;
    this.BeginInvoke(new Action(this.TriggerValidationErrors), DispatcherPriority.Background);
  }

  private void TriggerValidationErrors()
  {
    foreach (string property in BoreholeTubingDetailViewModel.TubingSectionProperties.Keys.Concat<string>((IEnumerable<string>) BoreholeTubingDetailViewModel.ViewModelproperties))
      this.OnPropertyChanged(property);
  }

  protected override string GetPropertyError(string propertyName)
  {
    string str = propertyName;
    if (propertyName == "GradeDisplay")
      str = "Grade";
    string propertyError = base.GetPropertyError(str);
    if (this._propertyErrors.ContainsKey(str))
      propertyError = this._propertyErrors[str];
    if (propertyName == "Density")
    {
      this._dummyEmptyString = this._dummyEmptyString == string.Empty ? (string) null : string.Empty;
      this.OnPropertyChanged("GradeDisplay");
    }
    return propertyError;
  }
}

