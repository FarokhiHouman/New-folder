ption(eventPublisher, (EventHandler<DomainObjectChangeEventArgs>) ((sender, args) => this.RefreshFlowDirection()))));
      this.RefreshFlowDirection();
    }
    if (e.Action != NotifyCollectionChangedAction.Remove)
      return;
    foreach (GasLiftInjection gasLiftInjection1 in e.OldItems.OfType<GasLiftInjection>())
    {
      GasLiftInjection gasLiftInjection = gasLiftInjection1;
      foreach (ISubscription sub in this._gasLiftInjectionSubscriptions.Where<ISubscription>((Func<ISubscription, bool>) (x => (GasLiftInjection) x.Publisher == gasLiftInjection)).ToList<ISubscription>())
        this.UnregisterSubscription(sub);
    }
  }

  private void RefreshFlowDirection()
  {
    this.OnPropertyChanged("FlowDirection");
    this.OnPropertyChanged("IsFlowDirectionReadOnly");
    this.OnPropertyChanged("CheckValveOptions");
  }
}

