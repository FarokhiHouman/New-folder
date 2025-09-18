ature));
    if (e.PropertyNames.Contains<string>("CompletionTestType"))
      this.CheckPwsInitialValues();
    if (!e.PropertyNames.Contains<string>("IPRModelType"))
      this.RecalculateCompletionModelValue();
    if (!e.PropertyNames.Contains<string>("UseTestData"))
      return;
    this.OnPropertyChanged("TestPoints");
    this.OnPropertyChanged("CompletionTestType");
  }

  private void CheckPwsInitialValues()
  {
    if (this.DataSource.CompletionTestType != CompletionTestType.Isochronal)
      return;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      double reservoirPressure = this.DataSource.CompModel.GetFormationPressure();
      foreach (CompletionTestPoint completionTestPoint in this.DataSource.TestData.Where<CompletionTestPoint>((Func<CompletionTestPoint, bool>) (x => x.IsDefined(this.DataSource.CompModel.IsGasCompletion, (FluidLink) this.DataSource, reservoirPressure, false))))
      {
        if (!completionTestPoint.StaticReservoirPressure.IsNotNaN())
        {
          nuTransaction.Lock((object) completionTestPoint);
          completionTestPoint.StaticReservoirPressure = reservoirPressure;
        }
      }
      nuTransaction.Commit();
    }
  }

  private void Model_Changed(
    object sender,
    DomainObjectChangeEventArgs domainObjectChangeEventArgs)
  {
    if (!this.ShouldFireEventOnModelChange(domainObjectChangeEventArgs))
      return;
    this.OnPropertyChanged(domainObjectChangeEventArgs.PropertyNames.First<string>());
  }

  private void ReflectCurrentFluidForValidation()
  {
    foreach (ISubscription changesSubscription in this._fluidChangesSubscriptions)
      this.UnregisterSubscription(changesSubscription);
    foreach (ModelItem key in this._validationStatusDictionary.Keys.OfType<Fluid>())
      this._validationStatusDictionary.TryRemove(key, out bool _);
    Fluid fluid = this.AssociatedZone == (Zone) null ? this.DataSource.GetAssociatedFluid(thi
