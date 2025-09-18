urce.WellHead.WellType == WellType.Advanced;

  public void InitializeSections()
  {
    this.PopulateCasingSections();
    this.PopulateTubingSections(SectionType.Tubing);
    this.PopulateTubingSections(SectionType.TailPipe);
  }

  private void OnTubingConfigChanged()
  {
  }

  private static bool CanDeleteSelectedItems(object parameter)
  {
    if (!(parameter is IList source1))
      return false;
    IEnumerable<ViewModelGridItem<TubingSection>> source2 = source1.OfType<ViewModelGridItem<TubingSection>>();
    bool flag = source2.Any<ViewModelGridItem<TubingSection>>();
    return flag && source2.First<ViewModelGridItem<TubingSection>>().Data.IsCasing ? source2.First<ViewModelGridItem<TubingSection>>().Data.WellString.Sections.Count - source2.Count<ViewModelGridItem<TubingSection>>() > 0 : flag;
  }

  private void DeleteSelectedItems(object parameter)
  {
    if (!BoreholeTubingViewModel.CanDeleteSelectedItems(parameter))
      return;
    List<ViewModelGridItem<TubingSection>> list = ((IEnumerable) parameter).OfType<ViewModelGridItem<TubingSection>>().ToList<ViewModelGridItem<TubingSection>>();
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      foreach (TubingSection tubingSection in list.Select<ViewModelGridItem<TubingSection>, TubingSection>((Func<ViewModelGridItem<TubingSection>, TubingSection>) (x => x.Data)).Where<TubingSection>((Func<TubingSection, bool>) (x => x != (TubingSection) null)))
      {
        nuTransaction.Lock((object) tubingSection);
        TubingSectionAccessor.GetFacadeAccessor(this._domainObjectHost).Delete(tubingSection);
      }
      nuTransaction.Commit();
    }
    this.OnPropertyChanged("TubingSections");
  }

  private void PopulateCasingSections()
  {
    this.ClearSections(SectionType.Casing);
    foreach (WellString wellString in this.DataSource.WellStrings.Where<WellString>((Func<WellString, bool>) (x => !x.IsValidTubing)).OrderBy<WellString, int
