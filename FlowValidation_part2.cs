ug>(section.TopMeasuredDepth, section.BottomMeasuredDepth);
  }

  protected bool HasEquipmentInRange<T>(double start, double end) where T : Equipment
  {
    return this.EquipmentDepths<T>().Any<double>((Func<double, bool>) (l => start <= l && end >= l));
  }

  public abstract bool CanAddFlowSection();
}

