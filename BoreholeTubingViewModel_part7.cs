>((Func<WellString, int>) (ws => ws.Id)).ToList<WellString>())
    {
      foreach (TubingSection section in wellString.GetSections())
      {
        TubingSectionViewModel sectionViewModel = this.RegisterContent<TubingSectionViewModel>(new TubingSectionViewModel(section, this));
        sectionViewModel.DetailViewModel = this.RegisterContent<BoreholeTubingDetailViewModel>(new BoreholeTubingDetailViewModel(section));
        this._aggregateSubscription.AddDomainObjectChanged<TubingSection>(section);
        this.CasingSections.Add(new ViewModelGridItem<TubingSection>((DomainObjectViewModel<TubingSection>) sectionViewModel));
        if (this.OpenHole == null && sectionViewModel.SelectedSectionType == SectionType.OpenHole)
          this.OpenHole = sectionViewModel;
        if (this.Liner == null && sectionViewModel.SelectedSectionType == SectionType.Liner)
          this.Liner = sectionViewModel;
      }
    }
  }

  private GridItemCollection<ViewModelGridItem<TubingSection>> RetrieveSections(
    SectionType retrieveType)
  {
    switch (retrieveType)
    {
      case SectionType.Casing:
      case SectionType.Liner:
      case SectionType.OpenHole:
        return this.CasingSections;
      case SectionType.Tubing:
        return this.TubingSections;
      case SectionType.TailPipe:
        return this.TailTubingSections;
      default:
        throw new ArgumentOutOfRangeException(nameof (retrieveType), (object) retrieveType, (string) null);
    }
  }

  private ObservableCollection<ViewModelGridItem<TubingSection>> RetrieveSelectedSections(
    SectionType retrieveType)
  {
    switch (retrieveType)
    {
      case SectionType.Casing:
      case SectionType.Liner:
      case SectionType.OpenHole:
        return this.SelectedDetailedCasings;
      case SectionType.Tubing:
        return this.SelectedDetailedTubings;
      case SectionType.TailPipe:
        return this.SelectedDetailedTailTubings;
      default:
  
