ad == (Slb.Production.Engineering.Model.StandardDomain.WellHead) null || this._wellHead.Boreholes.Count == 0)
          return;
        Borehole borehole = this._wellHead.Boreholes[0];
        wellbore.Name = borehole.Name;
        this.AddWatch((ModelItem) this._wellHead);
        this.AddWatch((ModelItem) borehole.Trajectory);
        this.AddWatch((INotifyCollectionChanged) borehole.Trajectory.Measurements);
        if (borehole.Trajectory.SurveyType == DeviationSurveyType.VerticalDeviation)
        {
          wellbore.Trajectory.Stations.Clear();
        }
        else
        {
          using (FacadeAccessor.StartPriming())
          {
            WellTrajectoryAccessor.PrimeMeasurements((IEnumerable<WellTrajectory>) new WellTrajectory[1]
            {
              borehole.Trajectory
            }, (string[]) null);
            foreach (TrajectoryMeasurement trajectoryMeasurement in new List<TrajectoryMeasurement>((IEnumerable<TrajectoryMeasurement>) borehole.Trajectory.GetSortedMeasurements()))
            {
              this.AddWatch((ModelItem) trajectoryMeasurement);
              TrajectoryStation trajectoryStation = new TrajectoryStation();
              trajectoryStation.MD = trajectoryMeasurement.MeasuredDepth;
              trajectoryStation.TVD = trajectoryMeasurement.TrueVerticalDepth;
              double d1 = StingrayWellboreAdapter.ConvertAngleForDisplay(trajectoryMeasurement.Azimuth);
              if (!double.IsNaN(d1))
                trajectoryStation.Azimuth = d1;
              double d2 = StingrayWellboreAdapter.ConvertAngleForDisplay(trajectoryMeasurement.Inclination);
              if (!double.IsNaN(d2))
                trajectoryStation.Inclination = d2;
              if (!double.IsNaN(trajectoryStation.MD) && !double.IsNaN(trajectoryStation.TVD))
                wellbore.Trajectory.Stations.Add(trajectoryStation);
            }
          }
          wellbore.Trajectory.Is2DSurvey = borehole.Traject
