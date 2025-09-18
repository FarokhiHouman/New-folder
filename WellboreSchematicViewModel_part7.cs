lboreSchematic.SelectedItem;
    if (selectedItem == null)
      return;
    selectedItem.IsLabelVisible = !selectedItem.IsLabelVisible;
  }

  private void ShowWell()
  {
    lock (this._showWellLock)
    {
      if (this._wellboreAdapter == null)
        return;
      this._wellboreAdapter.Attach(this._wellHead);
    }
  }

  public void Refresh(object sender)
  {
    if (sender == this)
      return;
    this._wellboreAdapter.RedrawWell();
  }
}

