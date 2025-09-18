em(key);
      this.RedrawWellAlreadyInProgress = false;
    }
  }

  private void DataItemChanged(object sender, DomainObjectChangeEventArgs e)
  {
    this.RedrawWell(sender);
  }

  private void ConnectionChanged(object sender, DomainObjectChangeEventArgs e) => this.RedrawWell();

  private void EquipmentChanged(object sender, DomainObjectChangeEventArgs e) => this.RedrawWell();

  public bool ContainsKey(ModelItem key) => this._modelUiMap.ContainsKey(key);

  public FrameworkElement GetElement(ModelItem key) => this._modelUiMap[key];

  public void RefreshFlowPath() => this._wellHead?.RefreshFlowPath();

  public void Redraw() => this.DrawWellHeadImpl();

  private delegate void DrawDelegate();
}

