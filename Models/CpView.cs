using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class CpView
{
    public int EngagementId { get; set; }

    public int ControlPointId { get; set; }

    public double ControlPointValue { get; set; }

    public string ControlPointName { get; set; }
}
