  Injector injector1 = equipment1 as Injector;
                        if ((object) injector1 == null)
                        {
                          UserEquipment userEquipment1 = equipment1 as UserEquipment;
                          if ((object) userEquipment1 == null)
                          {
                            SSSV sssv1 = equipment1 as SSSV;
                            if ((object) sssv1 == null)
                            {
                              if ((object) (equipment1 as FlowControlValve) == null)
                              {
                                Choke choke1 = equipment1 as Choke;
                                if ((object) choke1 == null)
                                {
                                  SinglephaseSeparator singlephaseSeparator1 = equipment1 as SinglephaseSeparator;
                                  if ((object) singlephaseSeparator1 == null)
                                  {
                                    EngineKeywords engineKeywords1 = equipment1 as EngineKeywords;
                                    if ((object) engineKeywords1 == null)
                                    {
                                      SpotReport spotReport1 = equipment1 as SpotReport;
                                      if ((object) spotReport1 != null)
                                      {
                                        SpotReport spotReport2 = spotReport1;
                                        baseDownholeItem = (BaseDownholeItem) new SpotReportWellboreItemView(this.SectionalStyle, spotReport1.IsActive);
                                        baseDownholeItem.Name = spotReport2.Name;
                                        baseDownholeItem.TopDepth = location.TopMeasuredDepth;
                                        currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
                    
