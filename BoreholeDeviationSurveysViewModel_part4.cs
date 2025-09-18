)
        return;
      this.SelectedCalculationMethod = CoreStrings.CalculateMethod_Tangential;
    }
  }

  public double WellheadDepth
  {
    get => this._parent == null ? double.NaN : this._parent.WellheadDepth;
    set
    {
      if (double.IsNaN(value) || this._parent == null || this.WellheadDepth.AlmostEqual(value) || Math.Abs(value) > 10000000.0)
        return;
      if (this.DataSource.Measurements != null && this.DataSource.Measurements.Count > 0 && !value.Equals(double.NaN))
      {
        List<TrajectoryMeasurement> sortedMeasurements = this.DataSource.GetSortedMeasurements();
        TrajectoryMeasurement trajectoryMeasurement1 = sortedMeasurements.FirstOrDefault<TrajectoryMeasurement>();
        if (trajectoryMeasurement1 != (TrajectoryMeasurement) null && !trajectoryMeasurement1.TrueVerticalDepth.AlmostEqual(value))
        {
          if (trajectoryMeasurement1.TrueVerticalDepth > value)
          {
            INuTransaction nuTransaction;
            using (nuTransaction = NuDataManager.NewTransaction())
            {
              nuTransaction.Lock((object) trajectoryMeasurement1);
              trajectoryMeasurement1.MeasuredDepth = value;
              trajectoryMeasurement1.TrueVerticalDepth = value;
              trajectoryMeasurement1.HorizontalDisplacement = 0.0;
              trajectoryMeasurement1.Inclination = 0.0;
              nuTransaction.Commit();
            }
          }
          else
          {
            bool flag = false;
            List<TrajectoryMeasurement> list = sortedMeasurements.Where<TrajectoryMeasurement>((Func<TrajectoryMeasurement, bool>) (x => x.TrueVerticalDepth <= value)).ToList<TrajectoryMeasurement>();
            if (list.Count > 1)
            {
              INuTransaction nuTransaction;
              using (nuTransaction = NuDataManager.NewTransaction())
              {
                foreach (TrajectoryMeasurement other in list)
                {
         
