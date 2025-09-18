, ModelItemPort>()
  {
    {
      1,
      ModelItemPort.OutletTop
    },
    {
      2,
      ModelItemPort.OutletMiddle
    },
    {
      3,
      ModelItemPort.OutletBottom
    }
  };
  private static readonly IImmutableDictionary<ExportStatus, string> WellExportErrorMessageMap;

  public static bool FindWellHead(
    Equipment equipment,
    out WellHead foundWellHead,
    out WellString connectedWellString)
  {
    foundWellHead = (WellHead) null;
    connectedWellString = (WellString) null;
    List<WellHead> list = equipment.FindInnerBranches().SelectMany<Branch, Equipment>((Func<Branch, IEnumerable<Equipment>>) (b => (IEnumerable<Equipment>) b.Nodes)).OfType<WellHead>().Distinct<WellHead>().ToList<WellHead>();
    if (list.Count != 1)
      return false;
    WellHead wellInBranch = list.First<WellHead>();
    Branch branch = wellInBranch.FindInnerBranches().ToList<Branch>().FirstOrDefault<Branch>((Func<Branch, bool>) (b =>
    {
      if (!b.Nodes.Contains(equipment))
        return false;
      return b.FirstNode == (Equipment) wellInBranch || b.LastNode == (Equipment) wellInBranch;
    }));
    if (branch == null)
      return false;
    foundWellHead = wellInBranch;
    if (!foundWellHead.IsAdvancedType())
      return true;
    connectedWellString = WellCommands.FindConnectedWellStringFromBranch(wellInBranch, branch);
    return (object) (equipment as WellHead) != null || connectedWellString != (WellString) null;
  }

  private static WellString FindConnectedWellStringFromBranch(WellHead well, Branch branch)
  {
    if (!well.IsAdvancedType())
      return (WellString) null;
    IEnumerable<Equipment> branchEquipments = branch.Nodes.Except<Equipment>((IEnumerable<Equipment>) new WellHead[1]
    {
      well
    });
    if (!branchEquipments.Any<Equipment>())
      return (WellString) null;
    IEnumerable<KeyValuePair<int, ModelItemPort>> source = WellCommands.wellPortsMap.Where<KeyValuePair<int, Mod
