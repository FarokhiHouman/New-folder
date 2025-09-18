tcherPriority.ApplicationIdle);
  }

  private void TriggerValidationErrors()
  {
    foreach (string viewModelProperty in PerforationViewModel._viewModelProperties)
      this.OnPropertyChanged(viewModelProperty);
  }

  private enum CompletionFluidEntryGeometryProfileMode
  {
    SinglePointVertical,
    SinglePointHorizontal,
    DistributedVertical,
    DistributedHorizontal,
  }

  private enum TabNumbers
  {
    Reservoir,
    Fracture,
    Skin,
    Sand,
    Fluid,
    Something,
  }
}

