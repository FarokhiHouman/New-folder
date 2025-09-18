tSelected), (Action<StingrayWellboreAdapter, EventHandler<NamedItemEventArgs>>) ((x, y) => x.SurfaceEquipmentSelected += y), (Action<StingrayWellboreAdapter, EventHandler<NamedItemEventArgs>>) ((x, y) => x.SurfaceEquipmentSelected -= y)));
      this._wellboreAdapter.WellboreSchematic.IsReadOnly = this._wellHead.IsBuiltinTemplate;
      this.ShowWell();
    }
  }

  public ICommand DeleteSelectedItemCommand { get; private set; }

  public ICommand ToggleSelectedItemLabelVisibilityCommand { get; private set; }

  public void HandleWellboreCommand(string commandParameterString, object parameter)
  {
    if (this._wellboreAdapter == null || this._wellHead.IsBuiltinTemplate)
      return;
    switch (commandParameterString)
    {
      case "1D":
        this._wellboreAdapter.HandleDimensionChange(WellboreView.Vertical);
        break;
      case "2D":
        this._wellboreAdapter.HandleDimensionChange(WellboreView.Trajectory);
        break;
      case "DepthVisible":
        this._wellboreAdapter.ShowDepthReferenceChecked = (bool) parameter;
        break;
      case "FlowLineVisible":
        this._wellboreAdapter.ShowFlowPathChecked = (bool) parameter;
        break;
      case "FullMode":
        this._wellboreAdapter.HandleSectionalChange(WellboreItemView.FULL);
        break;
      case "HalfMode":
        this._wellboreAdapter.HandleSectionalChange(WellboreItemView.HALF);
        break;
      case "LabelVisible":
        this._wellboreAdapter.ShowLabelChecked = (bool) parameter;
        break;
      case "QuarterMode":
        this._wellboreAdapter.HandleSectionalChange(WellboreItemView.QUARTER);
        break;
      case "SimplifiedFHalf":
        this._wellboreAdapter.HandleSectionalChange(WellboreItemView.NONE);
        break;
      case "Slb.Production.Engineering.WellboreViewer.PrintWellbore":
        this._wellboreAdapter.Print();
        break;
    }
    this._wellboreAdapter.RedrawWell();
  }

  private 
