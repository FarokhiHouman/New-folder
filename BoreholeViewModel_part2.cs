leTubingViewModel
  {
    get
    {
      if (this._boreholeTubingViewModel == null)
        this._boreholeTubingViewModel = this.RegisterContent<BoreholeTubingViewModel>(new BoreholeTubingViewModel(this.DataSource, this._activeWellItemNotifier, this._wellViewNavigationService));
      return this._boreholeTubingViewModel;
    }
  }

  public BoreholeDeviationSurveysViewModel BoreholeDeviationSurveysViewModel
  {
    get
    {
      if (this._boreholeDeviationSurveysViewModel == null)
        this._boreholeDeviationSurveysViewModel = this.RegisterContent<BoreholeDeviationSurveysViewModel>(new BoreholeDeviationSurveysViewModel(this.DataSource.Trajectory, this, this._wellViewNavigationService));
      return this._boreholeDeviationSurveysViewModel;
    }
  }

  public BoreholeHeatTransferViewModel BoreholeHeatTransferViewModel
  {
    get
    {
      if (this._boreholeHeatTransferViewModel == null)
        this._boreholeHeatTransferViewModel = this.RegisterContent<BoreholeHeatTransferViewModel>(new BoreholeHeatTransferViewModel(this.DataSource));
      return this._boreholeHeatTransferViewModel;
    }
  }

  public double WellheadDepth
  {
    get
    {
      return !DataHelper.IsNullObject((IDomainObject) this.DataSource) && !DataHelper.IsNullObject((IDomainObject) this.DataSource.WellHead) ? this.DataSource.WellHead.WellheadDepth : double.NaN;
    }
    set
    {
      if (!DataHelper.IsNullObject((IDomainObject) this.DataSource) && !DataHelper.IsNullObject((IDomainObject) this.DataSource.WellHead) && !value.AlmostEqual(this.WellheadDepth))
      {
        using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
        {
          nuTransaction.Lock((object) this.DataSource, (object) this.DataSource.WellHead);
          this.DataSource.WellHead.WellheadDepth = value;
          nuTransaction.Commit();
        }
        if (this.BoreholeTubingViewModel.TubingSections.Count > 0 && this.BoreholeTubingViewModel.
