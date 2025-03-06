using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class DefaultControlPointCase
{
    public int ControlPointCaseId { get; set; }

    public string ControlPointCaseName { get; set; }

    public double ControlPointCaseValue { get; set; }

    public int ControlPointId { get; set; }

    public virtual DefaultControlPoint ControlPoint { get; set; }

    public virtual ICollection<ControlPointCase> ControlPointCases { get; set; } = new List<ControlPointCase>();
}
