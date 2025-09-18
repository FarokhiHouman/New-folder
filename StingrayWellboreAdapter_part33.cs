DownholeItem.TopDepth = location.TopMeasuredDepth;
                          currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
                        }
                      }
                      else
                      {
                        GasLiftInjection gasLiftInjection2 = gasLiftInjection1;
                        baseDownholeItem = (BaseDownholeItem) new GasLiftInjectionWellboreItemView(this.SectionalStyle, gasLiftInjection1.IsActive);
                        baseDownholeItem.Name = gasLiftInjection2.Name;
                        baseDownholeItem.TopDepth = location.TopMeasuredDepth;
                        currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
                      }
                    }
                    else
                    {
                      RodPump rodPump2 = rodPump1;
                      RodPumpWellboreItemView wellboreItemView = new RodPumpWellboreItemView(this.SectionalStyle, rodPump1.IsActive);
                      wellboreItemView.Name = rodPump2.Name;
                      wellboreItemView.TopDepth = location.TopMeasuredDepth;
                      wellboreItemView.RodDiameter = rodPump2.RodDiameter;
                      baseDownholeItem = (BaseDownholeItem) wellboreItemView;
                      currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
                    }
                  }
                  else
                  {
                    PCP pcp2 = pcp1;
                    PCPWellboreItemView wellboreItemView = new PCPWellboreItemView(this.SectionalStyle, pcp1.IsActive);
                    wellboreItemView.Name = pcp2.Name;
                    wellboreItemView.TopDepth = location.TopMeasuredDepth;
                    wellboreItemVie
