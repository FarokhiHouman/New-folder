duction.Engineering.Model.StandardDomain.WellHead) null)
      throw new ArgumentNullException(nameof (wellHead));
    if (stateService == null)
      throw new ArgumentNullException(nameof (stateService));
    if (pluginService == null)
      throw new ArgumentNullException(nameof (pluginService));
    if (contextTabFactory == null)
      throw new ArgumentNullException(nameof (contextTabFactory));
    if (this.validationService != null)
      this.RegisterContent<IDisposable>(this.validationService.QueueInActiveRootItemList((IValidation) this.DataSource));
    this._contextTabFactory = contextTabFactory;
    this.SetWellTypes();
    using (FacadeAccessor.StartPriming())
    {
      FacadeAccessor.PrimeProperties<Slb.Production.Engineering.Model.StandardDomain.WellHead>((IEnumerable<Slb.Production.Engineering.Model.StandardDomain.WellHead>) new Slb.Production.Engineering.Model.StandardDomain.WellHead[1]
      {
        wellHead
      }, (string[]) null);
      List<Borehole> list = FacadeAccessor.PrimeRelationship<Slb.Production.Engineering.Model.StandardDomain.WellHead>((IEnumerable<Slb.Production.Engineering.Model.StandardDomain.WellHead>) new Slb.Production.Engineering.Model.StandardDomain.WellHead[1]
      {
        wellHead
      }, "Boreholes", (string[]) null).OfType<Borehole>().ToList<Borehole>();
      FacadeAccessor.PrimeRelationship<Borehole>((IEnumerable<Borehole>) list, "Trajectory", (string[]) null);
      FacadeAccessor.PrimeProperties<Fluid>(FacadeAccessor.PrimeRelationship<WellString>(FacadeAccessor.PrimeRelationship<Borehole>((IEnumerable<Borehole>) list, "WellStrings", (string[]) null).OfType<WellString>(), "DownholeEquipment", (string[]) null).OfType<Equipment>().OfType<FluidLink>().ToList<FluidLink>().Select<FluidLink, Fluid>((Func<FluidLink, Fluid>) (x => x.GetAssociatedFluid(wellHead.Network != (Network) null ? wellHead.Network.Model : wellHead.Model))).Where<Fluid>((Func<Fluid, bool>) (x => x != (Fluid) null)), (string
