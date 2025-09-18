this._casingSubscription);
    TubingSection eventPublisher = this.DataSource.FluidLink.WellString.GetSections().OrderByDescending<TubingSection, double>((Func<TubingSection, double>) (x => x.InnerDiameter)).FirstOrDefault<TubingSection>();
    if (!(eventPublisher != (TubingSection) null))
      return;
    this._casingSubscription = this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) eventPublisher, new EventHandler<DomainObjectChangeEventArgs>(this.CasingSection_Changed)));
  }

  private void RelativePermeabilityPoints_CollectionChanged(
    object sender,
    NotifyCollectionChangedEventArgs e)
  {
    if (e.Action == NotifyCollectionChangedAction.Remove && e.OldItems != null)
      this.DeleteSelectedPermeabilityItems((IEnumerable<ViewModelGridItem<RelativePermeabilityPoint>>) e.OldItems.OfType<ViewModelGridItem<RelativePermeabilityPoint>>().ToList<ViewModelGridItem<RelativePermeabilityPoint>>());
    this.OnPropertyChanged("RelativePermeabilityPoints");
  }

  private void Point_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    this.UpdatePending = true;
  }

  private void DataSource_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    if (e.PropertyNames.Contains<string>("IsTransient") && this.DataSource.IsTransient)
    {
      if (!this.DataSource.UseDrainageRadius)
        this.SetValue("UseDrainageRadius", (object) true);
      this.OnPropertyChanged((string) null);
    }
    if (e.PropertyNames.Contains<string>("UseVogelBelowBubblepoint") || e.PropertyNames.Contains<string>("IsGasModel"))
      this.OnPropertyChanged((Expression<Func<object>>) (() => (object) this.IsVogelBelowBubblePoint));
    this.UpdatePending = true;
  }

  private void PerforationLocation_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    this.OnPropertyChanged((Expression<Func<object>>) (() => (object) this.CanSetWellboreDiameter));
    this.OnPropertyChanged((Expr
