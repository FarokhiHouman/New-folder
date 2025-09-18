LinePosition.Right ? 0.5 : 0.0);
  }

  private double GetYOffset(double md) => this.Wellbore.Transform.ToYWellbore(md) - this.Location.Y;

  private Point GetOutsideExtendPoint(
    FlowPoint flowPoint,
    Point currentPoint,
    double spacingValue,
    PipesimFlowPath.FlowLinePosition flowLinePosition)
  {
    Point outsideExtendPoint = new Point(0.0, 0.0);
    BaseWellboreItem flowPointParent = this.FindFlowPointParent(flowPoint);
    if (flowPointParent == null)
      return outsideExtendPoint;
    if (flowPointParent.TopDepth.AlmostEqual(flowPoint.MD))
    {
      outsideExtendPoint.X = currentPoint.X;
      outsideExtendPoint.Y = currentPoint.Y - spacingValue;
    }
    else if (flowPointParent.BottomDepth.AlmostEqual(flowPoint.MD))
    {
      outsideExtendPoint.X = currentPoint.X;
      outsideExtendPoint.Y = currentPoint.Y + spacingValue;
    }
    else
    {
      outsideExtendPoint.X = flowLinePosition == PipesimFlowPath.FlowLinePosition.Left ? currentPoint.X - spacingValue : currentPoint.X + spacingValue;
      outsideExtendPoint.Y = currentPoint.Y;
    }
    return outsideExtendPoint;
  }

  private Pen CreateDefaultPen()
  {
    return new Pen(this.Background, this.FlowPathThickness)
    {
      DashStyle = DashStyles.Solid,
      MiterLimit = 0.0,
      EndLineCap = PenLineCap.Flat,
      StartLineCap = PenLineCap.Flat,
      LineJoin = PenLineJoin.Bevel
    };
  }

  private BaseWellboreItem FindFlowPointParent(FlowPoint flowPoint)
  {
    return flowPoint.ParentItem ?? (flowPoint.ParentItem = this.Wellbore.FindName(flowPoint.ParentString) as BaseWellboreItem);
  }

  private enum FlowLinePosition
  {
    Left,
    Right,
  }
}

