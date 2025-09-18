    case "BottomMD":
        return "TopMeasuredDepth";
      case "OutD":
        if (enterOdValue)
          return "InnerDiameter";
        break;
      case "InD":
        return "InnerDiameter";
      case "WallThickness":
        if (!enterOdValue)
          return "WallThickness";
        break;
      case "SectionRoughness":
        if (!enterOdValue)
          return "Roughness";
        break;
      default:
        return (string) null;
    }
    return (string) null;
  }

  protected override bool SupportsValidationSystemErrors => true;

  protected override IEnumerable<string> ViewModelProperties
  {
    get => (IEnumerable<string>) TubingSectionViewModel._viewModelPropertiesMap.Keys;
  }

  protected override IEnumerable<ValidationIssue> GetRelevantIssues(ValidateArgs e)
  {
    return (IEnumerable<ValidationIssue>) e.Issues.Where<ValidationIssue>((Func<ValidationIssue, bool>) (x => (object) x.PropertyOwner == (object) this.DataSource && this.ViewModelProperties.Contains<string>(x.Property))).ToList<ValidationIssue>();
  }

  public override bool HasPropertyErrorThroughValidation(string propertyName)
  {
    string key;
    return TubingSectionViewModel.ViewModelPropertiesMapInverse.TryGetValue(propertyName, out key) && this.propertyErrors.ContainsKey(key);
  }

  protected override string GetPropertyError(string propertyName)
  {
    string key;
    return this.propertyErrors.Count == 0 || !TubingSectionViewModel.ViewModelPropertiesMapInverse.TryGetValue(propertyName, out key) || !this.propertyErrors.ContainsKey(key) ? string.Empty : this.propertyErrors[key];
  }

  protected override void TriggerValidateProperty()
  {
    foreach (string key in TubingSectionViewModel.ViewModelPropertiesMapInverse.Keys)
      this.OnPropertyChanged(key);
  }
}

