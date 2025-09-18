 schematicFlowPath.Name = string.Format(CoreStrings.FlowFrom, (object) str1, (object) str2);
    schematicFlowPath.Pen = new Pen()
    {
      DashStyle = wellIsSolvable ? DashStyles.Solid : DashStyles.Dash,
      Brush = wellIsSolvable ? (Brush) new SolidColorBrush(Color.FromRgb((byte) 40, (byte) 160 /*0xA0*/, (byte) 8)) : (Brush) new SolidColorBrush(Color.FromRgb(byte.MaxValue, (byte) 0, (byte) 0))
    };
    schematicFlowPath.Background = wellIsSolvable ? (Brush) new SolidColorBrush(Color.FromRgb((byte) 40, (byte) 160 /*0xA0*/, (byte) 8)) : (Brush) new SolidColorBrush(Color.FromRgb(byte.MaxValue, (byte) 0, (byte) 0));
    schematicFlowPath.FlowSectionCollection.AddRange((IEnumerable<FlowSection>) sections);
    schematicFlowPath.TopDepth = this.GetAValidWellHeadDepth(false);
    if (!this._showText)
      schematicFlowPath.IsLabelVisible = false;
    if (this._wellHead.WellType == WellType.Advanced)
    {
      schematicFlowPath.IsLabelVisible = false;
      schematicFlowPath.Name = string.Empty;
    }
    casing.DownholeItems.Add((BaseDownholeItem) schematicFlowPath);
    return schematicFlowPath;
  }

  private IList<double> FindDepths()
  {
    IList<double> depths = (IList<double>) new List<double>();
    WellString wellString = this._wellHead.DefaultBorehole.WellStrings.FirstOrDefault<WellString>((Func<WellString, bool>) (x => x.IsValidTubing));
    if (wellString != (WellString) null)
      depths = (IList<double>) wellString.GetSections().Where<TubingSection>((Func<TubingSection, bool>) (section => !double.IsNaN(section.TopMeasuredDepth))).Select<TubingSection, double>((Func<TubingSection, double>) (section => section.TopMeasuredDepth)).ToList<double>();
    return depths;
  }

  private double GetAValidWellHeadDepth(bool adjust)
  {
    double num = adjust ? 10.0 : 0.0;
    double wellheadDepth = this._wellHead.WellheadDepth;
    return !double.IsNaN(wellheadDepth) && !double.IsInfinity(wellheadDepth) ? this._wellHead.Well
