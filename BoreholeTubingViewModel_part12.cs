)
        {
          this._aggregateSubscription.AddDomainObjectChanged<TubingSection>(addedSection);
          GridItemCollection<ViewModelGridItem<TubingSection>> source = addedSection.IsTailPipe ? this.TailTubingSections : this.TubingSections;
          if (source.All<ViewModelGridItem<TubingSection>>((Func<ViewModelGridItem<TubingSection>, bool>) (x => x.Data.DurableId != addedSection.DurableId)))
            source.Add(new ViewModelGridItem<TubingSection>((DomainObjectViewModel<TubingSection>) sectionViewModel));
        }
        else
        {
          this._aggregateSubscription.AddDomainObjectChanged<TubingSection>(addedSection);
          this.CasingSections.Add(new ViewModelGridItem<TubingSection>((DomainObjectViewModel<TubingSection>) sectionViewModel));
          if (this.OpenHole == null && sectionViewModel.SelectedSectionType == SectionType.OpenHole)
            this.OpenHole = sectionViewModel;
          if (this.Liner == null && sectionViewModel.SelectedSectionType == SectionType.Liner)
            this.Liner = sectionViewModel;
        }
        this._aggregateSubscription.AddDomainObjectChanged<TubingSection>(addedSection);
      }
    }
    if (e.Action != NotifyCollectionChangedAction.Remove || e.OldItems == null || e.OldItems.Count <= 0)
      return;
    foreach (TubingSection tubingSection in e.OldItems.OfType<TubingSection>())
    {
      TubingSection deletedSection = tubingSection;
      GridItemCollection<ViewModelGridItem<TubingSection>> source = deletedSection.IsTailPipe ? this.TailTubingSections : this.TubingSections;
      if (source.Any<ViewModelGridItem<TubingSection>>((Func<ViewModelGridItem<TubingSection>, bool>) (x => x.Data.DurableId == deletedSection.DurableId)))
      {
        ViewModelGridItem<TubingSection> viewModelGridItem = source.First<ViewModelGridItem<TubingSection>>((Func<ViewModelGridItem<TubingSection>, bool>) (x => x.Data.DurableId == deletedSection.DurableId));
        this.Unregiste
