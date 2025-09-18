6.0, 4.0))));
        break;
      case ColorCode.Green:
        geometryDrawing1 = new GeometryDrawing((Brush) Brushes.Green, pen, (Geometry) new RectangleGeometry(new System.Windows.Rect(new Size(6.0, 4.0))));
        break;
      case ColorCode.Blue:
        geometryDrawing1 = new GeometryDrawing((Brush) Brushes.Blue, pen, (Geometry) new RectangleGeometry(new System.Windows.Rect(new Size(6.0, 4.0))));
        break;
      case ColorCode.Yellow:
        geometryDrawing1 = new GeometryDrawing((Brush) Brushes.Yellow, pen, (Geometry) new RectangleGeometry(new System.Windows.Rect(new Size(6.0, 4.0))));
        break;
      case ColorCode.Default:
        geometryDrawing1 = new GeometryDrawing((Brush) Brushes.LightGray, pen, (Geometry) new RectangleGeometry(new System.Windows.Rect(new Size(6.0, 4.0))));
        break;
      case ColorCode.Orange:
        geometryDrawing1 = new GeometryDrawing((Brush) Brushes.Orange, pen, (Geometry) new RectangleGeometry(new System.Windows.Rect(new Size(6.0, 4.0))));
        break;
    }
    if (geometryDrawing1 != null)
      drawingGroup.Children.Add((Drawing) geometryDrawing1);
    GeometryDrawing geometryDrawing2 = new GeometryDrawing(brush, pen, (Geometry) new EllipseGeometry(center, num, num));
    drawingGroup.Children.Add((Drawing) geometryDrawing2);
    this.Shape = new Shape((Drawing) drawingGroup);
  }

  protected override void TryDocking()
  {
    BaseTubularItem baseTubularItem = this.TryDockingAtTubularItem(TubularType.Tubing);
    if (baseTubularItem != null)
    {
      this.OD = baseTubularItem.OD;
      this.ID = baseTubularItem.ID;
    }
    else
      base.TryDocking();
  }

  protected override Size MeasureOverride(Size availableSize)
  {
    return this.IsDragging ? new Size(0.001, 0.001) : base.MeasureOverride(availableSize);
  }

  protected override void CalculateBounds()
  {
    base.CalculateBounds();
    System.Windows.Rect bounds = this.Bounds;
    if (this.IsDr
