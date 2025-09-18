ubularStrings.FirstOrDefault<TubularString>((Func<TubularString, bool>) (ts => ts.TubularItems.Count > 0 && ts.TubularItems[0] is Tubing));
    foreach (Equipment equipment1 in (IEnumerable<Equipment>) wellString.DownholeEquipment)
    {
      this.AddWatch((ModelItem) equipment1);
      this.AddWatch((ModelItem) equipment1.Location);
      DownholeLocation location = equipment1.Location as DownholeLocation;
      if (!(location == (DownholeLocation) null))
      {
        Slb.Production.Engineering.Model.StandardDomain.Packer packer1 = equipment1 as Slb.Production.Engineering.Model.StandardDomain.Packer;
        BaseDownholeItem baseDownholeItem;
        TubularString currentString;
        if ((object) packer1 == null)
        {
          TubingPlug tubingPlug1 = equipment1 as TubingPlug;
          if ((object) tubingPlug1 == null)
          {
            Slb.Production.Engineering.Model.StandardDomain.SlidingSleeve slidingSleeve1 = equipment1 as Slb.Production.Engineering.Model.StandardDomain.SlidingSleeve;
            if ((object) slidingSleeve1 == null)
            {
              Slb.Production.Engineering.Model.StandardDomain.Perforation perforation = equipment1 as Slb.Production.Engineering.Model.StandardDomain.Perforation;
              if ((object) perforation == null)
              {
                Slb.Production.Engineering.Model.StandardDomain.ESP esp1 = equipment1 as Slb.Production.Engineering.Model.StandardDomain.ESP;
                if ((object) esp1 == null)
                {
                  PCP pcp1 = equipment1 as PCP;
                  if ((object) pcp1 == null)
                  {
                    RodPump rodPump1 = equipment1 as RodPump;
                    if ((object) rodPump1 == null)
                    {
                      GasLiftInjection gasLiftInjection1 = equipment1 as GasLiftInjection;
                      if ((object) gasLiftInjection1 == null)
                      {
                      
