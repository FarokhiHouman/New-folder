osition)
  {
    Point flowPoint1 = this.GetFlowPoint(flowSection.FlowSource, flowLinePosition);
    Point flowPoint2 = this.GetFlowPoint(flowSection.FlowSink, flowLinePosition);
    this.DrawArrowLine(flowPoint1, flowPoint2, flowSection.IsFlowing, geometryGroup);
    if (flowSection.FlowSource.ExtendsOutside)
      this.DrawArrowLine(this.GetOutsideExtendPoint(flowSection.FlowSource, flowPoint1, 16.0, flowLinePosition), flowPoint1, true, geometryGroup);
    if (!flowSection.FlowSink.ExtendsOutside)
      return;
    Point outsideExtendPoint = this.GetOutsideExtendPoint(flowSection.FlowSink, flowPoint2, 16.0, flowLinePosition);
    this.DrawArrowLine(flowPoint2, outsideExtendPoint, true, geometryGroup);
  }

  private void DrawArrowLine(
    Point startPoint,
    Point endPoint,
    bool isFlowing,
    GeometryGroup geometryGroup)
  {
    LineGeometry lineGeometry = new LineGeometry(startPoint, endPoint);
    double num = this.FlowPathThickness / 2.0;
    this.guidelineSet.GuidelinesX.Add(startPoint.X + num);
    this.guidelineSet.GuidelinesX.Add(endPoint.X + num);
    this.guidelineSet.GuidelinesY.Add(startPoint.Y + num);
    this.guidelineSet.GuidelinesY.Add(endPoint.Y + num);
    geometryGroup.Children.Add((Geometry) lineGeometry);
    if (!isFlowing)
      return;
    double flowAngle = PipesimFlowPath.DetermineFlowAngle(startPoint, endPoint);
    PathGeometry arrowhead = PipesimFlowPath.CreateArrowhead(endPoint, flowAngle, true);
    geometryGroup.Children.Add((Geometry) arrowhead);
  }

  private static double DetermineFlowAngle(Point start, Point end)
  {
    double x = end.X - start.X;
    return Math.Atan2(end.Y - start.Y, x) * (180.0 / Math.PI);
  }

  private static PathGeometry CreateArrowhead(Point arrowHeadPoint, double angle, bool isFlowing)
  {
    PathGeometry arrowhead = new PathGeometry();
    PathFigure pathFigure = new PathFigure()
    {
      IsClosed = true,
      IsFilled = true
    };
    if (is
