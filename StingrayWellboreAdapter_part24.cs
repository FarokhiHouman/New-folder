n !(this.CurrentModel != (Slb.Production.Engineering.Model.StandardDomain.Model) null) || this.CurrentModel.GetBoolOption(key, true);
  }

  private void SaveDisplaySettings(string key, bool val)
  {
    if (!(this.CurrentModel != (Slb.Production.Engineering.Model.StandardDomain.Model) null))
      return;
    bool? boolOption = this.CurrentModel.GetBoolOption(key);
    if (boolOption.HasValue && boolOption.Value == val)
      return;
    this.CurrentModel.SetBoolOption(key, val);
  }

  private void DrawWellString(
    Wellbore wellbore,
    Borehole ourBore,
    TubularString tubingString,
    WellString wellString,
    TubularType tubularType)
  {
    double d1 = double.NaN;
    double y = 0.0;
    double od = 0.0;
    bool flag = tubularType == TubularType.Casing;
    int num = 1;
    TubularString stringToIgnore1 = tubingString;
    Material material = (Material) null;
    this.AddWatch((INotifyCollectionChanged) wellString.Sections);
    IEnumerable<TubingSection> tubingSections;
    if (wellString.IsValidTubing)
    {
      SectionType retrieveType = this._wellHead.WellType == WellType.Advanced ? SectionType.Tubing | SectionType.TailPipe : SectionType.Tubing;
      tubingSections = (IEnumerable<TubingSection>) WellString.RetrieveSections(wellString.ValidOrderedSections, retrieveType).OrderBy<TubingSection, double>((Func<TubingSection, double>) (s => s.TopMeasuredDepth)).ToList<TubingSection>();
    }
    else
      tubingSections = (IEnumerable<TubingSection>) wellString.GetSections();
    foreach (TubingSection tubingSection in tubingSections)
    {
      if (this.ValidateTubingSection(tubingSection))
      {
        this.AddWatch((ModelItem) tubingSection);
        if (!double.IsNaN(tubingSection.Length))
        {
          Tubular element1;
          if (flag)
          {
            if (tubingSection.SectionType == SectionType.OpenHole)
            {
              element1 = (Tubular) new Casing();
       
