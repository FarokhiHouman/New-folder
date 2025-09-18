;
    this._modelUiMap[item] = element;
    if (!this._showValidation)
      return;
    BaseWellboreItem equip = element as BaseWellboreItem;
    NamedItem namedItem = item as NamedItem;
    if (equip == null || !(namedItem != (NamedItem) null))
      return;
    StingrayWellboreAdapter.SetLabelControl(equip, namedItem, this._showText, this._showValidation);
  }

  private bool AddLabelsToSplitCompletion(Slb.Production.Engineering.Model.StandardDomain.Perforation perforation, TubularString currentString)
  {
    if (!perforation.IsDistributedCompletion() || currentString == null)
      return false;
    IOrderedEnumerable<PerforationFlowPathNode> source = this.GetPerforationNodes(perforation).OrderBy<PerforationFlowPathNode, double>((Func<PerforationFlowPathNode, double>) (p => p.TopPerf));
    foreach (PerforationFlowPathNode perforationFlowPathNode in (IEnumerable<PerforationFlowPathNode>) source)
    {
      SplitCompletionDepthReferenceWellboreItemView wellboreItemView = new SplitCompletionDepthReferenceWellboreItemView(perforationFlowPathNode.PerforationName, this._showText);
      wellboreItemView.TopDepth = perforationFlowPathNode.TopPerf + (perforationFlowPathNode.BottomPerf - perforationFlowPathNode.TopPerf) / 2.0;
      currentString.DownholeItems.Add((BaseDownholeItem) wellboreItemView);
    }
    return source.Any<PerforationFlowPathNode>();
  }

  private IEnumerable<PerforationFlowPathNode> GetPerforationNodes(Slb.Production.Engineering.Model.StandardDomain.Perforation perf)
  {
    List<PerforationFlowPathNode> nodes = new List<PerforationFlowPathNode>();
    foreach (IEnumerable flowPath in this._wellHead.FlowPaths)
      Add(flowPath.OfType<PerforationFlowPathNode>().Where<PerforationFlowPathNode>((Func<PerforationFlowPathNode, bool>) (p => (object) p.ParentObject == (object) perf && p.IsSplit)));
    return (IEnumerable<PerforationFlowPathNode>) nodes;

    void Add(IEnumerable<PerforationFlowPathNode> nodesToAdd)

