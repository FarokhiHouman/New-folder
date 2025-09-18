0016,239.99988 200,238.99987 200,200 z") as PathFigureCollection;
    LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
    linearGradientBrush.StartPoint = new Point(0.5, 0.0);
    linearGradientBrush.EndPoint = new Point(0.5, 1.0);
    switch (itemColor)
    {
      case ColorCode.Red:
        linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
        linearGradientBrush.GradientStops.Add(new GradientStop(Colors.IndianRed, 0.0));
        break;
      case ColorCode.Green:
        linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Green, 1.0));
        linearGradientBrush.GradientStops.Add(new GradientStop(Colors.LightGreen, 0.0));
        break;
      case ColorCode.Blue:
        linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Blue, 1.0));
        linearGradientBrush.GradientStops.Add(new GradientStop(Colors.BlueViolet, 0.0));
        break;
      case ColorCode.Yellow:
        linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 1.0));
        linearGradientBrush.GradientStops.Add(new GradientStop(Colors.LightGoldenrodYellow, 0.0));
        break;
      case ColorCode.Default:
        linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb((byte) 107, (byte) 107, (byte) 107, (byte) 107), 1.0));
        linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb((byte) 219, (byte) 219, (byte) 219, (byte) 219), 0.0));
        break;
      case ColorCode.Orange:
        linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Orange, 1.0));
        linearGradientBrush.GradientStops.Add(new GradientStop(Colors.DarkOrange, 0.0));
        break;
    }
    GeometryDrawing geometryDrawing = new GeometryDrawing((Brush) linearGradientBrush, pen, (Geometry) pathGeometry);
    drawingGroup.Children.Add((Drawing) geometryDrawing);
    this.Shape = new Shape((Drawing) drawingGroup);
  }

  protected override void TryDocking()
  {
