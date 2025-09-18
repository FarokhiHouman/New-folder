s((object) tubingWellString.Sections);
      nuTransaction.Lock((object) this.DataSource, (object) tubingWellString);
      string uniqueName = Slb.Production.Engineering.Common.Utilities.GetUniqueName(isTailPipe ? CoreResourceStrings.ModelItemType_TailTubingSection_SN : CoreStrings.Tubing, tubingWellString.GetSections().Select<TubingSection, string>((Func<TubingSection, string>) (x => x.Name)));
      double topMeasuredDepth = this.WellheadDepth;
      if (this.TubingSections.ElementAtOrDefault<ViewModelGridItem<TubingSection>>(this.TubingSections.Count - 1)?.ViewModel is TubingSectionViewModel viewModel)
        topMeasuredDepth = viewModel.BottomMD;
      TubingSection tubingSection = tubingWellString.CreateTubingSection(uniqueName, topMeasuredDepth, isTailPipe);
      tubingSection.InitializeTubularSection();
      TubingSectionViewModel sectionViewModel = this.RegisterContent<TubingSectionViewModel>(new TubingSectionViewModel(tubingSection, this));
      sectionViewModel.DetailViewModel = this.RegisterContent<BoreholeTubingDetailViewModel>(new BoreholeTubingDetailViewModel(tubingSection));
      nuTransaction.Lock((object) tubingSection);
      item.ViewModel = (DomainObjectViewModel<TubingSection>) sectionViewModel;
      nuTransaction.Commit();
      this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) tubingWellString.Sections, new NotifyCollectionChangedEventHandler(this.WellStringSectionsCollection_ModelCollectionChanged)));
      this._aggregateSubscription.AddDomainObjectChanged<TubingSection>(tubingSection);
    }
  }

  private GridItemCollection<ViewModelGridItem<TubingSection>> ClearSections(
    SectionType retrieveType)
  {
    GridItemCollection<ViewModelGridItem<TubingSection>> contentCollection = this.RetrieveSections(retrieveType);
    foreach (ViewModelGridItem<TubingSection> viewModelGridItem in (Collection<ViewModelGridItem<TubingSection>>) contentCollection)
    {
   
