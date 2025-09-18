ull && this.DataSource.Name != null && !this.DataSource.Name.Equals(name);
        this.SetChildValue((object) this.DataSource, "Name", (DomainObjectViewModel<Perforation>.SetMethod) (() => this.DataSource.Name = name));
        this.OnPropertyChanged(nameof (ItemName));
        this.QueueValidationIfRequired(needsValidation);
      }
    }
  }

  private void QueueValidationIfRequired(bool needsValidation)
  {
    if (!needsValidation || !this.DataSource.WellString.Borehole.WellHead.Perforations.Any<Perforation>((Func<Perforation, bool>) (p => p.IsDistributedCompletion())))
      return;
    this.DataSource.WellString.Borehole.RefreshFlowPath();
    this.validationService.QueueInToBeValidatedItems((IValidation) this.DataSource);
  }

  public IEnumerable<FluidEntryType> FluidEntryTypeOptions
  {
    get
    {
      if (PerforationViewModel._fluidEntryOptions == null)
        PerforationViewModel._fluidEntryOptions = Enum.GetValues(typeof (FluidEntryType)).Cast<FluidEntryType>();
      if (this.DataSource.GeometryProfileType != GeometryProfileType.Vertical)
        return PerforationViewModel._fluidEntryOptions;
      return PerforationViewModel._fluidEntryOptions.Except<FluidEntryType>((IEnumerable<FluidEntryType>) new FluidEntryType[1]
      {
        FluidEntryType.Distributed
      });
    }
  }

  public IEnumerable<GeometryProfileType> GeometryProfileTypeOptions
  {
    get
    {
      return (IEnumerable<GeometryProfileType>) PerforationViewModel._fluidEntryGeometryProfileMappings[this.DataSource.FluidEntryType];
    }
  }

  public IEnumerable<IPRModelType> IPRModelTypeOptions
  {
    get
    {
      return (IEnumerable<IPRModelType>) PerforationViewModel._IPRModelTypeModeMappings[this._completionFluidEntryGeometryProfileMode];
    }
  }

  public override FluidLinkType Type
  {
    get => !this.DataSource.IsOpenHole() ? FluidLinkType.Perforation : FluidLinkType.OpenHole;
  }

  public override FluidEntryTy
