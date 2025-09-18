TubingSections.First<ViewModelGridItem<TubingSection>>().ViewModel is TubingSectionViewModel viewModel1)
        {
          double bottomMd = viewModel1.BottomMD;
          viewModel1.TopMD = this.WellheadDepth;
          viewModel1.BottomMD = bottomMd;
        }
        if (this.BoreholeTubingViewModel.CasingSections.Count > 0)
        {
          foreach (ViewModelGridItem<TubingSection> casingSection in (Collection<ViewModelGridItem<TubingSection>>) this.BoreholeTubingViewModel.CasingSections)
          {
            if (casingSection.ViewModel is TubingSectionViewModel viewModel2 && casingSection.Data.SectionType == SectionType.Casing)
            {
              double bottomMd = viewModel2.BottomMD;
              viewModel2.TopMD = this.WellheadDepth;
              viewModel2.BottomMD = bottomMd;
            }
          }
        }
        this.BoreholeTubingViewModel.InitializeSections();
      }
      this.OnPropertyChanged(nameof (WellheadDepth));
    }
  }
}

