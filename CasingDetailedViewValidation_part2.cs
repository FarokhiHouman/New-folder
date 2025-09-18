eStrings.Validation_Tubulars_BiindingGroupNull);
    BoreholeTubingViewModel boreholeTubingViewModel = (BoreholeTubingViewModel) bindingGroup.Items[0];
    if (boreholeTubingViewModel == null)
      return new ValidationResult(false, (object) CoreStrings.Validation_NullViewModel);
    Borehole dataSource = boreholeTubingViewModel.DataSource;
    if (dataSource == (Borehole) null)
      return new ValidationResult(false, (object) CoreStrings.Validation_NullDataSource);
    WellHead wellHead = dataSource.WellHead;
    if (wellHead == (WellHead) null)
      return new ValidationResult(false, (object) CoreStrings.Validation_NullDataSource);
    ICollection<WellString> wellStringCollection = (ICollection<WellString>) null;
    if (wellHead.Boreholes.Count > 0)
    {
      WellStringAccessor.QueryCriteria criteria = new WellStringAccessor.QueryCriteria()
      {
        Borehole = new QueryConstraint<Borehole>((IEnumerable<Borehole>) wellHead.Boreholes)
      };
      wellStringCollection = (ICollection<WellString>) FacadeAccessor.Query<WellString>(wellHead.DataSource, (AbstractQueryCriteria) criteria);
    }
    List<ValidationIssue> list = this.GetValidIssues(wellHead, wellStringCollection).ToList<ValidationIssue>();
    if (!list.Any<ValidationIssue>())
      return new ValidationResult(true, (object) null);
    string errorContent = string.Join(Environment.NewLine, list.Select<ValidationIssue, string>((Func<ValidationIssue, string>) (s => s.Message)));
    return errorContent.Equals(string.Empty) ? new ValidationResult(true, (object) null) : new ValidationResult(false, (object) errorContent);
  }
}

