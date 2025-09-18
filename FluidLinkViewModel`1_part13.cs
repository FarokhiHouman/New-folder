 object sender,
    NotifyCollectionChangedEventArgs e)
  {
    this.UpdateListeners();
    this.OnPropertyChanged((string) null);
  }

  private void FluidLinkViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
  {
    if (!(e.PropertyName == "CompletionDeviationCalculated"))
      return;
    this._completionDeviationCalculatedNeedsUpdate = true;
  }

  private void AssociatedZone_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    bool flag = false;
    foreach (string propertyName in e.PropertyNames)
    {
      switch (propertyName)
      {
        case "Pressure":
          flag = true;
          continue;
        case "Temperature":
          flag = true;
          continue;
        case "AssociatedFluid":
        case "AssociatedBlackOilFluid":
        case "AssociatedCompositionalFluid":
          flag = true;
          this.OnPropertyChanged("AssociatedZone");
          continue;
        default:
          continue;
      }
    }
    if (!flag)
      return;
    this.OnPropertyChanged((string) null);
  }

  private void TestData_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    if (e.Action != NotifyCollectionChangedAction.Remove || e.OldItems == null)
      return;
    foreach (CompletionTestPoint completionTestPoint in e.OldItems.OfType<CompletionTestPoint>())
    {
      CompletionTestPoint testPoint = completionTestPoint;
      ViewModelGridItem<CompletionTestPoint> viewModelGridItem = this.TestPoints.FirstOrDefault<ViewModelGridItem<CompletionTestPoint>>((Func<ViewModelGridItem<CompletionTestPoint>, bool>) (x => x.Data.DurableId == testPoint.DurableId));
      if (viewModelGridItem != null)
      {
        this.UnregisterContent<DomainObjectViewModel<CompletionTestPoint>>(viewModelGridItem.ViewModel);
        this.TestPoints.Remove(viewModelGridItem);
      }
    }
  }

  private void Trajectory_Changed(object sender, DomainObjectChangeEvent
