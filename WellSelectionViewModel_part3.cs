leId>() : selectedValueDurableId;
    }
  }

  public bool IsMatch(DurableId itemId)
  {
    WellHead wellHead = itemId.TryResolveAs<WellHead>();
    return wellHead != (WellHead) null && wellHead.IsGood && !wellHead.IsTemplate;
  }

  protected override void OnSelectionChanged(NamedItemViewModel newValue)
  {
    if (newValue == null)
      return;
    this._stateService.SetInputContext(newValue.DataSource.DurableId, (object) this);
  }

  protected override ObservableCollection<NamedItemViewModel> CleanupAndRequeryItemsInternally()
  {
    Slb.Production.Engineering.Model.StandardDomain.Model currentWorkspaceModel = DataHelper.GetCurrentWorkspaceModel();
    if (!(currentWorkspaceModel != (Slb.Production.Engineering.Model.StandardDomain.Model) null) || !currentWorkspaceModel.IsGood)
      return new ObservableCollection<NamedItemViewModel>();
    List<WellHead> list1 = currentWorkspaceModel.DefaultNetwork.Wells.Where<WellHead>((Func<WellHead, bool>) (x => !x.IsTemplate)).ToList<WellHead>();
    using (FacadeAccessor.PrimeProperties<WellHead>((IEnumerable<WellHead>) list1, (string[]) null))
    {
      EquipmentAccessor.PrimeLocation((IEnumerable<Equipment>) list1, (string[]) null);
      List<NamedItemViewModel> list2 = list1.Select<WellHead, NamedItemViewModel>((Func<WellHead, NamedItemViewModel>) (x => this.RegisterContent<NamedItemViewModel>(new NamedItemViewModel((NamedItem) x)))).ToList<NamedItemViewModel>();
      list2.Sort();
      return new ObservableCollection<NamedItemViewModel>(list2);
    }
  }

  private void AddCommands()
  {
    this.Commands.Add(this.RegisterContent<ButtonDefinition>(new ButtonDefinition((string) null, WellCommands.DeleteWellSelected, (object) typeof (WellHead), ImageKey.Delete, string.Format(CoreStrings.DeleteSelectedType_Tooltip, (object) CoreStrings.Well.ToLower()), ButtonSize.Medium)));
    this.Commands.Add(this.RegisterContent<ButtonDefinition>(new ButtonDefinition((string) null, WellComma
