cription((INotifyCollectionChanged) wellString.Sections, new NotifyCollectionChangedEventHandler(this.WellStringSections_CollectionChanged))));
    foreach (OdtDomainObjectBase section in wellString.GetSections())
      this._transientSubscriptionList.Add(this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription(section, new EventHandler<DomainObjectChangeEventArgs>(this.WellString_Changed))));
    Borehole borehole = wellString.Borehole;
    if (DataHelper.IsNullObject((IDomainObject) borehole))
      return;
    this._transientSubscriptionList.Add(this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) borehole, new EventHandler<DomainObjectChangeEventArgs>(this.Borehole_Changed))));
    foreach (OdtDomainObjectBase zoneLink in (IEnumerable<ZoneLink>) borehole.ZoneLinks)
      this._transientSubscriptionList.Add(this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription(zoneLink, new EventHandler<DomainObjectChangeEventArgs>(this.ZoneLink_Changed))));
    this._transientSubscriptionList.Add(this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) borehole.ZoneLinks, new NotifyCollectionChangedEventHandler(this.ZoneLinks_CollectionChanged))));
    WellTrajectory trajectory = borehole.Trajectory;
    if (DataHelper.IsNullObject((IDomainObject) trajectory))
      return;
    this._transientSubscriptionList.Add(this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) trajectory, new EventHandler<DomainObjectChangeEventArgs>(this.Trajectory_Changed))));
    this._transientSubscriptionList.Add(this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) trajectory.Measurements, new NotifyCollectionChangedEventHandler(this.TrajectoryMeasurements_CollectionChanged))));
    foreach (OdtDomainObjectBase measurement in trajectory.GetMeasurements())

