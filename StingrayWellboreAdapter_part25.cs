       element1.BorderPen = new Pen((Brush) Brushes.White, 1.0)
              {
                DashStyle = DashStyles.Dot
              };
              element1.Background = (Brush) Brushes.Gray;
              element1.FillPen = (Pen) null;
              element1.FillBrush = (Brush) null;
              element1.IsSelectable = true;
              element1.IsTopFixed = true;
            }
            else
            {
              element1 = (Tubular) new Casing();
              element1.IsDepthLabelVisible = false;
              element1.IsTopFixed = true;
            }
          }
          else
          {
            if (tubingSection.IsFirstTailPipe)
            {
              TubingSection casingAtDepth = ourBore.GetFirstCasing().GetCasingAtDepth(tubingSection.TopMeasuredDepth);
              element1 = (Tubular) new TailTubingWellboreItemView(this._sectionalStyle == WellboreItemView.NONE, casingAtDepth != (TubingSection) null ? new double?(casingAtDepth.InnerDiameter) : new double?())
              {
                TailPipe = tubingSection,
                SchematicActions = (ISchematicActions) this,
                TubingItem = stringToIgnore1.TubularItems.OfType<Tubing>().FirstOrDefault<Tubing>()
              };
            }
            else
              element1 = (Tubular) new Tubing();
            if (tubingSection.IsTailPipe)
            {
              element1.IsTopFixed = true;
              element1.IsBottomFixed = true;
            }
            if (this._sectionalStyle != WellboreItemView.NONE)
            {
              Shape shape = this._xamlShapeLoader.GetShape("Tubing", "Tubing", this._sectionalStyle);
              element1.Shape = shape;
              element1.View = this._sectionalStyle;
            }
          }
          element1.IsDraggable = tubingSection.IsFirstTailPipe;
          element1.Name = StingrayWellboreAdapter.ConvertNameToWPFStandards(tubingSection.Name);
          this.A
