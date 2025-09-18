grayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, (TubularString) null);
            if (this._sectionalStyle != WellboreItemView.NONE)
            {
              Shape shape = this._xamlShapeLoader.GetShape("Slickline", "Bridge Plug", this._sectionalStyle);
              baseDownholeItem.Shape = shape;
            }
          }
        }
        else
        {
          double d2 = location.TopMeasuredDepth;
          if (double.IsNaN(d2))
          {
            Equipment equipment2 = wellString.DownholeEquipment.FirstOrDefault<Equipment>((Func<Equipment, bool>) (equip => equip is FluidLink));
            d2 = !(equipment2 != (Equipment) null) ? wellString.CalcTotalLength() - 1.0 : (equipment2.Location as DownholeLocation).TopMeasuredDepth - 1.0;
          }
          Slb.Production.Engineering.Model.StandardDomain.Packer packer2 = packer1;
          if (this._sectionalStyle == WellboreItemView.NONE)
          {
            baseDownholeItem = (BaseDownholeItem) new PackerWellboreItemView();
          }
          else
          {
            baseDownholeItem = (BaseDownholeItem) new GenericDownholeItem();
            Shape shape = this._xamlShapeLoader.GetShape("Packers", "Sump Packer", this._sectionalStyle);
            baseDownholeItem.Shape = shape;
          }
          baseDownholeItem.Name = packer2.Name;
          baseDownholeItem.TopDepth = d2;
          currentString = StingrayWellboreAdapter.GetInsideTubularStringAtDepth(wellbore, baseDownholeItem.TopDepth, stringToIgnore2);
          if (!double.IsNaN(packer2.Length) && packer2.Length > 0.0)
            baseDownholeItem.Length = packer2.Length;
        }
        if (!equipment1.IsActive)
          baseDownholeItem.BorderPen = StingrayWellboreAdapter.InactivePen;
        this.AssociateModelObject((FrameworkElement) baseDownholeItem, (ModelItem) equipment1);
        currentString?.DownholeItems.Add(baseDownholeItem);
      }
    }
