singCurrentIndex < this.CasingCurrentIndex)
        return (ObservableCollection<SectionType>) null;
      return this.parentBorehole.CasingSections[this.CasingCurrentIndex + 1].Data.SectionType == SectionType.OpenHole ? TubingSectionViewModel.CasingLinerSectionTypes : TubingSectionViewModel.CasingOnlySectionTypes;
    }
  }

  public int TubingCurrentIndex
  {
    get
    {
      return this.parentBorehole != null ? this.parentBorehole.TubingSections.IndexOf(this.parentBorehole.TubingSections.FirstOrDefault<ViewModelGridItem<TubingSection>>((Func<ViewModelGridItem<TubingSection>, bool>) (cs => cs.Data.DurableId.Instance == this.DataSource.DurableId.Instance))) : -1;
    }
  }

  public int CasingCurrentIndex
  {
    get
    {
      return this.parentBorehole != null ? this.parentBorehole.CasingSections.IndexOf(this.parentBorehole.CasingSections.FirstOrDefault<ViewModelGridItem<TubingSection>>((Func<ViewModelGridItem<TubingSection>, bool>) (cs => cs.Data.DurableId.Instance == this.DataSource.DurableId.Instance))) : -1;
    }
  }

  public double BottomMD
  {
    get
    {
      return this.DataSource != (TubingSection) null && !double.IsNaN(this.TopMD) && !double.IsNaN(this.Length) ? this.DataSource.BottomMeasuredDepth : double.NaN;
    }
    set
    {
      if (this.DataSource == (TubingSection) null || this.BottomMD.AlmostEqual(value))
        return;
      using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
      {
        nuTransaction.Lock((object) this.DataSource);
        this.DataSource.BottomMeasuredDepth = value;
        switch (this.SelectedSectionType)
        {
          case SectionType.Casing:
          case SectionType.Liner:
          case SectionType.OpenHole:
            if (this.CasingCurrentIndex + 1 > 0 && this.CasingCurrentIndex + 1 < this.parentBorehole.CasingSections.Count && this.parentBorehole.CasingSections[this.CasingCurrentIndex + 1].ViewModel is TubingSectionViewModel viewModel
