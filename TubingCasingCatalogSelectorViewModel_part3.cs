Tubings.FirstOrDefault<Tubing>((Func<Tubing, bool>) (i =>
    {
      int? nullable = selectedTubingId;
      int id = i.ID;
      return nullable.GetValueOrDefault() == id & nullable.HasValue;
    }));
  }

  protected override bool OnValidate() => this.CanApplySelection((object) null);

  protected override bool OnCommit()
  {
    this.ApplySelection((object) null);
    return base.OnCommit();
  }

  private bool CanApplySelection(object o) => this.SelectedTubing != null;

  private void ApplySelection(object o)
  {
    if (!this.CanApplySelection(o))
      return;
    using (INuTransaction nuTransaction = NuDataManager.NewTransaction())
    {
      nuTransaction.Lock((object) this._domainObject);
      this._domainObject.CatalogLabel = this.SelectedTubing.Catalog;
      this._domainObject.CatalogName = this.SelectedTubing.Catalog;
      TubingSection domainObject1 = this._domainObject;
      double? nullable = this.SelectedTubing.InsideDiameter;
      double num1 = nullable ?? double.NaN;
      domainObject1.InnerDiameter = num1;
      TubingSection domainObject2 = this._domainObject;
      nullable = this.SelectedTubing.Roughness;
      double num2 = nullable ?? double.NaN;
      domainObject2.Roughness = num2;
      TubingSection domainObject3 = this._domainObject;
      nullable = this.SelectedTubing.WallThickness;
      double num3 = nullable ?? double.NaN;
      domainObject3.WallThickness = num3;
      this._domainObject.Grade = this.SelectedTubing.Grade;
      this._domainObject.SetDensityFromWeight(this.SelectedTubing.Weight);
      nuTransaction.Commit();
    }
  }
}

