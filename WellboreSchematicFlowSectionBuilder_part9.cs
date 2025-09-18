Source.MD} To:{str2} AT {flowSection.FlowSink.MD} From Extends:{flowSection.FlowSource.ExtendsOutside} To Extends:{flowSection.FlowSink.ExtendsOutside}");
      }
      Trace.WriteLine("---------------------------");
      return true;
    }

    private bool HorizontalSectionsEqual(FlowSection f1, FlowSection f2)
    {
      return this.FlowPointsEqual(f1.FlowSource, f2.FlowSource) && this.FlowPointsEqual(f1.FlowSink, f2.FlowSink);
    }

    private bool FlowPointsEqual(FlowPoint f1, FlowPoint f2)
    {
      return f1.ParentItem == null || f2.ParentItem == null || f1.MD.AlmostEqual(f2.MD) && f1.ParentItem.Equals((object) f2.ParentItem);
    }
  }
}

