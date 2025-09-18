l isSupported = this.IsSupported;
    if (isSupported == this._previousCanExecute)
      return isSupported;
    this._previousCanExecute = isSupported;
    this._canExecuteChanged((object) this, (EventArgs) null);
    return isSupported;
  }

  public void Execute(object parameter)
  {
  }

  public event EventHandler CanExecuteChanged
  {
    add
    {
      CommandManager.RequerySuggested += value;
      this._canExecuteChanged += value;
    }
    remove
    {
      CommandManager.RequerySuggested -= value;
      this._canExecuteChanged -= value;
    }
  }

  private void OnStateChanged(ActionEventArgs<string, object, object> e)
  {
    if (!(e.Key == "topic://WellStatusChanged"))
      return;
    InvokeMethodHelper.BeginInvoke((Action) (() => this.CanExecute((object) null)), DispatcherPriority.Background);
  }

  public void Dispose() => this._stateChangedEventSubscription?.Dispose();

  public enum SupportedStatusType
  {
    Advanced,
    Conventional,
  }
}

