this._selectedTemplate = this.Templates.FirstOrDefault<WellTemplateDisplay>();
    this.ImportWellCommand = (ICommand) new RelayCommand(new Action<object>(this.OnImportWell));
  }

  public ObservableCollection<WellTemplateDisplay> Templates { get; private set; }

  public override string Title
  {
    get => string.Format(CoreStrings.NewType, (object) CoreStrings.Well.ToLower());
  }

  public override ImageSource Image => ImageKey.Well.ToImageSource(ImageSizes.Image16);

  public WellTemplateDisplay SelectedTemplate
  {
    get => this._selectedTemplate;
    set
    {
      if (this._selectedTemplate == value)
        return;
      this._selectedTemplate = value;
      this.OnPropertyChanged(ViewModel.GetPropertyName((Expression<Func<object>>) (() => this.SelectedTemplate)));
      if (this._selectedTemplate == null || this._selectedTemplate == this._noneOption)
        return;
      this.ImportWellPath = string.Empty;
    }
  }

  public string ImportWellPath
  {
    get => this._importWellPath;
    set
    {
      if (!(this._importWellPath != value))
        return;
      this._importWellPath = value;
      this.OnPropertyChanged(ViewModel.GetPropertyName((Expression<Func<object>>) (() => this.ImportWellPath)));
      if (string.IsNullOrEmpty(this._importWellPath))
        return;
      this.SelectedTemplate = this._noneOption;
    }
  }

  public WellHead ResultWell { get; private set; }

  public bool CanImportWell { get; }

  public ICommand ImportWellCommand { get; private set; }

  protected override bool OnValidate()
  {
    return !this.HasError() && this.SelectedTemplate != null && this._network != (Network) null;
  }

  private bool HasError()
  {
    return this.SelectedTemplate != null && this.SelectedTemplate.TemplateWell != (WellHead) null && !string.IsNullOrEmpty(this.ImportWellPath);
  }

  protected override bool OnCommit()
  {
    IPresentationService service1 = ServiceDirectory.GetSe
