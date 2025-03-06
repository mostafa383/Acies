using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class ControlPointCase
{
    public int EngagementId { get; set; }

    public int ControlPointId { get; set; }

    public int ControlPointCaseId { get; set; }

    public double ControlPointCaseValue { get; set; }

    public virtual DefaultControlPoint ControlPoint { get; set; }

    public virtual DefaultControlPointCase ControlPointCaseNavigation { get; set; }

    public virtual EngagmentTb Engagement { get; set; }
}
