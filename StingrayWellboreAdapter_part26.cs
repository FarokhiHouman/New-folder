ssociateModelObject((FrameworkElement) element1, (ModelItem) tubingSection);
          element1.Length = tubingSection.Length;
          if (flag)
          {
            element1.TopDepth = tubingSection.TopMeasuredDepth;
          }
          else
          {
            if (double.IsNaN(d1))
            {
              d1 = this._wellHead.WellheadDepth;
              if (double.IsNaN(d1))
                d1 = 0.0;
            }
            if (tubingSection.IsTailPipe)
            {
              element1.TopDepth = tubingSection.TopMeasuredDepth;
              element1.IsTopFixed = true;
              element1.IsBottomFixed = true;
              element1.IsLengthFixed = false;
            }
            else
              element1.TopDepth = d1;
          }
          element1.Label.Text = tubingSection.Name;
          if (double.IsNaN(tubingSection.InnerDiameter) || tubingSection.InnerDiameter.AlmostEqual(0.0, double.Epsilon))
          {
            TubularString tubularStringAtDepth = StingrayWellboreAdapter.GetOutsideTubularStringAtDepth(wellbore, element1.TopDepth, stringToIgnore1);
            if (tubularStringAtDepth != null)
              element1.ID = tubularStringAtDepth.GetMaxOD() * 2.0;
          }
          else
            element1.ID = tubingSection.InnerDiameter;
          double outerDiameter = TubingExtension.GetOuterDiameter(tubingSection);
          if (double.IsNaN(outerDiameter) || outerDiameter.AlmostEqual(0.0, double.Epsilon))
            element1.OD = element1.ID * 1.1;
          else
            element1.OD = outerDiameter;
          if (flag && od < tubingSection.InnerDiameter + 2.0 * tubingSection.WallThickness)
            od = tubingSection.InnerDiameter + 2.0 * tubingSection.WallThickness;
          else if (flag && od < element1.OD)
            od = element1.OD;
          if (flag)
          {
            if (stringToIgnore1.ExternalMaterials.Count > 0)
              material = stringToIg
