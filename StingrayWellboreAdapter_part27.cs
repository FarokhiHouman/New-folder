nore1.ExternalMaterials[0];
            if (material == null)
            {
              material = new Material();
              material.TopDepth = element1.TopDepth;
              material.Background = MaterialBrushes.Cement;
              material.IsTopDepthLabelVisible = false;
              material.IsBottomDepthLabelVisible = false;
              if (!this._showText)
                material.IsLabelVisible = false;
              stringToIgnore1.ExternalMaterials.Add(material);
            }
            material.Length += element1.Length;
            if (outerDiameter.AlmostEqual(y, double.Epsilon))
            {
              if (tubingSection.SectionType == SectionType.Liner)
              {
                LinerHanger linerHanger = new LinerHanger();
                linerHanger.TopDepth = element1.TopDepth;
                linerHanger.IsLabelVisible = false;
                linerHanger.DockedTo = (BaseTubularItem) element1;
                linerHanger.IsDraggable = false;
                stringToIgnore1.DownholeItems.Add((BaseDownholeItem) linerHanger);
              }
              TubularString element2 = new TubularString();
              element2.Name = stringToIgnore1.Name;
              this.AssociateModelObject((FrameworkElement) element2, stringToIgnore1.Tag as ModelItem);
              stringToIgnore1 = element2;
              wellbore.TubularStrings.Insert(num++, stringToIgnore1);
            }
          }
          else
            d1 += tubingSection.Length;
          stringToIgnore1.TubularItems.Add((BaseTubularItem) element1);
          y = element1.OD;
        }
      }
    }
    if (flag && this._wellheadUI == null)
    {
      Slb.Ocean.UI.WellboreSchematic.WellHead wellHead = this.CreateWellHead(od);
      stringToIgnore1.DownholeItems.Add((BaseDownholeItem) wellHead);
    }
    this.AddWatch((INotifyCollectionChanged) wellString.DownholeEquipment);
    TubularString stringToIgnore2 = wellbore.T
