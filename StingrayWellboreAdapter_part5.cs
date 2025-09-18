mbol(bool isOpenHole = false)
  {
    Slb.Ocean.UI.WellboreSchematic.Perforation perforation = (Slb.Ocean.UI.WellboreSchematic.Perforation) new PerforationWellboreItemView();
    if (isOpenHole)
    {
      perforation.Background = (Brush) Brushes.Black;
      perforation.PerforationWidth = 20.0;
    }
    else
    {
      perforation.IsAlignedOutside = true;
      perforation.IsExcludeFromDepthMapping = true;
      perforation.Background = (Brush) Brushes.Black;
      perforation.BorderPen = (Pen) null;
      perforation.PerforationWidth = 20.0;
      perforation.MinHeight = 30.0;
      perforation.MinPerforationCount = 4;
      perforation.PerforationDistance = 7.0;
      perforation.Geometry = Geometry.Parse("M2,0 L2,2 0,1 Z");
    }
    return perforation;
  }

  public void Attach(Slb.Production.Engineering.Model.StandardDomain.WellHead wellHead)
  {
    this._wellHead = wellHead;
    this._wellboreSchematic.BeginUpdate();
    try
    {
      this._wellboreSchematic.WellboreItemCreated -= new EventHandler<WellboreEventArgs>(this.WellboreItemCreated);
      this._wellboreSchematic.WellboreItemDeleted -= new EventHandler<WellboreEventArgs>(this.WellboreItemDeleted);
      this._wellboreSchematic.WellboreItemMoved -= new EventHandler<WellboreEventArgs>(this.WellboreItemMoved);
      this._wellboreSchematic.PropertyChanged -= new EventHandler<PropertyChangedEventArgs>(this.WellboreSchematicPropertyChanged);
      this.ClearWatches();
      this._wellboreSchematic.Wellbore.View = WellSettings.Dimension;
      this.RedrawWell();
      this._wellboreSchematic.WellboreItemCreated += new EventHandler<WellboreEventArgs>(this.WellboreItemCreated);
      this._wellboreSchematic.WellboreItemDeleted += new EventHandler<WellboreEventArgs>(this.WellboreItemDeleted);
      this._wellboreSchematic.WellboreItemMoved += new EventHandler<WellboreEventArgs>(this.WellboreItemMoved);
      this._wellboreSchematic.PropertyChanged += new EventHandl
