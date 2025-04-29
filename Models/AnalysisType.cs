using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class AnalysisType
{
    public byte Id { get; set; }

    public string AnalysisType1 { get; set; }

    public virtual ICollection<EngagmentTb> EngagmentTbs { get; set; } = new List<EngagmentTb>();
}
