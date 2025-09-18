 (object) watchedBranchItem;
              newItem.Command = this._selectSurfaceEquipmentCommand;
              this._wellheadUI.ContextMenu.Items.Add((object) newItem);
              Hyperlink hyperlink = new Hyperlink();
              hyperlink.Inlines.Add(watchedBranchItem.Name);
              hyperlink.Tag = (object) watchedBranchItem;
              hyperlink.CommandParameter = (object) watchedBranchItem;
              hyperlink.Command = this._selectSurfaceEquipmentCommand;
              TextBlock element = new TextBlock();
              element.Inlines.Add((Inline) hyperlink);
              element.ToolTip = (object) (newItem.Header as string);
              stackPanel.Children.Add((UIElement) element);
            }
          }
          scrollViewer.Content = (object) stackPanel;
          customExpander.Content = (object) scrollViewer;
          this._wellheadUI.ToolTip = (object) string.Format((IFormatProvider) CultureInfo.CurrentCulture, CoreStrings.RightClickToNavigate, (object) this._watchedBranchItems.Count);
          this._wellheadUI.Label.ContentControl = (Control) customExpander;
          this._wellheadUI.Label.ShadowBrush = (Brush) Brushes.LightGray;
        }
        else
        {
          MenuItem newItem = new MenuItem();
          newItem.Header = (object) CoreStrings.SurfaceEquipmentNotConnected;
          this._wellheadUI.ToolTip = (object) CoreStrings.SurfaceEquipmentNotConnected;
          this._wellheadUI.ContextMenu.Items.Add((object) newItem);
          this._wellheadUI.Label.Text = CoreStrings.SurfaceEquipmentNotConnected;
        }
      }
    }
    else if (this._wellheadUI.OD < od + od / 100.0 * 10.0)
      this._wellheadUI.OD = od + od / 100.0 * 10.0;
    return this._wellheadUI;
  }

  public Geometry CreateText(
    string text,
    bool bold,
    bool italic,
    FontFamily fontFamily,
    double fontSize,
    System.Windows.Point origin)
  {
    FontStyle style = italic ? FontStyles
