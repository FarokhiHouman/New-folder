ory.SurveyType == DeviationSurveyType.TwoDimensional;
        }
        this.AddWatch((ModelItem) borehole);
        this.DrawZones(wellbore, borehole);
        this.AddWatch((INotifyCollectionChanged) borehole.WellStrings);
        WellString firstCasing = borehole.GetFirstCasing();
        foreach (WellString wellString in (IEnumerable<WellString>) borehole.WellStrings)
        {
          if (wellString != firstCasing)
          {
            this.AddWatch((ModelItem) wellString);
            TubularString tubularString = new TubularString();
            tubularString.Name = wellString.Name;
            this.AssociateModelObject((FrameworkElement) tubularString, (ModelItem) wellString);
            wellbore.TubularStrings.Add(tubularString);
            this.DrawWellString(wellbore, borehole, tubularString, wellString, TubularType.Tubing);
          }
        }
        foreach (TubularString tubularString1 in (Collection<TubularString>) this._wellboreSchematic.Wellbore.TubularStrings)
        {
          foreach (BaseTubularItem tubularItem in (Collection<BaseTubularItem>) tubularString1.TubularItems)
          {
            if (tubularItem is Tubing)
            {
              foreach (TubularString tubularString2 in (Collection<TubularString>) this.WellboreSchematic.Wellbore.TubularStrings)
              {
                foreach (BaseWellboreItem baseWellboreItem in tubularString2.Items)
                {
                  if (baseWellboreItem.ZIndex < tubularItem.ZIndex)
                    tubularItem.ZIndex = baseWellboreItem.ZIndex;
                }
              }
              --tubularItem.TubularString.ZIndex;
            }
          }
        }
        if (!DataHelper.IsNullObject((IDomainObject) firstCasing))
        {
          this.AddWatch((ModelItem) firstCasing);
          TubularString tubularString = new TubularString();
          tubularString.Name = borehole.GetFirstCasing().Name;
          this.Ass
