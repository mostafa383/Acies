using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class UserOrganizationTb
{
    public int UserOrganizationId { get; set; }

    public int UserId { get; set; }

    public int OrganizationId { get; set; }

    public virtual OrganizationTb Organization { get; set; }

    public virtual UserTb User { get; set; }
}
