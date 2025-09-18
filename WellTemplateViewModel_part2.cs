iewService = viewService;
    this._domainObjectHost = domainObjectHost;
    this._name = this.DataSource.Name;
    this.IsUserDefined = !this.DataSource.IsBuiltinTemplate;
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) this.DataSource, new EventHandler<DomainObjectChangeEventArgs>(this.WellChanged)));
  }

  public override string Title
  {
    get
    {
      return !this.IsUserDefined ? CoreStrings.BuiltInWellTemplate : CoreStrings.UserDefinedWellTemplate;
    }
  }

  public bool IsUserDefined { get; private set; }

  public object MenuItems
  {
    get
    {
      List<MenuItem> menuItemList = new List<MenuItem>();
      MenuItem menuItem1 = new MenuItem();
      menuItem1.Header = this.IsUserDefined ? (object) CoreStrings.EditWithEllipses : (object) CoreStrings.View;
      menuItem1.Icon = (object) new System.Windows.Controls.Image()
      {
        Source = ImageKey.Edit.ToImageSource(ImageSizes.Image16)
      };
      menuItem1.Command = Slb.Production.Engineering.UI.Commands.Edit;
      menuItem1.CommandParameter = (object) this.DataSource;
      MenuItem menuItem2 = menuItem1;
      menuItemList.Add(menuItem2);
      MenuItem menuItem3 = new MenuItem();
      menuItem3.Header = (object) CoreStrings.Delete;
      menuItem3.Icon = (object) new System.Windows.Controls.Image()
      {
        Source = ImageKey.Delete.ToImageSource(ImageSizes.Image16)
      };
      menuItem3.Command = (ICommand) new RelayCommand((Action<object>) (param => this.OnDelete()), (Predicate<object>) (param => this.IsUserDefined));
      menuItem3.CommandParameter = (object) this.DataSource;
      MenuItem menuItem4 = menuItem3;
      menuItemList.Add(menuItem4);
      return (object) menuItemList.ToArray();
    }
  }

  public string TemplateName
  {
    get => this._name;
    set
    {
      if (value == null || value.Trim() == string.Empty)
        this._viewService.Error(Co
