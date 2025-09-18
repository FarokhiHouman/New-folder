 get
    {
      return Constants.DefaultAnnulusMaterialThermalConductivities[this.DataSource.AnnulusMaterialType];
    }
  }

  public string ExpanderHeaderTitle
  {
    get
    {
      return !this.DataSource.IsTailPipe ? this.DataSource.SectionType.ToString() : CoreResourceStrings.TailPipeLabel;
    }
  }

  public bool ShowBoreholeDiameter => this.DataSource.IsCasing;

  public ObservableCollection<string> GradeList
  {
    get
    {
      return this.DataSource.IsCasingOrLiner || this.IsOpenHole || !this.DataSource.IsTubingOrTailPipe ? this._casingGrades : this._tubingGrades;
    }
  }

  public string GradeDisplay
  {
    get
    {
      string str = this.GetValue("Grade") as string;
      return !string.IsNullOrWhiteSpace(str) ? str : this._dummyEmptyString;
    }
    set => this.SetValue("Grade", (object) value);
  }

  public ObservableCollection<AnnulusMaterialType> AnnulusMaterialTypes { get; }

  public bool ShowCement => this.DataSource.IsCasingOrLiner;

  public bool ShowAnnulusMaterial
  {
    get
    {
      if (this.DataSource.IsTubingOrTailPipe)
        return true;
      if (!this.DataSource.IsCasingOrLiner)
        return false;
      return this.DataSource.CementTop.IsNaN() || this.DataSource.CementTop > this.DataSource.TopMeasuredDepth;
    }
  }

  public string AnnulusMaterialTypeString
  {
    get
    {
      return !this.ShowCement ? CoreStrings.AnnulusMaterialType : CoreStrings.AnnulusMaterialTypeAboveCement;
    }
  }

  public bool IsOpenHole => this.DataSource.SectionType == SectionType.OpenHole;

  public bool CanShowAnnulusMaterial
  {
    get => this.DataSource.SectionType != SectionType.OpenHole && !this.DataSource.IsTailPipe;
  }

  private void ValidationService_ValidationCompleted(object sender, ValidateArgs e)
  {
    this._propertyErrors.Clear();
    if (e.Issues == null)
      return;
    foreach (ValidationIssue validationIssue in e.Issues.Where<ValidationI
