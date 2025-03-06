using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class ControlPointV
{
    public int ControlPointId { get; set; }

    public double ControlPointValue { get; set; }

    public string ControlPointName { get; set; }

    public int EngagementId { get; set; }
}
