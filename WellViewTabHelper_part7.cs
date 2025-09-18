holeLocation;
      criteria.Top = 1;
      IList<Equipment> source = FacadeAccessor.Query<Equipment>(dataSource, (AbstractQueryCriteria) criteria);
      if (source.Count > 0)
        newValue = (object) source.First<Equipment>();
    }
    int selectedTabIndex = 0;
    Type type = newValue.GetType();
    DebugLogger.Info($"Type is:{type}", DebugLogger.LogInfoType.LogInfoWellEditor);
    Func<object, WellEditorTabs> func;
    if (WellViewTabHelper.ModelItemDictionary.TryGetValue(type, out func))
    {
      DebugLogger.Info($"item:{type.Name} is converted to selIndex:{func(newValue)}, which is:{(int) func(newValue)}", DebugLogger.LogInfoType.LogInfoWellEditor);
      selectedTabIndex = (int) func(newValue);
    }
    else if ((object) (newValue as CompletionModel) != null)
    {
      selectedTabIndex = 6;
    }
    else
    {
      WellString wellString = newValue as WellString;
      if ((object) wellString != null && wellString.IsValidTubing)
        selectedTabIndex = 3;
      else if ((object) (newValue as Slb.Production.Engineering.Model.StandardDomain.WellHead) != null && validationIssue != null)
      {
        switch (validationIssue.Property)
        {
          case "WellheadDepth":
            selectedTabIndex = 1;
            break;
          case "HeatTransferSurveyLessThanTwoPoints":
          case "AmbientTemperature":
            selectedTabIndex = 2;
            break;
        }
      }
    }
    return selectedTabIndex;
  }
}

