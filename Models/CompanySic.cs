using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class CompanySic
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Industry> Industries { get; set; } = new List<Industry>();

    public virtual ICollection<OrganizationTb> OrganizationTbs { get; set; } = new List<OrganizationTb>();
}
