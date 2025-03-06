using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class CopmanySictb
{
    public int CopmanySicid { get; set; }

    public string CopmanySicname { get; set; }

    public string CopmanySicdescription { get; set; }

    public string CopmanySicindustry { get; set; }

    public virtual ICollection<EngagmentTb> EngagmentTbs { get; set; } = new List<EngagmentTb>();

    public virtual ICollection<OrganizationTb> OrganizationTbs { get; set; } = new List<OrganizationTb>();
}
