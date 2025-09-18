
    switch (surveyType)
    {
      case DeviationSurveyType.VerticalDeviation:
        return true;
      case DeviationSurveyType.TwoDimensional:
        return num == 4;
      case DeviationSurveyType.ThreeDimensional:
        return num == 6;
      default:
        return false;
    }
  }
}

