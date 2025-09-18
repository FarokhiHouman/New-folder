 = currentPoint.TrueVerticalDepth));
    if (this.DataSource.TrajectoryDependantParameter == TrajectoryDependantParameter.TVD && !double.IsNaN(currentPoint.MeasuredDepth) && double.IsNaN(currentPoint.TrueVerticalDepth))
      TransactionHelper.InsideTransaction<TrajectoryMeasurement>(currentPoint, (Action<INuTransaction>) (t => currentPoint.TrueVerticalDepth = currentPoint.MeasuredDepth));
    if (double.IsNaN(currentPoint.HorizontalDisplacement))
      currentPoint.HorizontalDisplacement = 0.0;
    if (this.DataSource.TrajectoryDependantParameter != TrajectoryDependantParameter.Angle || !double.IsNaN(currentPoint.Inclination))
      return;
    TransactionHelper.InsideTransaction<TrajectoryMeasurement>(currentPoint, (Action<INuTransaction>) (t => currentPoint.Inclination = 0.0));
  }

  private void PrepareChart()
  {
    this.BeginInvoke(new Action(this.PrepareChartInternal), DispatcherPriority.Normal);
  }

  private void PrepareChartInternal()
  {
    NumericParameterData dataY = new NumericParameterData(CoreStrings.TrueVerticalDepth_Abbreviation, "True_Vertical_Depth");
    NumericParameterData dataX = new NumericParameterData(CoreStrings.HorizontalDisplacement, "Measured_Depth");
    if (this.TrajectoryMeasurements.Count > 0)
    {
      foreach (ViewModelGridItem<TrajectoryMeasurement> trajectoryMeasurement in (Collection<ViewModelGridItem<TrajectoryMeasurement>>) this.TrajectoryMeasurements)
      {
        if (!double.IsNaN(trajectoryMeasurement.Data.TrueVerticalDepth) && !double.IsNaN(trajectoryMeasurement.Data.HorizontalDisplacement))
        {
          dataY.Add(trajectoryMeasurement.Data.TrueVerticalDepth);
          dataX.Add(trajectoryMeasurement.Data.HorizontalDisplacement);
        }
      }
    }
    this.ChartViewModel.ClearAllSeries();
    this.ChartViewModel.AddSeries(CoreStrings.MeasuredDepthMD, (IParameterData) dataX, (IParameterData) dataY).YAxis.IsInverted = true;
    this.OnPropertyChanged("ChartViewModel");
