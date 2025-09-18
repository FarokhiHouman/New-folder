// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.PackerViewModel
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Common;
using Slb.Production.Engineering.Model.Infrastructure.Hosting;
using Slb.Production.Engineering.Model.Infrastructure.Subscription;
using Slb.Production.Engineering.Model.Infrastructure.Toolkit.Common;
using Slb.Production.Engineering.Model.StandardDomain;
using Slb.Production.Engineering.UI;
using System;
using System.Windows.Media;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

public class PackerViewModel : DomainObjectPropertyBagViewModel<Packer>
{
  public PackerViewModel(Packer equipment)
    : base(equipment)
  {
    DownholeLocation location = equipment.Location as DownholeLocation;
    if (location != (DownholeLocation) null)
      this.LocationViewModel = this.RegisterContent<DownholeEquipmentLocationViewModel>(new DownholeEquipmentLocationViewModel(location, (NamedItem) equipment));
    this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) equipment, new EventHandler<DomainObjectChangeEventArgs>(this.DataSource_Changed)));
  }

  public override ImageSource Image => ImageKey.Packer.ToImageSource(ImageSizes.Image16);

  public DownholeEquipmentLocationViewModel LocationViewModel { get; private set; }

  private void DataSource_Changed(object sender, DomainObjectChangeEventArgs e)
  {
    foreach (string propertyName in e.PropertyNames)
    {
      this.OnPropertyChanged(propertyName);
      if (propertyName == "IsActive")
        this.LocationViewModel.RefreshValidation();
    }
  }
}
