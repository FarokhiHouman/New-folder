ession<Func<object>>) (() => this.BoreholeDiameterToolTip));
  }

  private bool IsTransactionPending()
  {
    INuTransaction current = NuDataManager.TransactionManager.GetCurrent(NuDataManager.TransactionManager.DefaultTransactionContext);
    if (current == null)
      return false;
    this._pendingTransactionMap.GetOrAdd(current, (Func<INuTransaction, ISubscription>) (x => this.RegisterSubscription((ISubscription) new TransactionCompletedSubscription(x.Manager, new EventHandler<NuTransactionEventArgs>(this.Transaction_Completed)))));
    return true;
  }

  private void Transaction_Completed(object sender, NuTransactionEventArgs e)
  {
    ISubscription sub;
    if (!this._pendingTransactionMap.TryRemove(e.Transaction, out sub))
      return;
    this.UnregisterSubscription(sub);
  }

  private void CasingSection_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    string[] strArray = new string[5]
    {
      "BoreholeDiameter",
      "InnerDiameter",
      "TopMeasuredDepth",
      "BottomMeasuredDepth",
      "Length"
    };
    if (!e.PropertyNames.Any<string>(new Func<string, bool>(((Enumerable) strArray).Contains<string>)))
      return;
    this.OnPropertyChanged("WellboreDiameter");
  }

  private void Sections_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    this.RegisterCasingSubscription();
  }
}

