   if (viewModelGridItem != null && viewModelGridItem.Data != (TubingSection) null)
        this._aggregateSubscription.RemoveDomainObjectChanged<TubingSection>(viewModelGridItem.Data);
    }
    this.UnregisterContentCollection<ViewModelGridItem<TubingSection>>((IEnumerable<ViewModelGridItem<TubingSection>>) contentCollection);
    contentCollection.Clear();
    return contentCollection;
  }

  private void OnWellHeadChanged(object sender, DomainObjectChangeEventArgs e)
  {
    if (e.PropertyNames.Contains<string>("WellType"))
      this.OnPropertyChanged("IsTubingTabControlVisible");
    if (!e.PropertyNames.Contains<string>("TubingConfig"))
      return;
    this.OnTubingConfigChanged();
  }

  private void OnWellStringChanged(object sender, DomainObjectChangeEventArgs e)
  {
    if (!e.PropertyNames.Contains<string>("Sections"))
      return;
    this.OnPropertyChanged("CanAddTailPipe");
  }

  private void WellStringSectionsCollection_ModelCollectionChanged(
    object sender,
    NotifyCollectionChangedEventArgs e)
  {
    if (e.Action == NotifyCollectionChangedAction.Remove)
    {
      this.OnPropertyChanged("CanAddTailPipe");
      BoreholeTubingDetailViewModel selectedTubingViewModel = this.SelectedTubingViewModel;
      if (selectedTubingViewModel != null && !selectedTubingViewModel.DataSource.IsGood)
        this.SelectedTubingViewModel = (BoreholeTubingDetailViewModel) null;
    }
    if (e.Action == NotifyCollectionChangedAction.Add)
    {
      foreach (TubingSection tubingSection in e.NewItems.OfType<TubingSection>())
      {
        TubingSection addedSection = tubingSection;
        TubingSectionViewModel sectionViewModel = this.RegisterContent<TubingSectionViewModel>(new TubingSectionViewModel(addedSection, this));
        sectionViewModel.DetailViewModel = this.RegisterContent<BoreholeTubingDetailViewModel>(new BoreholeTubingDetailViewModel(addedSection));
        if (addedSection.WellString.IsValidTubing
