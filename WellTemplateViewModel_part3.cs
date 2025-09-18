reStrings.Rename, CoreStrings.RenameTemplateWarningNull);
      if (DataHelper.IsNullObject((IDomainObject) this.DataSource))
        return;
      if (!this.IsNameUnique(value))
      {
        this._viewService.Error(CoreStrings.Rename, CoreStrings.RenameTemplateWarningExist);
      }
      else
      {
        using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
        {
          nuTransaction.Lock((object) this.DataSource);
          this._name = value;
          this.DataSource.Name = this._name;
          nuTransaction.Commit();
        }
      }
    }
  }

  public override ImageSource Image
  {
    get
    {
      return !this.IsUserDefined ? ImageKey.WellTemplateSystem.ToImageSource(ImageSizes.Image48) : ImageKey.WellTemplateUser.ToImageSource(ImageSizes.Image48);
    }
  }

  private void OnDelete()
  {
    if (!this._viewService.Warn(CoreStrings.Delete, string.Format(CoreStrings.DeleteItemName, (object) this.DataSource.Name)))
      return;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      nuTransaction.Lock((object) this.DataSource);
      WellHeadAccessor.GetFacadeAccessor(this._domainObjectHost).Delete(this.DataSource);
      nuTransaction.Commit();
    }
  }

  private bool IsNameUnique(string name)
  {
    foreach (WellHead well in (IEnumerable<WellHead>) DataHelper.GetCurrentWorkspaceModel().DefaultNetwork.Wells)
    {
      if ((well.IsBuiltinTemplate || well.IsTemplate) && well.Name == name.Trim())
        return false;
    }
    return true;
  }

  private void WellChanged(object sender, DomainObjectChangeEventArgs args)
  {
    bool flag = false;
    foreach (string propertyName in args.PropertyNames)
    {
      if (propertyName.Equals("Name"))
        this._name = this.DataSource.Name;
      flag = true;
    }
    if (!flag)
      return;
    this.OnPropertyChanged("Name");
  }
}

