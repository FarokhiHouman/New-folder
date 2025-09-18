      break;
              }
            }
          }
        }
      }
    }
  }

  private GalleryDefinition FindUserEquipmentGallery(string groupName)
  {
    TabGroupDefinition tabGroupDefinition = (TabGroupDefinition) null;
    foreach (TabGroupDefinition group in (Collection<TabGroupDefinition>) this._insertDownholeTabDefinition.Groups)
    {
      if (group.Label == groupName)
        tabGroupDefinition = group;
    }
    GalleryDefinition equipmentGallery = (GalleryDefinition) null;
    if ((ElementDefinition) tabGroupDefinition != (object) null)
    {
      foreach (ButtonDefinition element in (Collection<object>) tabGroupDefinition.Elements)
      {
        if (element is GalleryDefinition && element.Label == CoreStrings.UserEquipment)
        {
          equipmentGallery = (GalleryDefinition) element;
          break;
        }
      }
    }
    return equipmentGallery;
  }

  private bool IsGasliftIssue(ValidationIssue issue)
  {
    if ((object) (issue.RootItem as Operation) != null && issue.Property == "IsMultiPointing")
      return true;
    return this._isGasliftIssueMap.ContainsKey(issue.PropertyOwner.GetType()) && this._isGasliftIssueMap[issue.PropertyOwner.GetType()](issue);
  }

  private void StateService_OnStateChanged(ActionEventArgs<string, object, object> e)
  {
    if (e.Key == "topic://WellBoreEditorStateChanged")
      this.BeginInvoke((Action) (() => this.HandleValidationIssueClicked(e)), DispatcherPriority.ApplicationIdle);
    else if (e.Key == "topic://JunctionConvertedTo" && this.BranchViewModel != null)
    {
      DurableId data = e.Data as DurableId;
      if (!(data != (DurableId) null))
        return;
      LogicalNetworkViewModel branchViewModel = this.BranchViewModel;
      List<DurableId> selectedEquipmentDroids = new List<DurableId>();
      selectedEquipmentDroids.Add(data);
      DurableId primaryEquipmentDroid = data;
      branchViewModel.SetLocalContext(selectedEqui
