LinkViewModel) this));
          break;
        case IPRModelType.ForchheimerEquation:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelForchheimerViewModel>(new IPRModelForchheimerViewModel(this.DataSource.GetOrCreateCompletionModel<ForchheimerCompletionModel>((Func<ForchheimerCompletionModel, bool>) null, (Action<ForchheimerCompletionModel>) null), (IFluidLinkViewModel) this));
          break;
        case IPRModelType.HydraulicFracture:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelHydraulicFractureViewModel>(new IPRModelHydraulicFractureViewModel(this.DataSource.GetOrCreateCompletionModel<HydraulicFractureCompletionModel>((Func<HydraulicFractureCompletionModel, bool>) null, (Action<HydraulicFractureCompletionModel>) null), (IFluidLinkViewModel) this));
          break;
        case IPRModelType.JoshiSS:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelJoshiSSViewModel>(new IPRModelJoshiSSViewModel(this.DataSource.GetOrCreateDistributedCompletion(DistributedCompletionType.SSJoshi), (IFluidLinkViewModel) this));
          break;
        case IPRModelType.DistributedPIVertical:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelDistributedPIVerticalViewModel>(new IPRModelDistributedPIVerticalViewModel(this.DataSource.GetOrCreateDistributedCompletion(DistributedCompletionType.VerticalPI), (IFluidLinkViewModel) this));
          break;
        case IPRModelType.DistributedPIHorizontal:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelDistributedPIHorizontalViewModel>(new IPRModelDistributedPIHorizontalViewModel(this.DataSource.GetOrCreateDistributedCompletion(DistributedCompletionType.HorizontalPI), (IFluidLinkViewModel) this));
          break;
        case IPRModelType.BabuOdehPSS:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelBab
