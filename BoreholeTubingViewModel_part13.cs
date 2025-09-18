rContent<DomainObjectViewModel<TubingSection>>(viewModelGridItem.ViewModel);
        source.Remove(viewModelGridItem);
      }
      else if (this.CasingSections.Any<ViewModelGridItem<TubingSection>>((Func<ViewModelGridItem<TubingSection>, bool>) (x => x.Data.DurableId == deletedSection.DurableId)))
      {
        ViewModelGridItem<TubingSection> viewModelGridItem = this.CasingSections.First<ViewModelGridItem<TubingSection>>((Func<ViewModelGridItem<TubingSection>, bool>) (x => x.Data.DurableId == deletedSection.DurableId));
        this.UnregisterContent<DomainObjectViewModel<TubingSection>>(viewModelGridItem.ViewModel);
        this.CasingSections.Remove(viewModelGridItem);
      }
      this._aggregateSubscription.RemoveDomainObjectChanged<TubingSection>(deletedSection);
    }
  }

  private void TubingSectionChanged(object sender, AggregateEventArgs aggregateEventArgs)
  {
    bool flag = false;
    foreach (DomainObjectChangeEventArgs objectChangeEventArgs in aggregateEventArgs.EventArgs.OfType<DomainObjectChangeEventArgs>())
    {
      foreach (string propertyName in objectChangeEventArgs.PropertyNames)
      {
        this.OnPropertyChanged(propertyName);
        if (propertyName == "TopMeasuredDepth" || propertyName == "Length")
          flag = true;
      }
    }
    if (!flag)
      return;
    this.OnPropertyChanged("CanAddTailPipe");
  }

  private void LaunchTubingCasingCatalog(object parameter)
  {
    if (parameter is ViewModelGridItem<TubingSection> viewModelGridItem1)
      parameter = (object) viewModelGridItem1.Data;
    TubingSection selectedTubingSection = parameter as TubingSection;
    if (selectedTubingSection == (TubingSection) null)
      return;
    using (this._selectedDetailedTubingsChangedSubscription.Suspend())
    {
      using (this._selectedDetailedTailTubingsChangedSubscription.Suspend())
      {
        using (this._selectedDetailedCasingsChangedSubscription.Suspend())
        {
       
