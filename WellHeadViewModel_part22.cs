l)
    {
      tabGroupDefinition3.Elements.Remove((object) element);
      element.Command = (ICommand) this.currentNodalPointCommand;
      tabGroupDefinition3.Elements.Add((object) element);
    }
    tabDefinition2.Groups.Add(tabGroupDefinition3);
    TabGroupDefinition tabGroupDefinition4 = new TabGroupDefinition(ribbonService.GetElement(WellKnownTabGroup.Connections));
    tabDefinition2.Groups.Add(tabGroupDefinition4);
    return tabDefinition2;
  }

  private TabDefinition SetupFormatTab(ICommand command)
  {
    TabDefinition tabDefinition1 = new TabDefinition(CoreStrings.RibbonTab_Format);
    tabDefinition1.KeyTipAccessText = "WF";
    TabDefinition tabDefinition2 = tabDefinition1;
    TabGroupDefinition tabGroupDefinition1 = new TabGroupDefinition(CoreStrings.RibbonTabGroup_Style, ImageKey.Style);
    tabDefinition2.Groups.Add(tabGroupDefinition1);
    ButtonDefinition buttonDefinition1 = new ButtonDefinition(CoreStrings.Dimension_OneDimensional, command, (object) "1D", ImageKey.DimensionOne, CoreStrings.Dimension_Tooltip, "Dimension", ButtonSize.Medium);
    buttonDefinition1.KeyTipAccessText = "1";
    ButtonDefinition buttonDefinition2 = buttonDefinition1;
    buttonDefinition2.IsChecked = WellSettings.Dimension == WellboreView.Vertical;
    ButtonDefinition buttonDefinition3 = new ButtonDefinition(CoreStrings.Dimension_TwoDimensional, command, (object) "2D", ImageKey.DimensionTwo, CoreStrings.Dimension_Tooltip, "Dimension", ButtonSize.Medium);
    buttonDefinition3.KeyTipAccessText = "2";
    ButtonDefinition buttonDefinition4 = buttonDefinition3;
    buttonDefinition4.IsChecked = !buttonDefinition2.IsChecked;
    tabGroupDefinition1.Elements.Add((object) buttonDefinition2);
    tabGroupDefinition1.Elements.Add((object) buttonDefinition4);
    GalleryDefinition galleryDefinition1 = new GalleryDefinition(CoreStrings.SectionalViewStyle, command, (object) null, (string) null, (object) null, ImageKey.CrossSection, CoreStrings
