holeTubingView_DataContextChanged(
    object sender,
    DependencyPropertyChangedEventArgs e)
  {
    if (this.DataContext == null)
      return;
    if (e.OldValue is BoreholeTubingViewModel oldValue)
      oldValue.DisposeNotificationRequest -= new EventHandler(this.ViewModel_DisposeNotificationRequest);
    if (!(e.NewValue is BoreholeTubingViewModel newValue))
      return;
    newValue.DisposeNotificationRequest += new EventHandler(this.ViewModel_DisposeNotificationRequest);
    this._validationService = ServiceDirectory.GetService<IValidationService>();
    if (this._validationService != null)
      this._validationService.ValidationCompleted += new EventHandler<ValidateArgs>(this.ValidationService_OnValidationCompleted);
    IDomainObjectHost service = ServiceDirectory.GetService<IDomainObjectHost>();
    if (service == null)
      return;
    TubingSectionAccessor.GetFacadeAccessor(service).Deleted += new EventHandler<DomainObjectEventGroup>(this.WllStringCreatedDeleted);
    TubingSectionAccessor.GetFacadeAccessor(service).Created += new EventHandler<DomainObjectEventGroup>(this.WllStringCreatedDeleted);
  }

  private void WllStringCreatedDeleted(object sender, DomainObjectEventGroup e)
  {
    InvokeMethodHelper.BeginInvoke(new Action(this.ValidateControls), DispatcherPriority.Background);
  }

  private void ViewModel_DisposeNotificationRequest(object sender, EventArgs e)
  {
    if (!(sender is BoreholeTubingViewModel boreholeTubingViewModel))
      return;
    boreholeTubingViewModel.DisposeNotificationRequest -= new EventHandler(this.ViewModel_DisposeNotificationRequest);
    if (this._validationService != null)
      this._validationService.ValidationCompleted -= new EventHandler<ValidateArgs>(this.ValidationService_OnValidationCompleted);
    IDomainObjectHost service = ServiceDirectory.GetService<IDomainObjectHost>();
    if (service == null)
      return;
    TubingSectionAccessor.GetFacadeAccessor(service).De
