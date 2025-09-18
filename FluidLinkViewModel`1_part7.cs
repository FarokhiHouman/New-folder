new IPRModelPIViewModel(this.DataSource.GetOrCreateCompletionModel<PIModel>((Func<PIModel, bool>) null, (Action<PIModel>) null), (IFluidLinkViewModel) this));
          break;
        case IPRModelType.VogelEquation:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelVogelViewModel>(new IPRModelVogelViewModel(this.DataSource.GetOrCreateCompletionModel<VogelModel>((Func<VogelModel, bool>) null, (Action<VogelModel>) null), (IFluidLinkViewModel) this));
          break;
        case IPRModelType.FetkovitchEquation:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelFetkovitchViewModel>(new IPRModelFetkovitchViewModel(this.DataSource.GetOrCreateCompletionModel<FetkovitchEquationModel>((Func<FetkovitchEquationModel, bool>) null, (Action<FetkovitchEquationModel>) null), (IFluidLinkViewModel) this));
          break;
        case IPRModelType.JonesEquation:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelJonesViewModel>(new IPRModelJonesViewModel(this.DataSource.GetOrCreateCompletionModel<JonesCompletionModel>((Func<JonesCompletionModel, bool>) null, (Action<JonesCompletionModel>) null), (IFluidLinkViewModel) this));
          break;
        case IPRModelType.BackPressureEquation:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelBackPressureViewModel>(new IPRModelBackPressureViewModel(this.DataSource.GetOrCreateCompletionModel<BackPressureCompletionModel>((Func<BackPressureCompletionModel, bool>) null, (Action<BackPressureCompletionModel>) null), (IFluidLinkViewModel) this));
          break;
        case IPRModelType.DarcyEquation:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelDarcyViewModel>(new IPRModelDarcyViewModel(this.DataSource.GetOrCreateCompletionModel<DarcyCompletionModel>((Func<DarcyCompletionModel, bool>) null, (Action<DarcyCompletionModel>) null), this._model, (IFluid
