eholeDownholeEquipmentViewModel>(new BoreholeDownholeEquipmentViewModel(this.DataSource.Boreholes[0], (ITabbedActiveItemNotifier) this));
      this._refreshViewModels.Add((IWellRefresh) this._boreholeDownholeEquipmentViewModel);
      return this._boreholeDownholeEquipmentViewModel;
    }
  }

  public BoreholeArtificialLiftViewModel BoreholeArtificialLiftViewModel
  {
    get
    {
      if (this._boreholeArtificialLiftViewModel != null)
        return this._boreholeArtificialLiftViewModel;
      this._boreholeArtificialLiftViewModel = this.RegisterContent<BoreholeArtificialLiftViewModel>(new BoreholeArtificialLiftViewModel(this.DataSource.Boreholes[0], (ITabbedActiveItemNotifier) this, (IWellViewNavigationService) this));
      return this._boreholeArtificialLiftViewModel;
    }
  }

  public BoreholeCompletionsViewModel BoreholeCompletionSystemViewModel
  {
    get
    {
      if (this._boreholeCompletionsViewModel != null)
        return this._boreholeCompletionsViewModel;
      this._boreholeCompletionsViewModel = this.RegisterContent<BoreholeCompletionsViewModel>(new BoreholeCompletionsViewModel(this.DataSource.Boreholes[0], (ITabbedActiveItemNotifier) this, (IWellViewNavigationService) this));
      return this._boreholeCompletionsViewModel;
    }
  }

  public LogicalNetworkViewModel BranchViewModel { get; }

  public SourceViewModel WellStreamOutletViewModel { get; }

  public AdvancedOutletViewModel CasingOutletView { get; }

  public AdvancedOutletViewModel TubingOutletView { get; }

  public string WellstreamOutletHeader
  {
    get
    {
      if (this.DataSource == (Slb.Production.Engineering.Model.StandardDomain.WellHead) null)
        return CoreStrings.Header_WellstreamOutletBoundaryConditions;
      switch (this.DataSource.WellType)
      {
        case WellType.Production:
          return CoreStrings.Header_WellstreamOutletBoundaryConditions;
        case WellType.Injection:
          return CoreStr
