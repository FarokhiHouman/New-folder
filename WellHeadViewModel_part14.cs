   if ((object) source == null)
      return;
    WellString wellString = this.DataSource.DefaultBorehole.WellStrings.FirstOrDefault<WellString>((Func<WellString, bool>) (w => w.StreamOutlet == source));
    if (wellString == (WellString) null)
    {
      if (!(this.DataSource.WellStreamOutlet == source))
        return;
      wellString = this.DataSource.DefaultBorehole.CasingWellString;
    }
    this.SelectedStreamOutletIndex = wellString.TubingSectionsType == TubingSectionsType.Casing ? 1 : 0;
    this.OnPropertyChanged("SelectedStreamOutletIndex");
  }

  public event EventHandler ActiveItemChanged;

  public ModelItem ActiveItem
  {
    get => this._activeItem;
    set
    {
      if (this._activeItem != value)
      {
        this._activeItem = value;
        if (this.ActiveItemChanged != null)
          this.ActiveItemChanged((object) this, EventArgs.Empty);
        this.OnPropertyChanged(nameof (ActiveItem));
      }
      DebugLogger.Info($"ActiveItem called with:{(value == (ModelItem) null ? "null" : value.ToString())} ", DebugLogger.LogInfoType.LogInfoWellEditor);
      this.BeginInvoke((Action) (() =>
      {
        int selectedTabIndex = WellViewTabHelper.GetSelectedTabIndex((object) value, this.SelectedIndex);
        this.SelectedIndex = selectedTabIndex;
        NamedItem namedItem = value as NamedItem;
        if (namedItem != (NamedItem) null)
          DebugLogger.Info($"Active item changed:{namedItem.Name} SelectedIndex will be set to:{selectedTabIndex}", DebugLogger.LogInfoType.LogInfoWellEditor);
        else
          DebugLogger.Info($"Active item changed:namedItem is null. SelectedIndex will be set to:{selectedTabIndex}", DebugLogger.LogInfoType.LogInfoWellEditor);
      }), DispatcherPriority.ApplicationIdle);
    }
  }

  public bool IsItemInTheCurrentTab(object item)
  {
    return WellViewTabHelper.GetSelectedTabIndex(item, this.SelectedIndex) == this.SelectedIndex;
  }

  protected overri
