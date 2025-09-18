     }
                                }
                                else
                                {
                                  Choke choke2 = choke1;
                                  baseDownholeItem = (BaseDownholeItem) new FloatCollar();
                                  baseDownholeItem.Name = choke2.Name;
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
                                FCVWellboreItemView wellboreItemView = new FCVWellboreItemView(equipment1.IsActive);
                                wellboreItemView.Name = equipment1.Name;
                                wellboreItemView.TopDepth = location.TopMeasuredDepth;
                                baseDownholeItem = (BaseDownholeItem) wellboreItemView;
                                currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
                                if (this._sectionalStyle != WellboreItemView.NONE)
                                {
                                  Shape shape = this._xamlShapeLoader.GetShape("Completion Tubular Accessories", "Sliding Sleeve (up)", this._sectionalStyle);
                                  baseDownholeItem.Shape = shape;
                      
