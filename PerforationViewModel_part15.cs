t.Add(IPRModelType.JoshiSS);
          iprModelTypeList.Add(IPRModelType.BabuOdehPSS);
          break;
        case PerforationViewModel.CompletionFluidEntryGeometryProfileMode.DistributedVertical:
          iprModelTypeList.Add(IPRModelType.DistributedPIVertical);
          break;
        case PerforationViewModel.CompletionFluidEntryGeometryProfileMode.DistributedHorizontal:
          iprModelTypeList.Add(IPRModelType.DistributedPIHorizontal);
          iprModelTypeList.Add(IPRModelType.JoshiSS);
          iprModelTypeList.Add(IPRModelType.BabuOdehPSS);
          iprModelTypeList.Add(IPRModelType.TrilinearTransientIPR);
          break;
      }
      PerforationViewModel._IPRModelTypeModeMappings.Add(key, iprModelTypeList);
    }
  }

  public PerforationViewModel(Perforation dataSource, Slb.Production.Engineering.Model.StandardDomain.Model model)
    : base(dataSource, model)
  {
    this.UpdateIPROptions();
    this.PropertyChanged += new PropertyChangedEventHandler(this.PerforationViewModel_PropertyChanged);
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) model, new EventHandler<DomainObjectChangeEventArgs>(this.Model_Changed)));
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) this.DataSource, new EventHandler<DomainObjectChangeEventArgs>(this.PerforationChanged)));
    this.SetupValidation();
  }

  public int SelectedIndex
  {
    get => this.selectedIndex;
    set
    {
      this.selectedIndex = value;
      this.OnPropertyChanged((Expression<Func<object>>) (() => (object) this.SelectedIndex));
    }
  }

  public string ItemName
  {
    get => this.DataSource.Name;
    set
    {
      string name = value;
      if (this.DataSource.DownholeEquipmentNameAlreadyExists(name))
      {
        this.OnPropertyChanged(nameof (ItemName));
      }
      else
      {
        bool needsValidation = value != n
