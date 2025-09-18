tType.Downhole), ImageKey.UserDownholeEquipment, stringBuilder.ToString(), true);
            galleryDefinition1.AddItem((object) buttonDefinition);
          }
          else
          {
            ButtonDefinition buttonDefinition = new ButtonDefinition(entryPoint.DisplayName, (ICommand) null, (object) new UserEquipmentItemFactory(userEquipmentEntryPoint, UserEquipmentType.ArtificialLift), ImageKey.UserArtificialLiftEquipment, stringBuilder.ToString(), true);
            galleryDefinition2.AddItem((object) buttonDefinition);
          }
        }
      }
    }
    tabGroupDefinition2.Elements.Add((object) galleryDefinition1);
    tabDefinition2.Groups.Add(tabGroupDefinition2);
    tabGroupDefinition3.Elements.Add((object) galleryDefinition2);
    tabDefinition2.Groups.Add(tabGroupDefinition3);
    return tabDefinition2;
  }

  private TabDefinition SetupInsertSurfaceTab(IRibbonService ribbonService)
  {
    TabDefinition tabDefinition1 = new TabDefinition(CoreStrings.RibbonTab_Insert);
    tabDefinition1.KeyTipAccessText = "WI";
    TabDefinition tabDefinition2 = tabDefinition1;
    TabGroupDefinition tabGroupDefinition1 = new TabGroupDefinition(CoreStrings.RibbonTabGroup_BoundaryNodes, ImageKey.BoundaryNodes);
    tabGroupDefinition1.Elements.Add((object) ribbonService.GetElement(WellKnownButton.Source));
    tabGroupDefinition1.Elements.Add((object) ribbonService.GetElement(WellKnownButton.Sink));
    tabDefinition2.Groups.Add(tabGroupDefinition1);
    TabGroupDefinition tabGroupDefinition2 = new TabGroupDefinition(ribbonService.GetElement(WellKnownTabGroup.InternalNodes));
    tabDefinition2.Groups.Add(tabGroupDefinition2);
    TabGroupDefinition tabGroupDefinition3 = new TabGroupDefinition(ribbonService.GetElement(WellKnownTabGroup.Others));
    NodalPointButtonDefinition element = this._ribbonService.GetElement(WellKnownButton.NodalAnalysisPoint) as NodalPointButtonDefinition;
    if ((ElementDefinition) element != (object) nul
