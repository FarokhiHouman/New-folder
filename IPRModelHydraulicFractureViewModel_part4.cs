mainObjectChangeEventArgs e)
  {
    if (!e.PropertyNames.Contains<string>("UseVogelBelowBubblepoint") && !e.PropertyNames.Contains<string>("IsGasModel"))
      return;
    this.OnPropertyChanged((Expression<Func<object>>) (() => (object) this.IsVogelBelowBubblePoint));
  }
}

