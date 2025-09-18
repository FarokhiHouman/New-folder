   this.SelectedDetailedTubings.Clear();
          this.SelectedDetailedCasings.Clear();
          this.SelectedDetailedTailTubings.Clear();
        }
      }
    }
    ViewModelGridItem<TubingSection> viewModelGridItem2 = this.RetrieveSections(selectedTubingSection.SectionType).FirstOrDefault<ViewModelGridItem<TubingSection>>((Func<ViewModelGridItem<TubingSection>, bool>) (i => i.ViewModel.DataSource.Equals((OdtDomainObjectBase) selectedTubingSection)));
    if (viewModelGridItem2 != null)
      this.RetrieveSelectedSections(selectedTubingSection.SectionType).Add(viewModelGridItem2);
    using (Slb.Production.Engineering.UI.Utilities.NewWaitCursorScope())
      this._viewService.ShowDialog<TubingCasingCatalogSelectorView>((ViewModel) new TubingCasingCatalogSelectorViewModel(selectedTubingSection));
  }

  private bool SelectTubingViewModel(
    ObservableCollection<ViewModelGridItem<TubingSection>> tubingViews,
    ObservableCollection<ViewModelGridItem<TubingSection>> selectedTubingViews)
  {
    ViewModelGridItem<TubingSection> viewModelGridItem = tubingViews.FirstOrDefault<ViewModelGridItem<TubingSection>>((Func<ViewModelGridItem<TubingSection>, bool>) (i => i.ViewModel.DataSource.Equals((OdtDomainObjectBase) this._activeWellItemNotifier.ActiveItem)));
    if (viewModelGridItem == null)
      return false;
    selectedTubingViews.Add(viewModelGridItem);
    this.SelectedTubingViewModel = ((TubingSectionViewModel) viewModelGridItem.AssociatedData).DetailViewModel;
    return true;
  }

  private void WellActiveItemChanged(object sender, EventArgs eventArgs)
  {
    using (this._selectedDetailedTubingsChangedSubscription.Suspend())
    {
      using (this._selectedDetailedTailTubingsChangedSubscription.Suspend())
      {
        using (this._selectedDetailedCasingsChangedSubscription.Suspend())
        {
          this.SelectedDetailedTubings.Clear();
          this.SelectedDetailedCasings.Clear();
          this.SelectedDetailed
