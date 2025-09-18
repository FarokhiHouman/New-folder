ameof (WellheadDepth));
      this.OnPropertyChanged("BoreholeViewModel");
      this.OnPropertyChanged("WellboreSchematicViewModel");
    }
  }

  public override ImageSource Image
  {
    get
    {
      if (this.DataSource != (Slb.Production.Engineering.Model.StandardDomain.WellHead) null)
      {
        if (this.DataSource.IsBuiltinTemplate)
          return ImageKey.WellTemplateSystem.ToImageSource(ImageSizes.Image16);
        if (this.DataSource.IsTemplate)
          return ImageKey.WellTemplateUser.ToImageSource(ImageSizes.Image16);
      }
      return ImageKey.Well.ToImageSource(ImageSizes.Image16);
    }
  }

  public int SelectedStreamOutletIndex { get; set; }

  public int SelectedIndex
  {
    get => this._selectedIndex;
    set
    {
      DebugLogger.Info($"SelectedIndex Called with:{value} Current value is:{this._selectedIndex}", DebugLogger.LogInfoType.LogInfoWellEditor);
      if (this._selectedIndex == value)
        return;
      bool equipmentSelected = this.IsSurfaceEquipmentSelected;
      this._selectedIndex = value;
      this.OnPropertyChanged(nameof (SelectedIndex));
      this.OnPropertyChanged("IsSurfaceEquipmentSelected");
      if (this._ribbonService != null && equipmentSelected != this.IsSurfaceEquipmentSelected)
        this.UpdateRibbon();
      this.InvokeRefreshLayout();
    }
  }

  public bool IsSurfaceEquipmentSelected => this.SelectedIndex == 7;

  public IRibbonService RibbonService
  {
    get => this._ribbonService;
    set
    {
      if (this._ribbonService == value)
        return;
      if (this._ribbonService != null)
        this._ribbonService.Dispose();
      this._ribbonService = value;
      this.OnPropertyChanged(nameof (RibbonService));
      this.UpdateRibbon();
    }
  }

  private void SetStreamOutletTabIndex(ModelItem activeItem)
  {
    if (this.DataSource.WellType != WellType.Advanced)
      return;
    Source source = activeItem as Source;
 
