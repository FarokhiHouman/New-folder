domainObject.SectionType == SectionType.Liner;
    this.RefreshTubings();
    this.SelectedTubing = this.Tubings.FirstOrDefault<Tubing>((Func<Tubing, bool>) (i =>
    {
      if (!(i.Name == this._domainObject.Name))
        return false;
      double? outsideDiameter = i.OutsideDiameter;
      double outerDiameter = this._domainObject.GetOuterDiameter();
      return outsideDiameter.GetValueOrDefault() == outerDiameter & outsideDiameter.HasValue;
    }));
  }

  public override string Title
  {
    get
    {
      switch (this._domainObject.SectionType)
      {
        case SectionType.Casing:
        case SectionType.Liner:
          return CoreStrings.CasingCatalog;
        case SectionType.Tubing:
        case SectionType.TailPipe:
          return CoreStrings.TubingCatalog;
        default:
          throw new NotSupportedException("Unknown section type enum.");
      }
    }
  }

  public ICommand ApplySelectionCommand { get; set; }

  public IEnumerable<Tubing> Tubings
  {
    get => this._tubings;
    set
    {
      this._tubings = value;
      this.OnPropertyChanged(nameof (Tubings));
    }
  }

  public Tubing SelectedTubing
  {
    get => this._selectedTubing;
    set
    {
      this._selectedTubing = value;
      this.OnPropertyChanged(nameof (SelectedTubing));
    }
  }

  private void RefreshTubings()
  {
    List<Tubing> list = this._catalogDataService.Get<Tubing>((Expression<Func<Tubing, bool>>) (i => i.IsCasing == this._isCasing)).OrderBy<Tubing, string>((Func<Tubing, string>) (i => i.Catalog)).ThenBy<Tubing, string>((Func<Tubing, string>) (i => i.Name)).ThenBy<Tubing, double?>((Func<Tubing, double?>) (i => i.InsideDiameter)).ToList<Tubing>();
    int? selectedTubingId = this.SelectedTubing != null ? new int?(this.SelectedTubing.ID) : new int?();
    this.Tubings = (IEnumerable<Tubing>) list;
    this.SelectedTubing = !selectedTubingId.HasValue ? this.Tubings.FirstOrDefault<Tubing>() : this.
