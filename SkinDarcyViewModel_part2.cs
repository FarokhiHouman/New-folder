pendentGasLiquidSkin;

  static SkinDarcyViewModel()
  {
    foreach (PointCompletionType key in Enum.GetValues(typeof (PointCompletionType)))
    {
      List<SkinComponentType> skinComponentTypeList = new List<SkinComponentType>();
      switch (key)
      {
        case PointCompletionType.OpenHole:
          skinComponentTypeList.Add(SkinComponentType.DamagedZone);
          skinComponentTypeList.Add(SkinComponentType.PartialPenetration);
          skinComponentTypeList.Add(SkinComponentType.Perforation);
          break;
        case PointCompletionType.Perforated:
          skinComponentTypeList.Add(SkinComponentType.DamagedZone);
          skinComponentTypeList.Add(SkinComponentType.PartialPenetration);
          skinComponentTypeList.Add(SkinComponentType.Perforation);
          skinComponentTypeList.Add(SkinComponentType.CompactedZone);
          break;
        case PointCompletionType.GravelPackedAndPerforated:
          skinComponentTypeList.Add(SkinComponentType.DamagedZone);
          skinComponentTypeList.Add(SkinComponentType.PartialPenetration);
          skinComponentTypeList.Add(SkinComponentType.GravelPack);
          skinComponentTypeList.Add(SkinComponentType.Perforation);
          skinComponentTypeList.Add(SkinComponentType.CompactedZone);
          break;
        case PointCompletionType.OpenHoleGravelPack:
          skinComponentTypeList.Add(SkinComponentType.DamagedZone);
          skinComponentTypeList.Add(SkinComponentType.PartialPenetration);
          skinComponentTypeList.Add(SkinComponentType.GravelPack);
          skinComponentTypeList.Add(SkinComponentType.Perforation);
          break;
        case PointCompletionType.FracPack:
          skinComponentTypeList.Add(SkinComponentType.PartialPenetration);
          skinComponentTypeList.Add(SkinComponentType.GravelPack);
          skinComponentTypeList.Add(SkinComponentType.Perforation);
          skinComponentTypeList.Add(SkinComponentType.FracPack
