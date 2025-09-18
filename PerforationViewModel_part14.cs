e),
      "Name",
      nameof (ItemName)
    };
    PerforationViewModel._fluidEntryGeometryProfileMappings = new Dictionary<FluidEntryType, List<GeometryProfileType>>();
    foreach (FluidEntryType key in Enum.GetValues(typeof (FluidEntryType)))
    {
      List<GeometryProfileType> geometryProfileTypeList = new List<GeometryProfileType>();
      switch (key)
      {
        case FluidEntryType.SinglePoint:
          geometryProfileTypeList.Add(GeometryProfileType.Vertical);
          geometryProfileTypeList.Add(GeometryProfileType.Horizontal);
          break;
        case FluidEntryType.Distributed:
          geometryProfileTypeList.Add(GeometryProfileType.Horizontal);
          break;
      }
      PerforationViewModel._fluidEntryGeometryProfileMappings.Add(key, geometryProfileTypeList);
    }
    PerforationViewModel._IPRModelTypeModeMappings = new Dictionary<PerforationViewModel.CompletionFluidEntryGeometryProfileMode, List<IPRModelType>>();
    foreach (PerforationViewModel.CompletionFluidEntryGeometryProfileMode key in Enum.GetValues(typeof (PerforationViewModel.CompletionFluidEntryGeometryProfileMode)))
    {
      List<IPRModelType> iprModelTypeList = new List<IPRModelType>();
      switch (key)
      {
        case PerforationViewModel.CompletionFluidEntryGeometryProfileMode.SinglePointVertical:
          iprModelTypeList.Add(IPRModelType.WellPI);
          iprModelTypeList.Add(IPRModelType.VogelEquation);
          iprModelTypeList.Add(IPRModelType.FetkovitchEquation);
          iprModelTypeList.Add(IPRModelType.JonesEquation);
          iprModelTypeList.Add(IPRModelType.BackPressureEquation);
          iprModelTypeList.Add(IPRModelType.DarcyEquation);
          iprModelTypeList.Add(IPRModelType.ForchheimerEquation);
          iprModelTypeList.Add(IPRModelType.HydraulicFracture);
          break;
        case PerforationViewModel.CompletionFluidEntryGeometryProfileMode.SinglePointHorizontal:
          iprModelTypeLis
