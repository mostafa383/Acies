using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class Industry
{
    public int Code { get; set; }

    public string Description { get; set; }

    public int? CompanySic { get; set; }

    public virtual CompanySic CompanySicNavigation { get; set; }

    public virtual ICollection<EngagmentTb> EngagmentTbs { get; set; } = new List<EngagmentTb>();

    public virtual ICollection<OrganizationTb> OrganizationTbs { get; set; } = new List<OrganizationTb>();
}
