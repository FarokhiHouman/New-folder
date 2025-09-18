// Decompiled with JetBrains decompiler
// Type: Slb.Production.Engineering.Views.Well.WellheadForWellPerspectiveModelContext
// Assembly: Slb.Production.Engineering.Views, Version=2023.1.615.0, Culture=neutral, PublicKeyToken=844175dfdbe2def2
// MVID: B478FF87-C86A-4166-A4D5-6AA7967E3F2C
// Assembly location: C:\Users\Farokhihouman\MAPSA\PipeSim\DLLS\Slb.Production.Engineering.Views.dll

using Slb.Production.Engineering.Model.Infrastructure.Data;
using Slb.Production.Engineering.UI.Infrastructure.ViewModelContexts;
using System;
using System.Runtime.Serialization;

#nullable disable
namespace Slb.Production.Engineering.Views.Well;

[Serializable]
public class WellheadForWellPerspectiveModelContext : ModelContext
{
  public WellheadForWellPerspectiveModelContext()
    : base((DurableId) null)
  {
  }

  protected WellheadForWellPerspectiveModelContext(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}
