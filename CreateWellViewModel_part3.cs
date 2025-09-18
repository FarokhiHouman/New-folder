rvice<IPresentationService>();
    if (service1 == null)
      return this.ResultWell != (WellHead) null;
    if (this.SelectedTemplate == null || this._network == (Network) null)
      return this.ResultWell != (WellHead) null;
    if (this.HasError())
      return false;
    DurableId droid = (DurableId) null;
    IWellLayoutSyncService service2 = ServiceDirectory.GetService<IWellLayoutSyncService>();
    service2.FireBeforeWellCreatedEvent();
    if (this.SelectedTemplate.TemplateWell != (WellHead) null)
    {
      droid = service1.CreateFromTemplate(this.SelectedTemplate.TemplateWell);
      this.PostProcessAfterWellCreated(service2, droid);
    }
    else if (string.IsNullOrWhiteSpace(this.ImportWellPath))
    {
      droid = service1.CreateWithoutTemplate(this._network);
      this.PostProcessAfterWellCreated(service2, droid);
    }
    else if (this.CanImportWell)
      droid = service1.ImportFromPath(this.ImportWellPath);
    if (droid != (DurableId) null)
      this.ResultWell = FacadeAccessor.Resolve<WellHead>(droid);
    return this.ResultWell != (WellHead) null;
  }

  private void OnImportWell(object path)
  {
    string path1 = path?.ToString();
    if (string.IsNullOrWhiteSpace(path1) || !File.Exists(path1))
      return;
    this.ImportWellPath = path1;
  }

  private void PostProcessAfterWellCreated(IWellLayoutSyncService syncService, DurableId droid)
  {
    if (!(this._commandType == "CommandType_InputTree") && !(this._commandType == "CommandType_Toolbar"))
      return;
    syncService.PostProcessAfterWellCreated(droid);
  }
}

