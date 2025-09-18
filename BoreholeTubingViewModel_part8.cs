      throw new ArgumentOutOfRangeException(nameof (retrieveType), (object) retrieveType, (string) null);
    }
  }

  private void PopulateTubingSections(SectionType retrieveType)
  {
    GridItemCollection<ViewModelGridItem<TubingSection>> gridItemCollection = this.ClearSections(retrieveType);
    if (this.DataSource.WellStrings.Count <= 0)
      return;
    WellString tubingWellString = this.DataSource.TubingWellString;
    if (tubingWellString == (WellString) null || DataHelper.IsNullObject((IDomainObject) tubingWellString))
      return;
    foreach (TubingSection tubingSection in tubingWellString.RetrieveSections(retrieveType).ToArray<TubingSection>())
    {
      this._aggregateSubscription.AddDomainObjectChanged<TubingSection>(tubingSection);
      gridItemCollection.Add(new ViewModelGridItem<TubingSection>((DomainObjectViewModel<TubingSection>) this.RegisterContent<TubingSectionViewModel>(new TubingSectionViewModel(tubingSection, this)
      {
        DetailViewModel = this.RegisterContent<BoreholeTubingDetailViewModel>(new BoreholeTubingDetailViewModel(tubingSection))
      })));
    }
  }

  private void InitializeCasingSection(ViewModelGridItem<TubingSection> item)
  {
    bool flag = this.CasingSections.Count > 0 && this.CasingSections[this.CasingSections.Count - 1].Data.SectionType != SectionType.Casing;
    WellString casingWellString = this.DataSource.CasingWellString;
    if (casingWellString == (WellString) null)
      throw new ArgumentException("Casing string is null!");
    this.UnregisterSubscriptions((object) casingWellString.Sections);
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      nuTransaction.Lock((object) this.DataSource);
      nuTransaction.Lock((object) casingWellString);
      string uniqueName = Slb.Production.Engineering.Common.Utilities.GetUniqueName(flag ? CoreStrings.SectionType_OpenHole : CoreStrings.SectionType_Casing, this.CasingSections.Select<ViewModelGr
