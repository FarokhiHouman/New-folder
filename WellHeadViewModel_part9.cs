pmentDroids, primaryEquipmentDroid);
    }
    else
    {
      if (!(e.Key == "topic://WellStatusChanged"))
        return;
      this.BeginInvoke((Action) (() => this._ribbonService?.Update()), DispatcherPriority.ApplicationIdle);
    }
  }

  internal void HandleValidationIssueClicked(ActionEventArgs<string, object, object> e)
  {
    ValidationIssue issue = e.Data as ValidationIssue;
    if (issue != null)
    {
      if (this.IsGasliftIssue(issue))
      {
        ModelItem modelItem = (ModelItem) this.DataSource.DefaultBorehole.WellStrings.SelectMany<WellString, Equipment>((Func<WellString, IEnumerable<Equipment>>) (i => (IEnumerable<Equipment>) i.DownholeEquipment)).OfType<GasLiftInjection>().FirstOrDefault<GasLiftInjection>();
        if ((object) modelItem == null)
          modelItem = issue.PropertyOwner as ModelItem;
        this.ActiveItem = modelItem;
        this.SelectedIndex = 5;
        this.BoreholeArtificialLiftViewModel.GasLiftInjectionListViewModel.NavigateToProperty(issue);
      }
      if (issue.Message == CoreResourceStrings.Validation_Well_Looped_Branches)
      {
        this.SelectedIndex = 7;
      }
      else
      {
        if (issue.Property != null && issue.Property == "AmbientTemperature")
        {
          this.ActiveItem = (ModelItem) this.DataSource.DefaultBorehole;
        }
        else
        {
          this.ActiveItem = issue.PropertyOwner as ModelItem;
          this.SetStreamOutletTabIndex(this.ActiveItem);
        }
        if (issue.Message == CoreResourceStrings.Validation_NA_NoNodalPointInBranch)
          this.SelectedIndex = 7;
        else if (issue.Property != null && issue.Property.Equals("HeatTransferSurveyLessThanTwoPoints"))
          this.BeginInvoke((Action) (() => this.SelectedIndex = WellViewTabHelper.GetSelectedTabIndex((object) issue, this.SelectedIndex)), DispatcherPriority.ApplicationIdle);
        else if (issue.Message == CoreResourceStrings.Validation_N
