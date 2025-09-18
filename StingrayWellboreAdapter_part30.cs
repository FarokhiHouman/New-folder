                  }
                                      else
                                        continue;
                                    }
                                    else
                                    {
                                      EngineKeywords engineKeywords2 = engineKeywords1;
                                      baseDownholeItem = (BaseDownholeItem) new EngineKeywordsWellboreItemView(this.SectionalStyle, engineKeywords1.IsActive);
                                      baseDownholeItem.Name = engineKeywords2.Name;
                                      baseDownholeItem.TopDepth = location.TopMeasuredDepth;
                                      currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
                                    }
                                  }
                                  else
                                  {
                                    SinglephaseSeparator singlephaseSeparator2 = singlephaseSeparator1;
                                    baseDownholeItem = (BaseDownholeItem) new DownholeSeparator(this._itemColor, singlephaseSeparator1.IsActive);
                                    baseDownholeItem.Name = singlephaseSeparator2.Name;
                                    baseDownholeItem.TopDepth = location.TopMeasuredDepth;
                                    currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
                                    if (this._sectionalStyle != WellboreItemView.NONE)
                                    {
                                      Shape shape = this._xamlShapeLoader.GetShape("Submersible Pumps", "RF Gas Separator", this._sectionalStyle);
                                      baseDownholeItem.Shape = shape;
                                    }
                             
