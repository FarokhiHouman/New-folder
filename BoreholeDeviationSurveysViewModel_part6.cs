talLength()));
    }
  }

  public string SelectedCalculationMethod
  {
    get
    {
      if (this.DataSource == (WellTrajectory) null)
        return string.Empty;
      return !this.DataSource.CalculateUsingTangentialMethod ? CoreStrings.CalculateMethod_MinimumCurvature : CoreStrings.CalculateMethod_Tangential;
    }
    set
    {
      if (value.Equals(this.DataSource.CalculateUsingTangentialMethod ? CoreStrings.CalculateMethod_Tangential : CoreStrings.CalculateMethod_MinimumCurvature) || string.IsNullOrWhiteSpace(value) || !(value == CoreStrings.CalculateMethod_MinimumCurvature) && !(value == CoreStrings.CalculateMethod_Tangential))
        return;
      bool flag = value.Equals(CoreStrings.CalculateMethod_Tangential);
      if (this.DataSource != (WellTrajectory) null && flag != this.DataSource.CalculateUsingTangentialMethod)
        this.SetValue("CalculateUsingTangentialMethod", (object) flag);
      this.OnPropertyChanged(nameof (SelectedCalculationMethod));
      this.CalculateTrajectoryValues();
    }
  }

  public DeviationSurveyType SelectedSurveyType
  {
    get => this.DataSource.SurveyType;
    set
    {
      if (!(this.DataSource != (WellTrajectory) null) || value == this.SelectedSurveyType)
        return;
      this.SetValue("SurveyType", (object) value);
      this.OnPropertyChanged(nameof (SelectedSurveyType));
    }
  }

  public Borehole Borehole => this._parent != null ? this._parent.DataSource : (Borehole) null;

  private List<TrajectoryMeasurement> GetTrajectoryMeasurementsTableValidNodes()
  {
    List<TrajectoryMeasurement> measurementsTableValidNodes = new List<TrajectoryMeasurement>();
    measurementsTableValidNodes.AddRange((IEnumerable<TrajectoryMeasurement>) this.TrajectoryMeasurements.Where<ViewModelGridItem<TrajectoryMeasurement>>((Func<ViewModelGridItem<TrajectoryMeasurement>, bool>) (x => !double.IsNaN(x.Data.TrueVerticalDepth))).Select<ViewModelGridItem<TrajectoryMeasurement>, Traject
