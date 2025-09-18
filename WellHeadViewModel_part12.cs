ings.Header_WellstreaminletBoundaryConditions;
        case WellType.Advanced:
          return CoreStrings.Header_WellstreamInletOutletBoundaryConditions;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }

  public BoreholeTubingViewModel BoreholeTubingViewModel
  {
    get
    {
      return this.BoreholeViewModel != null ? this.BoreholeViewModel.BoreholeTubingViewModel : (BoreholeTubingViewModel) null;
    }
  }

  public BoreholeDeviationSurveysViewModel BoreholeDeviationSurveysViewModel
  {
    get
    {
      return this.BoreholeViewModel != null ? this.BoreholeViewModel.BoreholeDeviationSurveysViewModel : (BoreholeDeviationSurveysViewModel) null;
    }
  }

  public BoreholeHeatTransferViewModel BoreholeHeatTransferViewModel
  {
    get
    {
      return this.BoreholeViewModel != null ? this.BoreholeViewModel.BoreholeHeatTransferViewModel : (BoreholeHeatTransferViewModel) null;
    }
  }

  public WellType WellMode
  {
    get => this.DataSource.WellType;
    set
    {
      if (this.DataSource == (Slb.Production.Engineering.Model.StandardDomain.WellHead) null || value == this.WellMode)
        return;
      IWellTypeChangeService service = ServiceDirectory.GetService<IWellTypeChangeService>();
      if (service != null && !service.ProceedWithWellTypeChange(this.DataSource, value))
        return;
      TransactionHelper.InsideTransaction<Slb.Production.Engineering.Model.StandardDomain.WellHead>(this.DataSource, (Action<INuTransaction>) (transaction => this.DataSource.WellType = value));
      this.DataSource.RefreshFlowPath();
    }
  }

  public double WellheadDepth
  {
    get => this.DataSource.WellheadDepth;
    set
    {
      if (!(this.DataSource != (Slb.Production.Engineering.Model.StandardDomain.WellHead) null) || this.WellheadDepth.AlmostEqual(value))
        return;
      this.SetValue(nameof (WellheadDepth), (object) value);
      this.OnPropertyChanged(n
