ce(ImageSizes.Image16);
  }

  public RelayCommand DeleteItemCmd { get; private set; }

  public ObservableCollection<WellTemplateViewModel> WellDisplays => this._wellDisplays;

  public WellTemplateViewModel SelectedItem
  {
    get => this._selectedItem;
    set
    {
      if (this._selectedItem == value)
        return;
      this._selectedItem = value;
      this.OnPropertyChanged(nameof (SelectedItem));
      if (this._selectedItem == null)
        return;
      this._stateService.SetInputContext((IEnumerable<DurableId>) new DurableId[1]
      {
        this._selectedItem.DataSource.DurableId
      }, (object) this);
    }
  }

  public ICommand OpenWellTemplateCommand { get; private set; }

  private void SetupCommands()
  {
    this.DeleteItemCmd = new RelayCommand((Action<object>) (param => this.DeleteTemplate()), (Predicate<object>) (param => this.CanDeleteTemplate()));
  }

  private void PopulateWellDisplaysList()
  {
    if (this._wellDisplays == null)
      this._wellDisplays = new ObservableCollection<WellTemplateViewModel>();
    this._wellDisplays.Clear();
    foreach (WellHead templateWell in (IEnumerable<WellHead>) this._model.TemplateWells)
    {
      if (templateWell != (WellHead) null)
        this._wellDisplays.Add(new WellTemplateViewModel(templateWell));
    }
  }

  private WellTemplateViewModel FindInstance(WellHead templateWell)
  {
    return this.WellDisplays.FirstOrDefault<WellTemplateViewModel>((Func<WellTemplateViewModel, bool>) (x => x.DataSource == templateWell));
  }

  private bool CanDeleteTemplate() => this.SelectedItem != null;

  private void DeleteTemplate()
  {
    if (!this.CanDeleteTemplate() || this.SelectedItem.DataSource.IsBuiltinTemplate || !this._viewService.Warn(CoreStrings.Delete, string.Format(CoreStrings.DeleteItemName, (object) this.SelectedItem.DataSource.Name)))
      return;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
