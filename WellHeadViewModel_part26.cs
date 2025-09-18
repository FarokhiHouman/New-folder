endencyObject == null || data == null)
    {
      NuLogger.Warn($"WellRibbonTools.InsertElementDragged: Invalid arguments (sender:'{dependencyObject}' parameter:'{data}')");
    }
    else
    {
      BaseWellboreItem wellboreItem = data.CreateWellboreItem();
      if (wellboreItem == null)
        return;
      if (wellboreItem is ICreateWellStringItem createWellStringItem)
        createWellStringItem.WellHead = this.DataSource;
      if (wellboreItem is IDragItem dragItem)
        dragItem.IsDragging = true;
      try
      {
        int num = (int) DragDrop.DoDragDrop((DependencyObject) sender, (object) new DragAndDropContainer(wellboreItem), DragDropEffects.All);
      }
      finally
      {
        if (dragItem != null)
          dragItem.IsDragging = false;
      }
    }
  }

  public void Register(IWellViewNavigateFromValidation navigator)
  {
    lock (this._navigators)
      this._navigators[navigator.GetType()] = navigator;
  }

  public void Refresh(object sender)
  {
    foreach (IWellRefresh refreshViewModel in this._refreshViewModels)
      refreshViewModel.Refresh(sender);
  }

  public void RecalculateLayout()
  {
    if (this.IsDisposed)
      return;
    if (this.IsSurfaceEquipmentSelected)
      this.BeginInvoke((Action) (() =>
      {
        if (this.IsDisposed)
          return;
        this.BranchViewModel?.RecalcLayout();
      }), DispatcherPriority.Background);
    else
      this.NeedRecalculateLayout = true;
  }
}

