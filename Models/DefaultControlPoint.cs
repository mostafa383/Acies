using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class DefaultControlPoint
{
    public int ControlPointId { get; set; }

    public string ControlPointName { get; set; }

    public double ControlPointValue { get; set; }

    public string Nature { get; set; }

    public virtual ICollection<ControlPointCase> ControlPointCases { get; set; } = new List<ControlPointCase>();

    public virtual ICollection<ControlPoint> ControlPoints { get; set; } = new List<ControlPoint>();

    public virtual ICollection<DefaultControlPointCase> DefaultControlPointCases { get; set; } = new List<DefaultControlPointCase>();
}
