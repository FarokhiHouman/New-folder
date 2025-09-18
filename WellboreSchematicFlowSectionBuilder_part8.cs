rt,
    FlowPoint end,
    List<Equipment> equipments,
    TubingSection startTubingSection,
    TubingSection endTubingSection,
    FlowPathNode firstNode,
    FlowPathNode secondNode,
    bool isInjection)
  {
    FlowSection flowSection = new FlowSection(sections.GenerateNewName(), start, end);
    if (!FlowValidatorFactory.CreateValidator(equipments, flowSection, startTubingSection, endTubingSection, firstNode, secondNode, path, isInjection).CanAddFlowSection())
      return;
    sections.Add(flowSection);
  }

  private class FlowSectionsUnique : List<FlowSection>
  {
    private readonly bool _isFlowing;

    public FlowSectionsUnique(bool isFlowing) => this._isFlowing = isFlowing;

    private IEnumerable<FlowSection> HorizontalSections
    {
      get => this.Where<FlowSection>((Func<FlowSection, bool>) (f => f.IsFlowHorizontal));
    }

    public string GenerateNewName() => "flowSection" + (this.Count + 1).ToString();

    public void AddNewSection(FlowPoint flowSource, FlowPoint flowSink)
    {
      this.Add(new FlowSection(this.GenerateNewName(), flowSource, flowSink));
    }

    public new void Add(FlowSection item)
    {
      if (item == null)
        throw new ArgumentNullException("FlowSection cannot be null");
      item.IsFlowing = this._isFlowing;
      if (item.IsFlowHorizontal && this.HorizontalSections.Any<FlowSection>((Func<FlowSection, bool>) (f => this.HorizontalSectionsEqual(f, item))))
        return;
      base.Add(item);
    }

    public bool Print()
    {
      Trace.WriteLine("---------------------------");
      foreach (FlowSection flowSection in (List<FlowSection>) this)
      {
        string str1 = flowSection.FlowSource.ParentItem == null ? "NULL ParentItem" : flowSection.FlowSource.ParentItem.Name;
        string str2 = flowSection.FlowSink.ParentItem == null ? "NULL ParentItem" : flowSection.FlowSink.ParentItem.Name;
        Trace.WriteLine($"From:{str1} AT {flowSection.Flow
