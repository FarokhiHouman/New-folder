nds.CreateNewWithTemplateAndLaunch, (object) null, ImageKey.New, string.Format(CoreStrings.NewType_Tooltip, (object) CoreStrings.Well.ToLower()), ButtonSize.Medium)));
  }

  private void UpdateWellSelector(string key, object data)
  {
    switch (key)
    {
      case "topic://InputContext":
        if (((IEnumerable<object>) this._stateService.InputContext ?? Enumerable.Empty<object>()).Count<object>() == 1 && this._stateService.ActiveContext.TryResolveAs<WellHead>() != (WellHead) null)
        {
          NamedItemViewModel newValue = this.Items.FirstOrDefault<NamedItemViewModel>((Func<NamedItemViewModel, bool>) (item => item.DataSource.DurableId == this._stateService.ActiveContext));
          if (newValue == null)
          {
            this.BeginRefresh();
            this.EndRefresh();
            newValue = this.Items.FirstOrDefault<NamedItemViewModel>((Func<NamedItemViewModel, bool>) (item => item.DataSource.DurableId == this._stateService.ActiveContext));
          }
          this.SetSelectedValueInternal(newValue);
          this.BeginRefresh();
          this.EndRefresh();
          break;
        }
        this.SetSelectedValueInternal((NamedItemViewModel) null);
        break;
      case "topic://WorkspaceRootReady":
        this.BeginRefresh();
        break;
    }
    if (!(key == "topic://WorkspaceTypeChanged") && !(key == "topic://WorkspaceRootReady"))
      return;
    this._stateService.SetInputContextFilter((data is WorkspaceType workspaceType ? workspaceType : WorkspaceType.Unknown) == WorkspaceType.Well ? (IInputContextFilter) this : (IInputContextFilter) null);
  }

  private void OnStateChanged(ActionEventArgs<string, object, object> e)
  {
    if (e.Source != this)
      this.UpdateWellSelector(e.Key, e.Data);
    if (!(e.Key == "topic://WorkspaceClosed"))
      return;
    this.Clear();
  }

  private void TransactionManager_TransactionCompleted(object sender, NuTransactionEventArgs e)
  {
    
