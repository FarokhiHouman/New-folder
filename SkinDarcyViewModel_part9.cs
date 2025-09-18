me == "IPRModelViewModel" || e.PropertyName == "IsConditionalIPRCalculationBasis" || e.PropertyName == "HasSkinConfiguration" || e.PropertyName == "IPRModelTypeOptions")
      return;
    if (e.PropertyName == "Type")
    {
      this.OnPropertyChanged("CompletionTypeMethods");
      this.UpdateCompletionType();
    }
    else if (e.PropertyName == "CompletionDeviationCalculated")
    {
      this.UpdateCompletionDeviation();
      this._skinCalculationPending = true;
    }
    else
    {
      if (((IEnumerable<string>) source).Contains<string>(e.PropertyName))
        return;
      this._skinCalculationPending = true;
    }
  }

  private void GravelPackViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
  {
    if (e.PropertyName == null)
      return;
    this._skinCalculationPending = true;
    this.OnPropertyChanged(e.PropertyName);
  }
}

