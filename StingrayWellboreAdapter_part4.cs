this._sectionalStyle = value;
  }

  public bool ShowValidation
  {
    get => this._showValidation;
    set => this._showValidation = value;
  }

  public bool ShowText
  {
    get => this._showText;
    set => this._showText = value;
  }

  public WellboreSchematicCanvas WellboreSchematic => this._wellboreSchematic;

  public Func<object, bool> IsItemValidForSelection { get; set; }

  public static DepthReferenceWellboreItemView NewGauge(string name, bool showName)
  {
    DepthReferenceWellboreItemView wellboreItemView = new DepthReferenceWellboreItemView();
    wellboreItemView.IsLabelVisible = true;
    Gauge gauge = new Gauge();
    wellboreItemView.Label.ContentControl = (Control) gauge;
    wellboreItemView.LabelTrackIndex = 0;
    gauge.DataContext = (object) wellboreItemView;
    if (!string.IsNullOrWhiteSpace(name))
    {
      wellboreItemView.Name = name.Trim();
      gauge.GaugeName.Text = showName ? name.Trim() : string.Empty;
    }
    wellboreItemView.Label.ShadowBrush = (Brush) Brushes.Transparent;
    return wellboreItemView;
  }

  public static DepthReferenceWellboreItemView NewNodal(string name, bool showName)
  {
    DepthReferenceWellboreItemView wellboreItemView = new DepthReferenceWellboreItemView();
    wellboreItemView.RenderTransform = (Transform) StingrayWellboreAdapter.ScaleTransform;
    wellboreItemView.IsLabelVisible = true;
    Measurement measurement = new Measurement();
    wellboreItemView.Label.ContentControl = (Control) measurement;
    wellboreItemView.LabelTrackIndex = 0;
    measurement.DataContext = (object) wellboreItemView;
    if (!string.IsNullOrWhiteSpace(name))
    {
      wellboreItemView.Name = name.Trim();
      measurement.GaugeName.Text = showName ? name.Trim() : string.Empty;
    }
    wellboreItemView.Label.ShadowBrush = (Brush) Brushes.Transparent;
    return wellboreItemView;
  }

  public static Slb.Ocean.UI.WellboreSchematic.Perforation NewPerforationSy
