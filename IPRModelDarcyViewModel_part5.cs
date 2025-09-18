ch (string completionModelProperty in IPRModelDarcyViewModel.DarcyCompletionModelProperties)
      this.OnPropertyChanged(completionModelProperty);
  }

  private void InitializeNewRelativePermeabilityPoint(
    ViewModelGridItem<RelativePermeabilityPoint> item)
  {
    RelativePermeabilityPoint permeabilityPoint;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      IDomainObjectHost service = ServiceDirectory.GetService<IDomainObjectHost>();
      nuTransaction.Lock((object) this.DataSource, (object) this.DataSource.RelativePermeabilityData);
      permeabilityPoint = RelativePermeabilityPointAccessor.GetFacadeAccessor(service).Create(this.workspaceModel.DataSource);
      permeabilityPoint.DarcyCompletionModel = this.DataSource;
      nuTransaction.Commit();
    }
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) permeabilityPoint, new EventHandler<DomainObjectChangeEventArgs>(this.Point_Changed)));
    item.ViewModel = (DomainObjectViewModel<RelativePermeabilityPoint>) this.RegisterContent<DomainObjectPropertyBagViewModel<RelativePermeabilityPoint>>(new DomainObjectPropertyBagViewModel<RelativePermeabilityPoint>(permeabilityPoint));
  }

  private void PopulatePermeabilityPoints()
  {
    if (this.DataSource.RelativePermeabilityData == null)
      return;
    foreach (ViewModelGridItem<RelativePermeabilityPoint> permeabilityPoint in (Collection<ViewModelGridItem<RelativePermeabilityPoint>>) this.RelativePermeabilityPoints)
      this.UnregisterSubscriptions((object) permeabilityPoint.Data);
    this.RelativePermeabilityPoints.Clear();
    foreach (RelativePermeabilityPoint permeabilityPoint in (IEnumerable<RelativePermeabilityPoint>) this.DataSource.RelativePermeabilityData)
    {
      this.RelativePermeabilityPoints.Add(new ViewModelGridItem<RelativePermeabilityPoint>((DomainObjectViewModel<RelativePermeabilityPoint>) new DomainObjectPropertyBagVi
