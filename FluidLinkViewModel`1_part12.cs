     return;
    this.IPRModelViewModel.Update(valid);
    this.NeedIprUpdate = false;
  }

  private bool CanDeleteSelectedItems(object parameter)
  {
    if (this.DataSource.CompModel != (CompletionModel) null && !this.DataSource.CompModel.CanDeleteTestPoints || !(parameter is IList source))
      return false;
    int num = source.OfType<ViewModelGridItem<CompletionTestPoint>>().Count<ViewModelGridItem<CompletionTestPoint>>();
    return num != 0 && this.DataSource.TestData.Count<CompletionTestPoint>() - num >= this.IPRModelViewModel.MinTestPoints;
  }

  private void DeleteSelectedItems(object parameter)
  {
    List<ViewModelGridItem<CompletionTestPoint>> list = ((IEnumerable) parameter).OfType<ViewModelGridItem<CompletionTestPoint>>().ToList<ViewModelGridItem<CompletionTestPoint>>();
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      foreach (ViewModelGridItem<CompletionTestPoint> viewModelGridItem in list)
      {
        if (viewModelGridItem != null)
        {
          nuTransaction.Lock((object) this.DataSource, (object) this.DataSource.TestData, (object) viewModelGridItem.Data);
          FacadeAccessor.Delete<CompletionTestPoint>(viewModelGridItem.Data);
        }
      }
      nuTransaction.Commit();
    }
    this.OnPropertyChanged("IPRCurveTestData");
  }

  private bool ShouldFireEventOnModelChange(
    DomainObjectChangeEventArgs domainObjectChangeEventArgs)
  {
    List<string> second = new List<string>()
    {
      ViewModel.GetPropertyName((Expression<Func<object>>) (() => (object) this._model.FluidType))
    };
    return domainObjectChangeEventArgs.PropertyNames.Intersect<string>((IEnumerable<string>) second).Any<string>();
  }

  private void WellString_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    this.UpdateListeners();
    this.AssociatedZone = this.DataSource.GetAssociatedZone();
  }

  private void WellStringSections_CollectionChanged(
   
