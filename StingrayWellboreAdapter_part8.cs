nts = network.FindSingleBranchFromNodeWithNodalPoints((Equipment) this._wellHead)) == null)
      {
        this._wellheadUI.Shape = new Shape((Drawing) this.WellHeadDrawingGroup((FrameworkElement) wellheadShape));
        return this._wellheadUI;
      }
      this._watchedBranchItems = nodeWithNodalPoints.ToList<NamedItem>();
      if (this._wellheadUI.Shape == null)
      {
        DrawingGroup drawingGroup = this.WellHeadDrawingGroup((FrameworkElement) wellheadShape);
        if (!this._wellHead.IsAdvancedType() && this._watchedBranchItems.Count > 0)
        {
          drawingGroup.Children.Add((Drawing) new GeometryDrawing()
          {
            Geometry = (Geometry) wellheadShape.FindResource((object) "branchLineGeo"),
            Brush = (Brush) wellheadShape.FindResource((object) "wellpipeBrush"),
            Pen = (Pen) wellheadShape.FindResource((object) "wellheadBorder")
          });
          drawingGroup.Children.Add((Drawing) new GeometryDrawing()
          {
            Geometry = this.CreateText((this._watchedBranchItems.Count - 1).ToString((IFormatProvider) CultureInfo.InvariantCulture), true, false, new FontFamily("Segui"), 5.0, new System.Windows.Point(25.0, 0.0)),
            Brush = (Brush) new SolidColorBrush(Colors.Black),
            Pen = (Pen) wellheadShape.FindResource((object) "wellheadBorder")
          });
        }
        this._wellheadUI.Shape = new Shape((Drawing) drawingGroup);
      }
      this._wellheadUI.IsDraggable = false;
      this._wellheadUI.IsSelectable = false;
      this._wellheadUI.ContextMenu = new ContextMenu();
      if (!this._showValidation && !this._wellHead.IsAdvancedType())
      {
        if (this._watchedBranchItems.Count > 1)
        {
          CustomExpander customExpander = new CustomExpander();
          customExpander.AllowCollapse = true;
          customExpander.IsExpanded = false;
          customExpander.Margin = new Thickness(1.0, 0.0, 0.0, 1.0);
         
