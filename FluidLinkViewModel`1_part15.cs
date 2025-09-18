bject sender, PropertyChangedEventArgs e)
  {
    Zone associatedZone = this.DataSource.GetAssociatedZone();
    if (!object.Equals((object) associatedZone, (object) this.AssociatedZone))
      this.AssociatedZone = associatedZone;
    this.OnPropertyChanged("CompletionDeviationCalculated");
    this.OnPropertyChanged("CasingIdCalculated");
    this.OnPropertyChanged("Type");
    this.UpdateListeners();
    if ((object) (this.DataSource.CompModel as TrilinearTransientModel) == null)
      return;
    this.NeedIprUpdate = true;
    this.UpdateIPR(true);
  }

  private void DataSource_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    if (this.LocationViewModel != null && e.PropertyNames.Contains<string>("FluidEntryType"))
      this.LocationViewModel.RefreshUIValidationForMeasuredDepth();
    if ((e.PropertyNames.Contains<string>("AssociatedFluid") || e.PropertyNames.Contains<string>("AssociatedBlackOilFluid") || e.PropertyNames.Contains<string>("AssociatedCompositionalFluid")) && (FluidLink) this.DataSource != (FluidLink) null && this.DataSource.GetAssociatedFluid(this._model) != (Fluid) null)
      this.ReflectCurrentFluidForValidation();
    if ((FluidLink) this.DataSource == (FluidLink) null)
      return;
    string propertyName1 = Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<Perforation, double>((Expression<Func<Perforation, double>>) (x => x.ReservoirPressure));
    string propertyName2 = Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<Perforation, double>((Expression<Func<Perforation, double>>) (x => x.ReservoirTemperature));
    if (e.PropertyNames.Contains<string>(propertyName1))
    {
      this.OnPropertyChanged((Expression<Func<object>>) (() => (object) this.Pressure));
      ++this.RefreshTestPointsValidation;
    }
    if (e.PropertyNames.Contains<string>(propertyName2))
      this.OnPropertyChanged((Expression<Func<object>>) (() => (object) this.Temper
