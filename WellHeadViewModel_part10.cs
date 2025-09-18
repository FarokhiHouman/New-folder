A_NodalPointInTubing)
          this.SelectedIndex = 4;
        this.NavigateFromValidationIssue(issue);
        this.OverrideSelectedItem(issue);
      }
    }
    else
      this.WellboreSchematicViewModel.HandleWellboreCommand(e.Data.ToString(), e.Source);
  }

  private void NavigateFromValidationIssue(ValidationIssue issue)
  {
    using (IEnumerator<IWellViewNavigateFromValidation> enumerator = this._navigators.Values.Where<IWellViewNavigateFromValidation>((Func<IWellViewNavigateFromValidation, bool>) (n => !n.IsDisposed)).GetEnumerator())
    {
      do
        ;
      while (enumerator.MoveNext() && !enumerator.Current.NavigateTo(issue));
    }
  }

  private void OverrideSelectedItem(ValidationIssue validationIssue)
  {
    if (!validationIssue.Path.Contains(CoreStrings.WellheadAmbientTemperature))
      return;
    this.SelectedIndex = 2;
  }

  public ObservableCollection<WellType> WellTypes { get; set; }

  public static ObservableCollection<TubingConfigType> TubingTypes { get; }

  public bool IsBuiltInTemplate { get; }

  public bool IsAdvancedWellWarningVisible
  {
    get => this.DataSource.IsAdvancedType() && AdvancedWellLicenseChecker.IsValidDate();
  }

  public string AdvancedWellWarning => AdvancedWellLicenseChecker.GetAdvancedWellWarning();

  public BoreholeViewModel BoreholeViewModel
  {
    get
    {
      return this._boreholeViewModel ?? (this._boreholeViewModel = this.RegisterContent<BoreholeViewModel>(new BoreholeViewModel(this.DataSource.DefaultBorehole, (ITabbedActiveItemNotifier) this, (IWellViewNavigationService) this)));
    }
  }

  public WellboreSchematicViewModel WellboreSchematicViewModel { get; }

  public BoreholeDownholeEquipmentViewModel DownholeEquipmentViewModel
  {
    get
    {
      if (this._boreholeDownholeEquipmentViewModel != null)
        return this._boreholeDownholeEquipmentViewModel;
      this._boreholeDownholeEquipmentViewModel = this.RegisterContent<Bor
