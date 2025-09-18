1 && viewModel1.SelectedSectionType == SectionType.OpenHole)
            {
              viewModel1.TopMD = value;
              break;
            }
            break;
          case SectionType.Tubing:
          case SectionType.TailPipe:
            if (this.TubingCurrentIndex + 1 > 0 && this.TubingCurrentIndex + 1 < this.parentBorehole.TubingSections.Count && this.parentBorehole.TubingSections[this.TubingCurrentIndex + 1].ViewModel is TubingSectionViewModel viewModel2)
            {
              viewModel2.TopMD = value;
              break;
            }
            break;
        }
        nuTransaction.Commit();
      }
      this.OnPropertyChanged("TopMeasuredDepth");
      this.OnPropertyChanged("Length");
      this.OnPropertyChanged(nameof (BottomMD));
      this.OnPropertyChanged("IsFromMdReadOnly");
    }
  }

  private bool CanAcceptToMd(double toMd)
  {
    return this.DataSource.SectionType != SectionType.TailPipe || !toMd.IsNaN() && (!this.DataSource.WellString.Borehole.WellHead.WellheadDepth.IsNotNaN() || toMd > this.DataSource.WellString.Borehole.WellHead.WellheadDepth);
  }

  public double TopMD
  {
    get
    {
      return !(this.DataSource != (TubingSection) null) ? double.NaN : this.DataSource.TopMeasuredDepth;
    }
    set
    {
      if (this.DataSource == (TubingSection) null || this.TopMD.AlmostEqual(value) || !this.CanAcceptToMd(value))
        return;
      this.SetValue("TopMeasuredDepth", (DomainObjectViewModel<TubingSection>.SetMethod) (() => this.DataSource.UpdateTopMD(value)));
      this.OnPropertyChanged("Length");
      this.OnPropertyChanged("BottomMeasuredDepth");
      this.OnPropertyChanged(nameof (TopMD));
      this.OnPropertyChanged("IsFromMdReadOnly");
    }
  }

  public bool IsFromMdReadOnly
  {
    get
    {
      return this.DataSource.IsTailPipe && !this.DataSource.Equals((OdtDomainObjectBase) this.DataSource.WellString.FirstTailPipe);
    }
  }

  public do
