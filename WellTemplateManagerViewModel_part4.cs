
      nuTransaction.Lock((object) this._model);
      nuTransaction.Lock((object) this.SelectedItem.DataSource);
      WellHeadAccessor.GetFacadeAccessor(this._domainObjectHost).Delete(this.SelectedItem.DataSource);
      nuTransaction.Commit();
    }
    this.SelectedItem = (WellTemplateViewModel) null;
  }

  private bool CanViewOrEditEnable(object parameter) => parameter is WellTemplateViewModel;

  private void ViewOrEditWellTemplate(object parameter)
  {
    if (!(parameter is WellTemplateViewModel templateViewModel))
      return;
    this._viewService.ShowActiveContextView((object) templateViewModel.DataSource);
  }

  private void TemplateWellsChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
  {
    if (!this._dispatcher.CheckAccess())
    {
      this._dispatcher.Invoke((Delegate) new WellTemplateManagerViewModel.TemplateWellChangedHandlerDelegate(this.TemplateWellsChangedHandler), sender, (object) e);
    }
    else
    {
      bool flag = false;
      if (e.NewItems != null && e.NewItems.Count > 0)
      {
        foreach (WellHead newItem in (IEnumerable) e.NewItems)
        {
          if (newItem.IsTemplate)
          {
            this.WellDisplays.Add(new WellTemplateViewModel(newItem));
            flag = true;
          }
        }
      }
      if (e.OldItems != null && e.OldItems.Count > 0)
      {
        foreach (WellHead oldItem in (IEnumerable) e.OldItems)
        {
          if (oldItem.IsTemplate)
          {
            WellTemplateViewModel instance = this.FindInstance(oldItem);
            if (instance != null)
            {
              this.WellDisplays.Remove(instance);
              flag = true;
            }
          }
        }
      }
      if (!flag)
        return;
      this.OnPropertyChanged("Templates");
    }
  }

  private void StateService_StateChanged(ActionEventArgs<string, object, object> args)
  {
    if (!(args.Key == "topic://InputContex
