
    this.Roughness = nullable ?? double.NaN;
    int? userDefined = tubing2.UserDefined;
    int num = 1;
    this.UserDefined = userDefined.GetValueOrDefault() == num & userDefined.HasValue;
  }

  public override string Title => !this._isCasing ? CoreStrings.Tubing : CoreStrings.Casing;

  public int ID { get; set; }

  public bool UserDefined { get; set; }

  public string Name { get; set; }

  public double OutsideDiameter { get; set; }

  public double InsideDiameter { get; set; }

  public double Roughness { get; set; }

  public double Weight { get; set; }

  public string Grade { get; set; }

  public string Catalog { get; set; }

  public override int EntityId => this.ID;
}

