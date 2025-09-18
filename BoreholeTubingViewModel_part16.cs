ModelGridItem?.Data;
      if (viewModelGridItem == null || !(viewModelGridItem.Data != (TubingSection) null))
        return;
      this.SelectedTubingViewModel = ((TubingSectionViewModel) viewModelGridItem.AssociatedData).DetailViewModel;
    }
  }

  private void SelectedDetailedTailTubingsChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    using (this._selectedDetailedCasingsChangedSubscription.Suspend())
      this.SelectedDetailedCasings.Clear();
    using (this._selectedDetailedTubingsChangedSubscription.Suspend())
      this.SelectedDetailedTubings.Clear();
    ViewModelGridItem<TubingSection> viewModelGridItem = this.SelectedDetailedTailTubings.LastOrDefault<ViewModelGridItem<TubingSection>>();
    using (this._wellActiveItemSubscription.Suspend())
    {
      this._activeWellItemNotifier.ActiveItem = (ModelItem) viewModelGridItem?.Data;
      if (viewModelGridItem == null || !(viewModelGridItem.Data != (TubingSection) null) || !viewModelGridItem.Data.IsGood)
        return;
      this.SelectedTubingViewModel = ((TubingSectionViewModel) viewModelGridItem.AssociatedData).DetailViewModel;
    }
  }

  public bool NavigateTo(ValidationIssue issue)
  {
    if (issue.ExtraInfo is SectionType extraInfo)
    {
      this.SetSelectedIndex(extraInfo);
      return true;
    }
    TubingSection propertyOwner = issue.PropertyOwner as TubingSection;
    if ((object) propertyOwner == null)
      return false;
    this.SetSelectedIndex(propertyOwner.SectionType);
    return true;
  }

  private void SetSelectedIndex(SectionType sectionType)
  {
    if (sectionType != SectionType.Tubing && sectionType != SectionType.TailPipe)
      return;
    this.SelectedIndex = sectionType == SectionType.TailPipe ? 1 : 0;
  }

  [SpecialName]
  bool IWellViewNavigateFromValidation.get_IsDisposed() => this.IsDisposed;
}

