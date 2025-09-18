              baseDownholeItem.Label = new WellboreLabel((BaseWellboreItem) baseDownholeItem);
                  baseDownholeItem.Name = perforation.Name;
                }
                baseDownholeItem.TopDepth = location.TopMeasuredDepth;
                if (perforation.FluidEntryType == FluidEntryType.Distributed)
                {
                  if (!double.IsNaN(perforation.Length) && perforation.Length > 0.0)
                    baseDownholeItem.Length = perforation.Length;
                  else if (!double.IsNaN(location.TopMeasuredDepth) && !double.IsNaN(location.BottomMeasuredDepth))
                    baseDownholeItem.Length = location.BottomMeasuredDepth - location.TopMeasuredDepth;
                }
              }
            }
            else
            {
              Slb.Production.Engineering.Model.StandardDomain.SlidingSleeve slidingSleeve2 = slidingSleeve1;
              baseDownholeItem = (BaseDownholeItem) new SlidingSleeve(this._itemColor);
              baseDownholeItem.Name = slidingSleeve2.Name;
              baseDownholeItem.TopDepth = location.TopMeasuredDepth;
              ((SlidingSleeve) baseDownholeItem).IsOpen = slidingSleeve2.IsOpen;
              currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
              if (this._sectionalStyle != WellboreItemView.NONE)
              {
                Shape shape = this._xamlShapeLoader.GetShape("Completion Tubular Accessories", "Sliding Sleeve (up)", this._sectionalStyle);
                baseDownholeItem.Shape = shape;
              }
            }
          }
          else
          {
            TubingPlug tubingPlug2 = tubingPlug1;
            baseDownholeItem = (BaseDownholeItem) new TubingPlugWellboreItemView();
            baseDownholeItem.Name = tubingPlug2.Name;
            baseDownholeItem.TopDepth = location.TopMeasuredDepth;
            currentString = Stin
