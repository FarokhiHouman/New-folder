OnPropertyChanged("TickVisibility");
    this.OnPropertyChanged("CrossVisibility");
  }

  public string Name => this.DataSource.Name;

  public Visibility TextVisibility => !this.showText ? Visibility.Collapsed : Visibility.Visible;

  public Visibility TickVisibility
  {
    get => !this.isValid || !this.showValidation ? Visibility.Collapsed : Visibility.Visible;
  }

  public Visibility CrossVisibility
  {
    get => this.isValid || !this.showValidation ? Visibility.Collapsed : Visibility.Visible;
  }
}

