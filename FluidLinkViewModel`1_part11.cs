      this._transientSubscriptionList.Add(this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription(measurement, new EventHandler<DomainObjectChangeEventArgs>(this.TrajectoryMeasurement_Changed))));
  }

  private void PopulateTestData()
  {
    if (this.IPRModelViewModel.CanUseTestDataForIPRCalulation)
    {
      this.TestPoints.Clear();
      if (this.DataSource.TestData != null)
      {
        for (int index = this.IPRModelViewModel.DefaultNumberOfTestPoints - this.DataSource.TestData.Count<CompletionTestPoint>(); index > 0; --index)
          this.CreateTestPoint();
        foreach (CompletionTestPoint completionTestPoint in (IEnumerable<CompletionTestPoint>) this.DataSource.TestData)
          this.TestPoints.Add(new ViewModelGridItem<CompletionTestPoint>((DomainObjectViewModel<CompletionTestPoint>) new CompletionTestPointViewModel(completionTestPoint)));
      }
    }
    this.OnPropertyChanged("IPRCurveTestData");
  }

  private void InitializeNewTestPoint(ViewModelGridItem<CompletionTestPoint> item)
  {
    CompletionTestPoint testPoint = this.CreateTestPoint();
    item.ViewModel = (DomainObjectViewModel<CompletionTestPoint>) new CompletionTestPointViewModel(testPoint);
    this.OnPropertyChanged("IPRCurveTestData");
  }

  private CompletionTestPoint CreateTestPoint()
  {
    CompletionTestPoint testPoint;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      testPoint = CompletionTestPointAccessor.GetFacadeAccessor(ServiceDirectory.GetService<IDomainObjectHost>()).Create(this._model.DataSource);
      nuTransaction.Lock((object) this.DataSource);
      testPoint.FluidLink = (FluidLink) this.DataSource;
      nuTransaction.Commit();
    }
    return testPoint;
  }

  private void UpdateIPR(bool valid)
  {
    if (!this.IsActiveView || !this.NeedIprUpdate || this.IsDisposed || this.IPRModelViewModel == null || !((FluidLink) this.DataSource != (FluidLink) null))
 
