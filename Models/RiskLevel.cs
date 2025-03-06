using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class RiskLevel
{
    public string Name { get; set; }

    public double StartValue { get; set; }

    public double EndValue { get; set; }
}
