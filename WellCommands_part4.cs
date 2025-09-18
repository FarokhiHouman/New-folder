   WellCommands.ImportWellCommand = (ICommand) new RelayCommand(new Action<object>(WellCommands.OnImportWell), new Predicate<object>(WellCommands.OnCanImportWell));
    WellCommands.DeleteWellSelected = (ICommand) new RelayCommand(new Action<object>(WellCommands.OnDeleteWellSelected), new Predicate<object>(WellCommands.CanDeleteWell));
    WellCommands.WellExportErrorMessageMap = WellheadExporter.WellExportErrorMessageMap;
  }

  public static ICommand Launch { get; private set; }

  public static ICommand CreateNewWithoutTemplateAndLaunch { get; private set; }

  public static ICommand CreateNewWithTemplateAndLaunch { get; private set; }

  public static ICommand SaveAsTemplate { get; private set; }

  public static ICommand SetEquipmentAsWellStreamOutlet { get; private set; }

  public static ICommand WellStateChanged { get; private set; }

  public static ICommand ImportWellCommand { get; private set; }

  public static ICommand ExportWellCommand { get; private set; }

  public static ICommand DeleteWellSelected { get; private set; }

  private static void RegisterViews()
  {
    IViewService service = ServiceDirectory.GetService<IViewService>();
    if (service == null)
      return;
    service.RegisterMainView<IModelContext, WellheadForWellPerspectiveViewModel, WellheadForWellPerspectiveView>(new Func<IModelContext, WellheadForWellPerspectiveViewModel>(WellCommands.ViewModelFactory), new Func<Stream, IModelContext>(StreamSerializer.Deserialize<WellheadForWellPerspectiveModelContext>), (Func<IModelContext, WellheadForWellPerspectiveViewModel, bool>) ((context, model) => true));
    service.DefaultViewLaunched += new EventHandler<ViewLauncherEventArgs>(WellCommands.viewService_DefaultViewLaunched);
  }

  private static void viewService_DefaultViewLaunched(object sender, ViewLauncherEventArgs e)
  {
    if (e.WorkspaceType != WorkspaceType.Well)
      return;
    WellCommands.OnLaunch((object) null);
  }

  private static W
