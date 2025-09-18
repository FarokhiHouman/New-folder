CasingOpenHoleSectionTypes { get; private set; }

  public static ObservableCollection<SectionType> CasingLinerSectionTypes { get; private set; }

  public static ObservableCollection<SectionType> CasingOnlySectionTypes { get; private set; }

  public static ObservableCollection<SectionType> OpenHoleOnlySectionTypes { get; private set; }

  public ObservableCollection<SectionType> CasingSectionTypes
  {
    get
    {
      if (this.CasingCurrentIndex < 0 || this.parentBorehole.CasingSections.Count < 1)
        return (ObservableCollection<SectionType>) null;
      if (this.parentBorehole.CasingSections.Count == 1 && this.CasingCurrentIndex == 0)
        return TubingSectionViewModel.CasingOpenHoleSectionTypes;
      if (this.parentBorehole.CasingSections.Count > 1 && this.CasingCurrentIndex == 0)
        return TubingSectionViewModel.CasingOnlySectionTypes;
      if (this.parentBorehole.CasingSections.Count - 1 == this.CasingCurrentIndex)
      {
        if (this.parentBorehole.OpenHole != null && this.parentBorehole.OpenHole.CasingCurrentIndex < this.CasingCurrentIndex)
          return (ObservableCollection<SectionType>) null;
        return this.parentBorehole.Liner != null && this.parentBorehole.Liner.CasingCurrentIndex < this.CasingCurrentIndex ? TubingSectionViewModel.OpenHoleOnlySectionTypes : TubingSectionViewModel.CasingLinerOpenHoleSectionTypes;
      }
      if (this.parentBorehole.CasingSections.Count - 1 <= this.CasingCurrentIndex)
        return (ObservableCollection<SectionType>) null;
      if (this.SelectedSectionType == SectionType.Liner)
        return TubingSectionViewModel.CasingLinerOpenHoleSectionTypes;
      if (this.parentBorehole.Liner != null && this.parentBorehole.Liner.CasingCurrentIndex < this.CasingCurrentIndex || this.SelectedSectionType == SectionType.OpenHole)
        return TubingSectionViewModel.OpenHoleOnlySectionTypes;
      if (this.parentBorehole.OpenHole != null && this.parentBorehole.OpenHole.Ca
