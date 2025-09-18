ngHelper.FixFlowPathsForDrawing(this._wellHead.DefaultBorehole).ToList<Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes.FlowPath>();
    foreach (Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes.FlowPath flowPath in this._flowPaths)
    {
      PipesimFlowPath pipesimFlowPath = this.DrawFlowPath(tubularCasingString, flowPath, isSolvable);
      if (pipesimFlowPath != null)
        pipesimFlowPathList.Add(pipesimFlowPath);
    }
    return (IEnumerable<PipesimFlowPath>) pipesimFlowPathList;
  }

  private PipesimFlowPath DrawFlowPath(TubularString casing, Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes.FlowPath path, bool wellIsSolvable)
  {
    WellboreSchematicFlowSectionBuilder.FlowSectionsUnique sections = this._wellHead.IsFlowPathInjection(path) ? this.CreateInjectionFlowPathSections(path) : this.CreateProductionFlowPathSections(path, this.FindDepths());
    if (sections.Count <= 0)
      return (PipesimFlowPath) null;
    sections[0].FlowSource.ExtendsOutside = true;
    sections[sections.Count - 1].FlowSink.ExtendsOutside = true;
    return this.CreateSchematicFlowPath(casing, path, wellIsSolvable, (IList<FlowSection>) sections);
  }

  private PipesimFlowPath CreateSchematicFlowPath(
    TubularString casing,
    Slb.Production.Engineering.Model.StandardDomain.Extension.FlowPathNodes.FlowPath path,
    bool wellIsSolvable,
    IList<FlowSection> sections)
  {
    PipesimFlowPath schematicFlowPath = new PipesimFlowPath();
    schematicFlowPath.IsDraggable = false;
    schematicFlowPath.IsSelectable = false;
    WellString parentString = path[path.Count - 1].ParentString;
    string str1 = !DataHelper.IsNullObject((IDomainObject) parentString) ? (parentString.IsValidTubing ? CoreStrings.Tubing : CoreStrings.Casing) : CoreStrings.Well;
    string str2 = DataHelper.IsNullObject((IDomainObject) path[0].ParentObject) ? "Perforation" : path[0].ParentObject.Name;
   
