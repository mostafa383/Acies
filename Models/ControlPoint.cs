using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class ControlPoint
{
    public int EngagementId { get; set; }

    public int ControlPointId { get; set; }

    public double ControlPointValue { get; set; }

    public virtual DefaultControlPoint ControlPointNavigation { get; set; }

    public virtual EngagmentTb Engagement { get; set; }
}
