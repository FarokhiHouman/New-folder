ion.Engineering.Model.Infrastructure.Expressions.GetPropertyName<DarcyCompletionModel, double>((Expression<Func<DarcyCompletionModel, double>>) (m => m.ReservoirPermeability)), PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add(nameof (SandProductionRatio), PerforationViewModel.TabNumbers.Sand);
    dictionary.Add(nameof (SandGrainSize), PerforationViewModel.TabNumbers.Sand);
    dictionary.Add("RateDependentLiquidSkin", PerforationViewModel.TabNumbers.Skin);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<Perforation, double>((Expression<Func<Perforation, double>>) (m => m.ShotDensity)), PerforationViewModel.TabNumbers.Skin);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<Perforation, double>((Expression<Func<Perforation, double>>) (m => m.Diameter)), PerforationViewModel.TabNumbers.Skin);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<Perforation, double>((Expression<Func<Perforation, double>>) (m => m.PenetrationDepth)), PerforationViewModel.TabNumbers.Skin);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<Perforation, double>((Expression<Func<Perforation, double>>) (m => m.PhaseAngle)), PerforationViewModel.TabNumbers.Skin);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<DarcyCompletionModel, double>((Expression<Func<DarcyCompletionModel, double>>) (m => m.CompactedZonePermeability)), PerforationViewModel.TabNumbers.Skin);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<DarcyCompletionModel, double>((Expression<Func<DarcyCompletionModel, double>>) (m => m.CompactedZonePermRatio)), PerforationViewModel.TabNumbers.Skin);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<DarcyCompletionModel, double>((Expression<Func<Da
