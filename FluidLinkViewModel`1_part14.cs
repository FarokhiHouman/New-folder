Args e)
  {
    this.OnPropertyChanged("CompletionDeviationCalculated");
    this.OnPropertyChanged("CasingIdCalculated");
  }

  private void TrajectoryMeasurements_CollectionChanged(
    object sender,
    NotifyCollectionChangedEventArgs e)
  {
    if (e.NewItems != null)
    {
      foreach (OdtDomainObjectBase newItem in (IEnumerable) e.NewItems)
        this._transientSubscriptionList.Add(this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription(newItem, new EventHandler<DomainObjectChangeEventArgs>(this.TrajectoryMeasurement_Changed))));
    }
    this.OnPropertyChanged("CompletionDeviationCalculated");
    this.OnPropertyChanged("CasingIdCalculated");
  }

  private void TrajectoryMeasurement_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    this.OnPropertyChanged("CompletionDeviationCalculated");
    this.OnPropertyChanged("CasingIdCalculated");
  }

  private void Borehole_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    if (!e.PropertyNames.Contains<string>("ShowZones"))
      return;
    this.AssociatedZone = this.DataSource.GetAssociatedZone();
  }

  private void ZoneLinks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    if (e.NewItems != null)
    {
      foreach (OdtDomainObjectBase newItem in (IEnumerable) e.NewItems)
        this._transientSubscriptionList.Add(this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription(newItem, new EventHandler<DomainObjectChangeEventArgs>(this.ZoneLink_Changed))));
    }
    this.AssociatedZone = this.DataSource.GetAssociatedZone();
  }

  private void ZoneLink_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    if (!e.PropertyNames.Contains<string>("ZoneTopMeasuredDepth") && !e.PropertyNames.Contains<string>("ZoneBottomMeasuredDepth"))
      return;
    this.AssociatedZone = this.DataSource.GetAssociatedZone();
  }

  private void LocationViewModel_PropertyChanged(o
