

  private static double ConvertAngleForDisplay(double angle)
  {
    return !double.IsNaN(angle) ? 180.0 * angle / Math.PI : double.NaN;
  }

  private static string ConvertNameToWPFStandards(string name)
  {
    string wpfStandards = string.Empty;
    if (string.IsNullOrWhiteSpace(name))
      return wpfStandards;
    int num = 0;
    foreach (char c in name)
      wpfStandards = !char.IsLetterOrDigit(c) ? wpfStandards + ((int) c).ToString() + string.Empty : (num++ != 0 || !char.IsDigit(c) ? wpfStandards + c.ToString() : $"{wpfStandards}nbsp{c.ToString()}");
    return wpfStandards;
  }

  private DrawingGroup WellHeadDrawingGroup(FrameworkElement wellheadShape)
  {
    return !(this._wellHead != (Slb.Production.Engineering.Model.StandardDomain.WellHead) null) || !this._wellHead.IsAdvancedType() ? (DrawingGroup) wellheadShape.FindResource((object) "grpWellHead") : this.AdvancedWellHeadDrawingGroup();
  }

  private DrawingGroup AdvancedWellHeadDrawingGroup()
  {
    AdvancedWellhead advancedWellhead = new AdvancedWellhead();
    Slb.Production.Engineering.Model.StandardDomain.WellHead.FlowPathOpenTypes pathOpenClosedType = this._wellHead.FlowPathOpenClosedType;
    switch (pathOpenClosedType)
    {
      case Slb.Production.Engineering.Model.StandardDomain.WellHead.FlowPathOpenTypes.NoFlow:
        return (DrawingGroup) advancedWellhead.FindResource((object) "EmptyWellHead");
      case Slb.Production.Engineering.Model.StandardDomain.WellHead.FlowPathOpenTypes.Annulus:
        return (DrawingGroup) advancedWellhead.FindResource((object) "WellHeadAnnulus");
      case Slb.Production.Engineering.Model.StandardDomain.WellHead.FlowPathOpenTypes.TubingOne:
        return (DrawingGroup) advancedWellhead.FindResource((object) "WellHeadSingleString");
      default:
        return pathOpenClosedType.HasFlag((Enum) Slb.Production.Engineering.Model.StandardDomain.WellHead.FlowPathOpenTypes.Annulus) && pathOpenClosedType.HasFlag((Enum) Sl
