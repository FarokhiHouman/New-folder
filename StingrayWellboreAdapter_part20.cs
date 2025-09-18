ociateModelObject((FrameworkElement) tubularString, (ModelItem) firstCasing);
          wellbore.TubularStrings.Insert(0, tubularString);
          borehole.RefreshFlowPath();
          this.DrawWellString(wellbore, borehole, tubularString, firstCasing, TubularType.Casing);
          new WellboreSchematicFlowSectionBuilder(this._wellHead, (ISchematicUiElementProvider) this, this._showText).DrawWellFlowPaths(tubularString);
        }
        this.ShowFlowPath();
        this._wellboreSchematic.Wellbore.IsDepthAxisVisible = this.ShowDepthReferenceChecked;
        if (this._wellboreSchematic.Wellbore.LabelTracks != null && this._wellboreSchematic.Wellbore.LabelTracks.Count != 0)
          this._wellboreSchematic.Wellbore.LabelTracks[0].Visibility = this.ShowLabelChecked ? Visibility.Visible : Visibility.Hidden;
        foreach (TubularString tubularString in (Collection<TubularString>) this._wellboreSchematic.Wellbore.TubularStrings)
        {
          foreach (BaseWellboreItem baseWellboreItem in tubularString.Items)
          {
            if (baseWellboreItem is Material)
            {
              baseWellboreItem.Visibility = Visibility.Collapsed;
              break;
            }
          }
        }
        foreach (FrameworkElement frameworkElement in this._wellboreSchematic.Wellbore.TubularStrings.SelectMany<TubularString, BaseWellboreItem>((Func<TubularString, IEnumerable<BaseWellboreItem>>) (i => (IEnumerable<BaseWellboreItem>) i.Items)))
          frameworkElement.ContextMenu = (ContextMenu) null;
        this.SetLabelColor();
        foreach (TubularString tubularString in (Collection<TubularString>) wellbore.TubularStrings)
        {
          foreach (BaseWellboreItem baseWellboreItem1 in tubularString.Items)
          {
            BaseWellboreItem item = baseWellboreItem1;
            if (!(item is PerforationWellboreItemView))
            {
              if (item.Tag != null)
              {
                if (sou
