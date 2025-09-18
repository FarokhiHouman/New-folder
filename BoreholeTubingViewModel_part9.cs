idItem<TubingSection>, string>((Func<ViewModelGridItem<TubingSection>, string>) (x => !(x.Data != (TubingSection) null) ? string.Empty : x.Data.Name)));
      TubingSection casingSection = casingWellString.CreateCasingSection(uniqueName, this.WellheadDepth);
      if (flag)
        casingSection.SectionType = SectionType.OpenHole;
      casingSection.InitializeTubularSection();
      TubingSectionViewModel sectionViewModel = this.RegisterContent<TubingSectionViewModel>(new TubingSectionViewModel(casingSection, this));
      sectionViewModel.DetailViewModel = this.RegisterContent<BoreholeTubingDetailViewModel>(new BoreholeTubingDetailViewModel(casingSection));
      nuTransaction.Lock((object) sectionViewModel.DataSource);
      item.ViewModel = (DomainObjectViewModel<TubingSection>) sectionViewModel;
      nuTransaction.Commit();
      this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) casingWellString.Sections, new NotifyCollectionChangedEventHandler(this.WellStringSectionsCollection_ModelCollectionChanged)));
      this._aggregateSubscription.AddDomainObjectChanged<TubingSection>(casingSection);
    }
  }

  private void InitializeMainTubingSection(ViewModelGridItem<TubingSection> item)
  {
    this.InitializeTubingSection(item, false);
  }

  private void InitializeTailTubingSection(ViewModelGridItem<TubingSection> item)
  {
    this.InitializeTubingSection(item, true);
  }

  private void InitializeTubingSection(ViewModelGridItem<TubingSection> item, bool isTailPipe)
  {
    WellString casingWellString = this.DataSource.CasingWellString;
    WellString tubingWellString = this.DataSource.TubingWellString;
    if (casingWellString == (WellString) null || tubingWellString == (WellString) null)
      throw new ArgumentException("Casing string or tubing string is null!");
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      this.UnregisterSubscription
