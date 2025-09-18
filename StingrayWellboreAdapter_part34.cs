w.Diameter = pcp2.Diameter;
                    wellboreItemView.IsTopDrive = pcp2.IsTopDrive;
                    wellboreItemView.RodDiameter = pcp2.RodDiameter;
                    baseDownholeItem = (BaseDownholeItem) wellboreItemView;
                    currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
                  }
                }
                else
                {
                  Slb.Production.Engineering.Model.StandardDomain.ESP esp2 = esp1;
                  ESPWellboreItemView wellboreItemView = new ESPWellboreItemView(this.SectionalStyle, equipment1.IsActive);
                  wellboreItemView.Diameter = esp2.Diameter;
                  wellboreItemView.Name = esp2.Name;
                  wellboreItemView.TopDepth = location.TopMeasuredDepth;
                  baseDownholeItem = (BaseDownholeItem) wellboreItemView;
                  currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
                }
              }
              else
              {
                currentString = StingrayWellboreAdapter.GetOutsideTubularStringAtDepthForPerf(wellbore, location.TopMeasuredDepth, (TubularString) null);
                bool splitCompletion = this.AddLabelsToSplitCompletion(perforation, currentString);
                bool isOpenHole = false;
                if (currentString != null && currentString.TubularItems.Count > 0)
                  isOpenHole = currentString.TubularItems.Any<BaseTubularItem>((Func<BaseTubularItem, bool>) (t => !t.IsSelectable));
                baseDownholeItem = (BaseDownholeItem) StingrayWellboreAdapter.NewPerforationSymbol(isOpenHole);
                if (splitCompletion)
                {
                  baseDownholeItem.Label.Visibility = Visibility.Collapsed;
                }
                else
                {
    
