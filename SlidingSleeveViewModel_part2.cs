ect sender, DomainObjectChangeEventArgs e)
  {
    foreach (string propertyName in e.PropertyNames)
    {
      this.OnPropertyChanged(propertyName);
      this.OnPropertyChanged("IsActiveUI");
    }
  }
}

