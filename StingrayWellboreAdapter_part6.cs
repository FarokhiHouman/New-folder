er<PropertyChangedEventArgs>(this.WellboreSchematicPropertyChanged);
      this._wellboreSchematic.DepthMappingMode = DepthMappingMode.Schematic;
    }
    finally
    {
      this._wellboreSchematic.EndUpdate();
    }
  }

  public void Detach()
  {
    this.ClearWatches();
    this._wellHead = (Slb.Production.Engineering.Model.StandardDomain.WellHead) null;
  }

  public void ShowFlowPath()
  {
    foreach (TubularString tubularString in (Collection<TubularString>) this._wellboreSchematic.Wellbore.TubularStrings)
    {
      foreach (BaseDownholeItem downholeItem in (Collection<BaseDownholeItem>) tubularString.DownholeItems)
      {
        if (downholeItem is PipesimFlowPath pipesimFlowPath)
        {
          int num = this.ShowFlowPathChecked ? 0 : 2;
          pipesimFlowPath.Visibility = (Visibility) num;
        }
      }
    }
  }

  public void Print()
  {
    if (this.WellboreSchematic != null)
    {
      PrintDialog printDialog = new PrintDialog();
      string tempFileName = TempRandomFile.GetTempFileName();
      this.WellboreSchematic.SaveToJpegFile(tempFileName, 96.0, 90);
      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.BeginInit();
      bitmapImage.UriSource = new Uri(tempFileName);
      bitmapImage.EndInit();
      DrawingVisual drawingVisual = new DrawingVisual();
      DrawingContext drawingContext = drawingVisual.RenderOpen();
      drawingContext.DrawImage((ImageSource) bitmapImage, new System.Windows.Rect(0.0, 0.0, this.WellboreSchematic.ActualWidth, this.WellboreSchematic.ActualHeight));
      drawingContext.Close();
      bool? nullable = printDialog.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      printDialog.PrintVisual((Visual) drawingVisual, "aa");
    }
    else
      this._viewService.Info(CoreStrings.PrinterNotFound, CoreStrings.PrinterNotFound);
  }

  public void HandleDime
