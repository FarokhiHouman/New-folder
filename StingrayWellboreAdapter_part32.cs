          }
                              }
                            }
                            else
                            {
                              SSSV sssv2 = sssv1;
                              baseDownholeItem = (BaseDownholeItem) new SSSVWellboreItemView();
                              baseDownholeItem.Name = sssv2.Name;
                              baseDownholeItem.TopDepth = location.TopMeasuredDepth;
                              currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
                              if (this._sectionalStyle != WellboreItemView.NONE)
                              {
                                Shape shape = this._xamlShapeLoader.GetShape("Subsurface Safety Valve", "SCSSV", this._sectionalStyle);
                                baseDownholeItem.Shape = shape;
                              }
                            }
                          }
                          else
                          {
                            UserEquipment userEquipment2 = userEquipment1;
                            baseDownholeItem = (BaseDownholeItem) new UserEquipmentWellboreItemView(userEquipment1.IsActive);
                            baseDownholeItem.Name = userEquipment2.Name;
                            baseDownholeItem.TopDepth = location.TopMeasuredDepth;
                            currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
                          }
                        }
                        else
                        {
                          Injector injector2 = injector1;
                          baseDownholeItem = (BaseDownholeItem) new InjectorWellboreItemView(this.SectionalStyle, injector1.IsActive);
                          baseDownholeItem.Name = injector2.Name;
                          base
