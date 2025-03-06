using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class ReportingFrequencyTb
{
    public int ReportingFrequencyId { get; set; }

    public string ReportingFrequencyName { get; set; }

    public string ReportingFrequencyDescription { get; set; }

    public virtual ICollection<EngagmentTb> EngagmentTbs { get; set; } = new List<EngagmentTb>();

    public virtual ICollection<OrganizationTb> OrganizationTbs { get; set; } = new List<OrganizationTb>();
}
