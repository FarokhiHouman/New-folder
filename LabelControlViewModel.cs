// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.LabelControlViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Common.Events;
using Slb.Production.Engineering.Common.Extension;
using Slb.Production.Engineering.Model.Infrastructure.Basics;
using Slb.Production.Engineering.Model.StandardDomain;
using System;
using System.Collections.Generic;
using System.Windows;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

internal class LabelControlViewModel : DomainObjectViewModel<NamedItem>
{
  private WeakEventListener<ValidateArgs> validateListener;
  private bool showText;
  private bool showValidation;
  private bool isValid = true;

  public LabelControlViewModel(NamedItem item, bool showText, bool showValidation)
    : base(item)
  {
    this.showText = showText;
    this.showValidation = showValidation;
    if (!this.showValidation)
      return;
    IValidationService service = ServiceDirectory.GetService<IValidationService>();
    this.validateListener = new WeakEventListener<ValidateArgs>(new EventHandler<ValidateArgs>(this.validationService_Validated));
    WeakEventManagerBase<ValidationEventManager, IValidationService>.AddListener(service, (IWeakEventListener) this.validateListener);
  }

  private void validationService_Validated(object sender, ValidateArgs e)
  {
    bool flag = true;
    foreach (ValidationIssue issue in (IEnumerable<ValidationIssue>) e.Issues)
    {
      if (issue.IsAffected((IValidation) this.DataSource))
      {
        flag = false;
        break;
      }
    }
    if (flag == this.isValid)
      return;
    this.isValid = flag;
    this.OnPropertyChanged("TickVisibility");
    this.OnPropertyChanged("CrossVisibility");
  }

  public string Name => this.DataSource.Name;

  public Visibility TextVisibility => !this.showText ? Visibility.Collapsed : Visibility.Visible;

  public Visibility TickVisibility
  {
    get => !this.isValid || !this.showValidation ? Visibility.Collapsed : Visibility.Visible;
  }

  public Visibility CrossVisibility
  {
    get => this.isValid || !this.showValidation ? Visibility.Collapsed : Visibility.Visible;
  }
}
