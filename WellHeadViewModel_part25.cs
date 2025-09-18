 elements2.Add((object) buttonDefinition10);
    return tabDefinition2;
  }

  private bool GetDisplaySettings(string key)
  {
    Slb.Production.Engineering.Model.StandardDomain.Model currentWorkspaceModel = DataHelper.GetCurrentWorkspaceModel();
    return !(currentWorkspaceModel != (Slb.Production.Engineering.Model.StandardDomain.Model) null) || currentWorkspaceModel.GetBoolOption(key, true);
  }

  private void SetWellTypes()
  {
    this.WellTypes = this.DataSource.ShouldDisableConvertToAdvanceWell() ? this._twoOptionsWellTypes : this._threeOptionsWellTypes;
    this.OnPropertyChanged("WellTypes");
  }

  private void InsertTabDefinition_ElementClicked(object sender, DataEventArgs<object> e)
  {
    if (!(e.Data is ICreateNetworkItem data) || this.BranchViewModel == null || this.BranchViewModel.InsertElementCommand == null)
      return;
    this.BranchViewModel.InsertElementCommand.Execute((object) data);
  }

  private void DataSource_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    if (e.PropertyNames.Contains<string>("WellheadDepth"))
      this.OnPropertyChanged("WellheadDepth");
    if (e.PropertyNames.Contains<string>("Name"))
      this.OnPropertyChanged("Name");
    if (e.PropertyNames.Contains<string>("IsActive"))
      this.OnPropertyChanged("IsActive");
    if (e.PropertyNames.Contains<string>("WellType"))
    {
      this.OnPropertyChanged("WellstreamOutletHeader");
      this.OnPropertyChanged("WellType");
      this.OnPropertyChanged("WellMode");
      this.OnPropertyChanged("IsAdvancedWellWarningVisible");
      this.SetWellTypes();
    }
    if (!e.PropertyNames.Contains<string>("CheckValveSetting"))
      return;
    this.OnPropertyChanged("CheckValveSetting");
  }

  private void InsertElementDragged(object sender, DataEventArgs<object> e)
  {
    DependencyObject dependencyObject = sender as DependencyObject;
    WellboreItemFactory data = e.Data as WellboreItemFactory;
    if (dep
