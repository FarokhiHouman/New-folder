// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.Tubulars.CasingDetailedViewValidation
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.Model.StandardDomain.Properties;
using Slb.Production.Engineering.Model.StandardDomain.Validators;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

#nullable disable
namespace Slb.Production.Engineering.Views.Well.Tubulars;

public class CasingDetailedViewValidation : System.Windows.Controls.ValidationRule
{
  protected virtual SectionType SectionType => SectionType.Casing;

  private IEnumerable<ValidationIssue> GetValidIssues(
    WellHead well,
    ICollection<WellString> wellStringCollection)
  {
    foreach (ValidationIssue validateTubularRelation in WellHeadValidator.ValidateTubularRelations(well, (ConcurrentDictionary<ValidationIssueKey, ValidationIssue>) null, (Dictionary<ValidationRuleKey, Slb.Production.Engineering.Model.StandardDomain.ValidationRule>) null, (string) null, wellStringCollection))
    {
      if (validateTubularRelation.ExtraInfo is SectionType extraInfo && extraInfo == this.SectionType)
        yield return validateTubularRelation;
    }
  }

  public override ValidationResult Validate(object value, CultureInfo cultureInfo)
  {
    BindingGroup bindingGroup = (BindingGroup) value;
    if (bindingGroup == null || bindingGroup.Items == null || bindingGroup.Items.Count < 1)
      return new ValidationResult(false, (object) Cor
