 customExpander.Padding = new Thickness(0.0, 0.0, 0.0, 0.0);
          customExpander.Header = (object) CoreStrings.SurfaceEquipmentConnected;
          customExpander.Name = "SurfaceEquipmentControl";
          customExpander.IsExpanded = true;
          ScrollViewer scrollViewer = new ScrollViewer();
          scrollViewer.MaxHeight = 50.0;
          StackPanel stackPanel = new StackPanel();
          foreach (NamedItem watchedBranchItem in this._watchedBranchItems)
          {
            if (watchedBranchItem != (NamedItem) this._wellHead)
            {
              watchedBranchItem.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.EquipmentChanged);
              watchedBranchItem.Changed += new EventHandler<DomainObjectChangeEventArgs>(this.EquipmentChanged);
              Equipment equipment = watchedBranchItem as Equipment;
              if (equipment != (Equipment) null)
              {
                Connection connection1 = equipment.ConnectionsFrom.FirstOrDefault<Connection>();
                Connection connection2 = equipment.ConnectionsTo.FirstOrDefault<Connection>();
                if (connection1 != (Connection) null)
                {
                  connection1.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.ConnectionChanged);
                  connection1.Changed += new EventHandler<DomainObjectChangeEventArgs>(this.ConnectionChanged);
                }
                if (connection2 != (Connection) null)
                {
                  connection2.Changed -= new EventHandler<DomainObjectChangeEventArgs>(this.ConnectionChanged);
                  connection2.Changed += new EventHandler<DomainObjectChangeEventArgs>(this.ConnectionChanged);
                }
              }
              MenuItem newItem = new MenuItem();
              newItem.Tag = (object) watchedBranchItem;
              newItem.Header = (object) watchedBranchItem.Name;
              newItem.CommandParameter =
