using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class ControlPointView
{
    public int? EngagementId { get; set; }

    public int? ControlPointId { get; set; }

    public string ControlPointName { get; set; }

    public double? ControlPointValue { get; set; }

    public int? ControlPointCaseId { get; set; }

    public string ControlPointCaseName { get; set; }

    public double? ControlPointCaseValue { get; set; }
}
