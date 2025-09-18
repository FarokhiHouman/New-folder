e;

  public static void OnImportWell(object parameter)
  {
    IWellImportService service = ServiceDirectory.GetService<IWellImportService>();
    bool wellViewExists = ServiceDirectory.GetService<IViewService>().ViewExists(typeof (WellHeadView));
    service.ImportWell(wellViewExists, service.Initialize(parameter));
  }

  private static bool OnCanSetEquipmentAsWellStreamOutlet(object parameter)
  {
    return WellCommands.CanFindWellAndCanSetWellStreamOutlet(parameter, out WellHead _, out Equipment _, out WellString _);
  }

  private static void OnSetEquipmentAsWellStreamOutlet(object parameter)
  {
    WellHead wellHead;
    Equipment equipment;
    WellString wellString1;
    if (!WellCommands.CanFindWellAndCanSetWellStreamOutlet(parameter, out wellHead, out equipment, out wellString1))
      return;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      if (wellHead.IsAdvancedType())
      {
        if ((object) (equipment as WellHead) != null)
        {
          foreach (WellString wellString2 in (IEnumerable<WellString>) wellHead.DefaultBorehole.WellStrings)
          {
            nuTransaction.Lock((object) wellString2);
            wellString2.OutletEquipment = equipment;
          }
        }
        else if (wellString1 != (WellString) null)
        {
          nuTransaction.Lock((object) wellString1);
          wellString1.OutletEquipment = equipment;
        }
      }
      else
      {
        nuTransaction.Lock((object) wellHead);
        wellHead.WellOutletEquipment = equipment;
      }
      nuTransaction.Commit();
    }
  }

  private static void OnExportWell(object parameter)
  {
    WellHead wellHead = parameter as WellHead;
    if ((object) wellHead == null)
      return;
    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
    saveFileDialog1.AddExtension = true;
    saveFileDialog1.Filter = CoreStrings.SaveAsFilter;
    saveFileDialog1.FilterIndex 
