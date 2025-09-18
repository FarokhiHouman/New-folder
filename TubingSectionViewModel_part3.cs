inObjectChangedSubscription((OdtDomainObjectBase) this.DataSource, new EventHandler<DomainObjectChangeEventArgs>(this.DataSource_Changed)));
    if (!(model != (TubingSection) null) || !(model.WellString != (WellString) null))
      return;
    this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) model.WellString.Sections, new NotifyCollectionChangedEventHandler(this.WellStringSectionsChanged)));
  }

  private void WellStringSectionsChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    this.OnPropertyChanged("IsFromMdReadOnly");
  }

  private void DataSource_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    foreach (string propertyName in e.PropertyNames)
    {
      switch (propertyName)
      {
        case "CatalogLabel":
          this.OnPropertyChanged("SectionCatalogLabel");
          continue;
        case "CatalogName":
          this.OnPropertyChanged("SectionCatalogName");
          continue;
        case "InnerDiameter":
          this.OnPropertyChanged("InD");
          this.OnPropertyChanged("OutD");
          continue;
        case "Length":
          this.OnPropertyChanged("Length");
          this.OnPropertyChanged("BottomMD");
          continue;
        case "OuterDiameter":
          this.OnPropertyChanged("OutD");
          continue;
        case "Roughness":
          this.OnPropertyChanged("SectionRoughness");
          continue;
        case "TopMeasuredDepth":
          this.OnPropertyChanged("TopMD");
          this.OnPropertyChanged("BottomMD");
          continue;
        case "WallThickness":
          this.OnPropertyChanged("WallThickness");
          this.OnPropertyChanged("OutD");
          continue;
        default:
          continue;
      }
    }
  }

  public static ObservableCollection<SectionType> CasingLinerOpenHoleSectionTypes { get; private set; }

  public static ObservableCollection<SectionType> 
