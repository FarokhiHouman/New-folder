         if (!list.Last<TrajectoryMeasurement>().Equals((OdtDomainObjectBase) other))
                  {
                    other.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.OnTrajectoryMeasurementChanged);
                    nuTransaction.Lock((object) sortedMeasurements, (object) other);
                    this._measurementsAccessor.Delete(other);
                    flag = true;
                  }
                }
                if (flag)
                {
                  nuTransaction.Commit();
                  sortedMeasurements = this.DataSource.GetSortedMeasurements();
                }
              }
            }
            if (sortedMeasurements.Count > 0)
            {
              TrajectoryMeasurement trajectoryMeasurement2 = sortedMeasurements.FirstOrDefault<TrajectoryMeasurement>();
              if (trajectoryMeasurement2 != (TrajectoryMeasurement) null && !trajectoryMeasurement2.TrueVerticalDepth.AlmostEqual(value))
              {
                INuTransaction nuTransaction;
                using (nuTransaction = NuDataManager.NewTransaction())
                {
                  nuTransaction.Lock((object) trajectoryMeasurement2);
                  trajectoryMeasurement2.TrueVerticalDepth = value;
                  trajectoryMeasurement2.MeasuredDepth = value;
                  trajectoryMeasurement2.HorizontalDisplacement = 0.0;
                  trajectoryMeasurement2.Azimuth = double.NaN;
                  nuTransaction.Commit();
                }
              }
            }
          }
          this.InitializeTrajectoryMeasurements();
        }
      }
      this._parent.WellheadDepth = value;
      this.OnPropertyChanged(nameof (WellheadDepth));
      this.OnPropertyChanged("TrajectoryMeasurements");
    }
  }

  public double BottomDepth
  {
    get
    {
      return this._parent.DataSource.WellStrings.Max<WellString>((Func<WellString, double>) (ws => ws.CalcTo
