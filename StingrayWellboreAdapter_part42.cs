ellString1))
          {
            ModelItem wellStringItem = createWellStringItem.CreateWellStringItem(wellString1);
            NamedItem namedItem = wellStringItem as NamedItem;
            string str = (object) namedItem != null ? namedItem.Name : string.Empty;
            baseWellboreItem.Name = str;
            StateMessageDisplayHelper.DisplayStateMessage(CoreStrings.InsertEquipment, (object) this.GetDownholeEquipmentType(e.Item), (object) str, (object) DataHelperExtension.GetCurrentWorkspaceName());
            baseWellboreItem.Tag = (object) wellStringItem;
            this._wellboreSchematic.SelectedItem = baseWellboreItem;
          }
          else
          {
            NuLogger.Debug($"Unable to generate a ModelItem for the provided BaseWellboreItem: {baseWellboreItem}, ModelItemType: {modelItemType}");
            baseWellboreItem.Delete();
            e.Cancel = true;
          }
        }
        else
        {
          NuLogger.Debug($"Unable to resolve the target parent WellString for the provide BaseWellboreItem: {baseWellboreItem}");
          baseWellboreItem.Delete();
          e.Cancel = true;
        }
      }
    }
  }

  private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    this.RedrawWell();
  }

  private void DrawWellHeadWithSelectionImpl(object sender)
  {
    ModelItem key = this._modelUiMap.FirstOrDefault<KeyValuePair<ModelItem, FrameworkElement>>((Func<KeyValuePair<ModelItem, FrameworkElement>, bool>) (x => object.Equals((object) x.Value, (object) this._wellboreSchematic.SelectedItem))).Key;
    this._wellboreSchematic.SelectedItem = (BaseWellboreItem) null;
    this.DrawWellHeadImpl();
    if ((object) (sender as WellTrajectory) != null || key == (ModelItem) null || this._wellboreSchematic.SelectedItem != null || !this.IsItemValidForSelection((object) key))
    {
      this.RedrawWellAlreadyInProgress = false;
    }
    else
    {
      this.SelectIt
