using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class CpViewFull
{
    public int? ControlPointId { get; set; }

    public double? ControlPointValue { get; set; }

    public string ControlPointName { get; set; }

    public int? ControlPointCaseId { get; set; }

    public double? ControlPointCaseValue { get; set; }

    public string ControlPointCaseName { get; set; }
}
