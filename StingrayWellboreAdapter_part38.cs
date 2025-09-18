    PipeBase pipeBase = (PipeBase) section;
    return pipeBase.Name != null && pipeBase.InnerDiameter > 0.0 && (pipeBase.WallThickness >= 0.0 || section.SectionType == SectionType.OpenHole);
  }

  private void WellboreSchematicPropertyChanged(object sender, PropertyChangedEventArgs e)
  {
    if (this._wellboreChangingInProgress)
      return;
    using (new DisposableToken((Action) (() => this._wellboreChangingInProgress = true), (Action) (() => this._wellboreChangingInProgress = false), true))
    {
      if (!(e.Source is Tubular source))
        return;
      TubingSection tag = source.Tag as TubingSection;
      if (tag == (TubingSection) null)
        return;
      switch (e.PropertyName)
      {
        case "TopDepth":
          if (!tag.IsTubing && !tag.IsTailPipe || Math.Abs(source.TopDepth - tag.TopMeasuredDepth) <= double.Epsilon)
            break;
          source.TopDepth = tag.TopMeasuredDepth;
          break;
        case "Length":
          double length = tag.Length;
          if (!length.AlmostEqual(tag.Length, double.Epsilon))
            break;
          using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
          {
            nuTransaction.Lock((object) tag);
            if (length.AlmostEqual(tag.Length, double.Epsilon))
              tag.Length = length;
            nuTransaction.Commit();
            break;
          }
      }
    }
  }

  private void WellboreItemMoved(object sender, WellboreEventArgs e)
  {
    BaseWellboreItem baseWellboreItem = e.Item;
    if (baseWellboreItem.TubularString == null)
      return;
    WellString tag1 = baseWellboreItem.TubularString.Tag as WellString;
    bool flag = false;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      DownholeLocation downholeLocation = (DownholeLocation) null;
      Equipment tag2 = baseWellboreItem.Tag as Equipment;
      if (tag2 != (Equipment) null)
      {
        downh
