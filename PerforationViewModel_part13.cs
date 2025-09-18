ers.Reservoir);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<TrilinearTransientModel, double>((Expression<Func<TrilinearTransientModel, double>>) (m => m.InnerResCompressibility)), PerforationViewModel.TabNumbers.Reservoir);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<TrilinearTransientModel, int>((Expression<Func<TrilinearTransientModel, int>>) (m => m.NumHydraulicFrac)), PerforationViewModel.TabNumbers.Fracture);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<TrilinearTransientModel, double>((Expression<Func<TrilinearTransientModel, double>>) (m => m.HydraulicFracHalf)), PerforationViewModel.TabNumbers.Fracture);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<TrilinearTransientModel, double>((Expression<Func<TrilinearTransientModel, double>>) (m => m.HydraulicFracWidth)), PerforationViewModel.TabNumbers.Fracture);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<TrilinearTransientModel, double>((Expression<Func<TrilinearTransientModel, double>>) (m => m.HydraulicFracPerm)), PerforationViewModel.TabNumbers.Fracture);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<TrilinearTransientModel, double>((Expression<Func<TrilinearTransientModel, double>>) (m => m.HydraulicFracPorosity)), PerforationViewModel.TabNumbers.Fracture);
    dictionary.Add(Slb.Production.Engineering.Model.Infrastructure.Expressions.GetPropertyName<TrilinearTransientModel, double>((Expression<Func<TrilinearTransientModel, double>>) (m => m.HydraulicFracCompressibility)), PerforationViewModel.TabNumbers.Fracture);
    PerforationViewModel._propertyToTab = dictionary;
    PerforationViewModel._viewModelProperties = new HashSet<string>()
    {
      nameof (SandProductionRatio),
      nameof (SandGrainSiz
