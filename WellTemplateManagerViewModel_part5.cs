t"))
      return;
    using (this._collectionChangedSubscription.Suspend())
    {
      List<DurableId> listDroids = this._stateService.InputContext.ToList<DurableId>();
      this.SelectedItem = this.WellDisplays.FirstOrDefault<WellTemplateViewModel>((Func<WellTemplateViewModel, bool>) (item => listDroids.Any<DurableId>((Func<DurableId, bool>) (droid => droid.Equals(item.DataSource.DurableId)))));
    }
  }

  private delegate void TemplateWellChangedHandlerDelegate(
    object sender,
    NotifyCollectionChangedEventArgs e);
}

