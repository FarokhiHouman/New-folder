ompletionModel, double>>) (m => m.PerforationShotDensity)), PerforationViewModel.TabNumbers.Skin);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<DistributedCompletionModel, double>((Expression<Func<DistributedCompletionModel, double>>) (m => m.PerforationDiameter)), PerforationViewModel.TabNumbers.Skin);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<DistributedCompletionModel, double>((Expression<Func<DistributedCompletionModel, double>>) (m => m.PerforationLength)), PerforationViewModel.TabNumbers.Skin);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<DistributedCompletionModel, double>((Expression<Func<DistributedCompletionModel, double>>) (m => m.GravelPackPermeability)), PerforationViewModel.TabNumbers.Skin);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<DistributedCompletionModel, double>((Expression<Func<DistributedCompletionModel, double>>) (m => m.GravelPackTunnel)), PerforationViewModel.TabNumbers.Skin);
    dictionary.Add("WaterSaturation", PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add("BackPressureSlopeN", PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add("LiquidFlowRate", PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add("GasFlowRate", PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add("OilFlowRate", PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add("WaterFlowRate", PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add("AssociatedFluidNull", PerforationViewModel.TabNumbers.Fluid);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<FluidLink, double>((Expression<Func<FluidLink, double>>) (m => m.ConedGasSG)), PerforationViewModel.TabNumbers.Fluid);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetProp
