ct, object>("topic://DownholeEquipmentWellStringChanged", (object) null, (object) null));
    StateMessageDisplayHelper.DisplayStateMessage(CoreStrings.MoveEquipment, (object) this.GetDownholeEquipmentType(baseWellboreItem), (object) baseWellboreItem.Label);
  }

  private void WellboreItemDeleted(object sender, WellboreEventArgs e)
  {
    BaseWellboreItem baseWellboreItem = e.Item;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      if ((object) (baseWellboreItem.Tag as NamedItem) != null)
      {
        NamedItem tag = (NamedItem) baseWellboreItem.Tag;
        if (tag is IOperationContext operationContext)
          OperationExtension.DeleteOperationContextData(operationContext);
        this.RemoveWatch((ModelItem) tag);
        if ((object) (tag as Equipment) != null)
          this.RemoveWatch((ModelItem) ((Equipment) tag).Location);
        else if ((object) (tag as MeasurementPoint) != null)
          this.RemoveWatch((ModelItem) ((MeasurementPoint) tag).Location);
        nuTransaction.Lock((object) tag);
        FacadeAccessor.Delete<NamedItem>(tag);
        nuTransaction.Commit();
        StateMessageDisplayHelper.DisplayStateMessage(CoreStrings.DeleteEquipment, (object) this.GetDownholeEquipmentType(baseWellboreItem), (object) baseWellboreItem.Label);
      }
      else if ((object) (baseWellboreItem.Tag as ZoneLink) != null)
      {
        ZoneLink tag = (ZoneLink) baseWellboreItem.Tag;
        nuTransaction.Lock((object) tag.Borehole, (object) tag);
        this.RemoveWatch((ModelItem) tag);
        ZoneLinkAccessor.GetFacadeAccessor(this._domainObjectHost).Delete(tag);
        nuTransaction.Commit();
        StateMessageDisplayHelper.DisplayStateMessage(CoreStrings.DeleteEquipment, (object) this.GetDownholeEquipmentType(baseWellboreItem), (object) baseWellboreItem.Label);
      }
      this._wellHead?.RefreshFlowPath();
    }
  }

  private void WellboreItemCreated(object sender,
