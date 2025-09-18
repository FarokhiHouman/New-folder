gs.MustBeSpecified;
  }

  private bool? IsLast()
  {
    if (this.DataSource == (TrajectoryMeasurement) null)
      return new bool?();
    WellTrajectory wellTrajectory = this.DataSource.WellTrajectory;
    if (wellTrajectory == (WellTrajectory) null)
      return new bool?();
    List<TrajectoryMeasurement> sortedMeasurements = wellTrajectory.GetSortedMeasurements();
    return sortedMeasurements == null || sortedMeasurements.Count <= 0 ? new bool?() : new bool?(sortedMeasurements.IndexOf(this.DataSource) == sortedMeasurements.Count - 1);
  }
}

