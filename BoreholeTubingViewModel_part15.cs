TailTubings.Clear();
          if (this.SelectTubingViewModel((ObservableCollection<ViewModelGridItem<TubingSection>>) this.TubingSections, this.SelectedDetailedTubings) || this.SelectTubingViewModel((ObservableCollection<ViewModelGridItem<TubingSection>>) this.TailTubingSections, this.SelectedDetailedTailTubings))
            return;
          this.SelectTubingViewModel((ObservableCollection<ViewModelGridItem<TubingSection>>) this.CasingSections, this.SelectedDetailedCasings);
        }
      }
    }
  }

  private void SelectedDetailedCasingsChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    using (this._selectedDetailedTubingsChangedSubscription.Suspend())
      this.SelectedDetailedTubings.Clear();
    using (this._selectedDetailedTailTubingsChangedSubscription.Suspend())
      this.SelectedDetailedTailTubings.Clear();
    ViewModelGridItem<TubingSection> viewModelGridItem = this.SelectedDetailedCasings.LastOrDefault<ViewModelGridItem<TubingSection>>();
    using (this._wellActiveItemSubscription.Suspend())
    {
      this._activeWellItemNotifier.ActiveItem = (ModelItem) viewModelGridItem?.Data;
      if (viewModelGridItem == null || !(viewModelGridItem.Data != (TubingSection) null))
        return;
      this.SelectedTubingViewModel = ((TubingSectionViewModel) viewModelGridItem.AssociatedData).DetailViewModel;
    }
  }

  private void SelectedDetailedTubingsChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    using (this._selectedDetailedCasingsChangedSubscription.Suspend())
      this.SelectedDetailedCasings.Clear();
    using (this._selectedDetailedTailTubingsChangedSubscription.Suspend())
      this.SelectedDetailedTailTubings.Clear();
    ViewModelGridItem<TubingSection> viewModelGridItem = this.SelectedDetailedTubings.LastOrDefault<ViewModelGridItem<TubingSection>>();
    using (this._wellActiveItemSubscription.Suspend())
    {
      this._activeWellItemNotifier.ActiveItem = (ModelItem) view
