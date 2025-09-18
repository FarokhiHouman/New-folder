rce1.Any<BaseWellboreItem>((Func<BaseWellboreItem, bool>) (o => o.Tag.Equals(item.Tag))))
                {
                  BaseWellboreItem baseWellboreItem2 = source1.First<BaseWellboreItem>((Func<BaseWellboreItem, bool>) (o => o.Tag.Equals(item.Tag)));
                  item.LabelTrackIndex = baseWellboreItem2.LabelTrackIndex;
                  item.IsLabelVisible = baseWellboreItem2.IsLabelVisible;
                }
              }
              else
              {
                BaseWellboreItem baseWellboreItem3 = source2.FirstOrDefault<BaseWellboreItem>((Func<BaseWellboreItem, bool>) (o => o.Label != null && o.Label.Text.Equals(item.Label.Text)));
                if (baseWellboreItem3 != null)
                {
                  item.LabelTrackIndex = baseWellboreItem3.LabelTrackIndex;
                  item.IsLabelVisible = baseWellboreItem3.IsLabelVisible;
                }
              }
            }
          }
        }
        if (this._wellheadUI == null || wellheadUi == null)
          return;
        this._wellheadUI.LabelTrackIndex = wellheadUi.LabelTrackIndex;
        this._wellheadUI.IsLabelVisible = wellheadUi.IsLabelVisible;
      }
      finally
      {
        wellbore.EndUpdate();
      }
    }
  }

  private void SetLabelColor()
  {
    if (this._wellboreSchematic.Wellbore.LabelTracks == null || this._wellboreSchematic.Wellbore.LabelTracks.Count == 0)
      return;
    foreach (LabelTrack labelTrack in (Collection<LabelTrack>) this._wellboreSchematic.Wellbore.LabelTracks)
    {
      if (labelTrack != null && labelTrack.Children != null && labelTrack.Children.Count != 0)
      {
        foreach (WellboreLabel child in labelTrack.Children)
          child.Background = (Brush) Brushes.White;
      }
    }
  }

  private void AssociateModelObject(FrameworkElement element, ModelItem item)
  {
    if (!(element != null & item != (ModelItem) null))
      return;
    element.Tag = (object) item
