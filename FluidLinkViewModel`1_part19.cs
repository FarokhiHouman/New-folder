onIssue>) issues))
        return false;
    }
    if (issues.Where<ValidationIssue>((Func<ValidationIssue, bool>) (x => x.IsAffected((IValidation) this.DataSource.CompModel))).ToList<ValidationIssue>().Any<ValidationIssue>())
      return false;
    DarcyCompletionModel compModel = this.DataSource.CompModel as DarcyCompletionModel;
    if (compModel != (DarcyCompletionModel) null && !compModel.IsTransient && compModel.UseRelativePermeability && compModel.RelativePermeabilityData != null && compModel.RelativePermeabilityData.Count > 0)
    {
      List<ModelItem> list = ((IEnumerable<ModelItem>) compModel.RelativePermeabilityData).ToList<ModelItem>();
      if (list.Any<ModelItem>() && !this.GridDataValid((IEnumerable<ModelItem>) list, (IEnumerable<ValidationIssue>) issues))
        return false;
    }
    return true;
  }

  private bool GridDataValid(IEnumerable<ModelItem> collection, IEnumerable<ValidationIssue> issues)
  {
    return collection.All<ModelItem>((Func<ModelItem, bool>) (x => !issues.Any<ValidationIssue>((Func<ValidationIssue, bool>) (y => y.IsAffected((IValidation) x)))));
  }

  private void UpdateIPRValidationStatusDictionary()
  {
    WellHead wellHead = !((FluidLink) this.DataSource != (FluidLink) null) || !(this.DataSource.WellString != (WellString) null) || !(this.DataSource.WellString.Borehole != (Borehole) null) ? (WellHead) null : this.DataSource.WellString.Borehole.WellHead;
    if (wellHead != (WellHead) null)
      this._validationStatusDictionary.TryAdd((ModelItem) wellHead, false);
    this.ReflectCurrentFluidForValidation();
  }

  [SpecialName]
  bool IFluidLinkViewModel.get_IsValid() => this.IsValid;
}

