Flowing)
    {
      pathFigure.Segments.Add((PathSegment) new LineSegment(new Point(-6.0, -3.0), true));
      pathFigure.Segments.Add((PathSegment) new LineSegment(new Point(-6.0, 3.0), true));
    }
    else
    {
      pathFigure.StartPoint = new Point(-1.0, -3.0);
      pathFigure.Segments.Add((PathSegment) new LineSegment(new Point(0.0, -3.0), true));
      pathFigure.Segments.Add((PathSegment) new LineSegment(new Point(0.0, 3.0), true));
      pathFigure.Segments.Add((PathSegment) new LineSegment(new Point(-1.0, 3.0), true));
    }
    arrowhead.Figures.Add(pathFigure);
    RotateTransform rotateTransform = new RotateTransform(angle);
    TranslateTransform translateTransform = new TranslateTransform(arrowHeadPoint.X, arrowHeadPoint.Y);
    arrowhead.Transform = (Transform) new TransformGroup()
    {
      Children = {
        (Transform) rotateTransform,
        (Transform) translateTransform
      }
    };
    return arrowhead;
  }

  private Point GetFlowPoint(FlowPoint flowPoint, PipesimFlowPath.FlowLinePosition flowLinePosition)
  {
    Point flowPoint1 = new Point(0.0, 0.0);
    if (this.FindFlowPointParent(flowPoint) == null)
      return flowPoint1;
    flowPoint1.X = this.GetXOffset(flowPoint.ParentItem, flowLinePosition);
    flowPoint1.Y = this.GetYOffset(flowPoint.MD);
    return flowPoint1;
  }

  private double GetXOffset(
    BaseWellboreItem parentItem,
    PipesimFlowPath.FlowLinePosition flowLinePosition)
  {
    double num;
    switch (flowLinePosition)
    {
      case PipesimFlowPath.FlowLinePosition.Left:
        num = -1.0;
        break;
      case PipesimFlowPath.FlowLinePosition.Right:
        num = 1.0;
        break;
      default:
        num = 0.0;
        break;
    }
    return this.Wellbore.Transform.ToXWellbore(parentItem.InnerRadius * num) - this.Location.X + (flowLinePosition == PipesimFlowPath.FlowLinePosition.Left ? 8.0 : -8.0) - (flowLinePosition == PipesimFlowPath.Flow
