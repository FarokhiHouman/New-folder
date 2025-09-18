== (CompletionModel) null || !this.DataSource.UseTestData)
      return;
    this.DataSource.CompModel.ReCalculate();
  }

  private bool CheckItemStatusWithIssues(ModelItem item, ICollection<ValidationIssue> issues)
  {
    WellHead wellhead = item as WellHead;
    if (wellhead != (WellHead) null)
      return this.CheckWellheadStatusWithIssues(wellhead, issues);
    Fluid fluid = item as Fluid;
    return fluid != (Fluid) null && this.CheckFluidStatusWithIssues(fluid, issues);
  }

  private bool CheckFluidStatusWithIssues(Fluid fluid, ICollection<ValidationIssue> issues)
  {
    return !(fluid == (Fluid) null) && this.validationService != null && !issues.Where<ValidationIssue>((Func<ValidationIssue, bool>) (x => x.IsAffected((IValidation) fluid))).ToList<ValidationIssue>().Any<ValidationIssue>();
  }

  private bool CheckWellheadStatusWithIssues(WellHead wellhead, ICollection<ValidationIssue> issues)
  {
    if (wellhead == (WellHead) null || (FluidLink) this.DataSource == (FluidLink) null || this.DataSource.CompModel == (CompletionModel) null || this.validationService == null || issues.Where<ValidationIssue>((Func<ValidationIssue, bool>) (x => x.IsAffected((IValidation) this.DataSource))).ToList<ValidationIssue>().Any<ValidationIssue>())
      return false;
    if (this.DataSource.UseConingData && this.DataSource.ConingData != null)
    {
      List<ModelItem> list = ((IEnumerable<ModelItem>) this.DataSource.ConingData).ToList<ModelItem>();
      if (list.Any<ModelItem>() && !this.GridDataValid((IEnumerable<ModelItem>) list, (IEnumerable<ValidationIssue>) issues))
        return false;
    }
    if (this.DataSource.UseTestData && this.DataSource.TestData != null && this.IPRModelViewModel.CanUseTestDataForIPRCalulation)
    {
      List<ModelItem> list = ((IEnumerable<ModelItem>) this.DataSource.TestData).ToList<ModelItem>();
      if (list.Any<ModelItem>() && !this.GridDataValid((IEnumerable<ModelItem>) list, (IEnumerable<Validati
