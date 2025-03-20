using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class UserTb
{
    public int UserId { get; set; }

    public string UserName { get; set; }

    public string UserPhone { get; set; }

    public string UserEmail { get; set; }

    public string UserPassword { get; set; }

    public string UserImage { get; set; }

    public virtual ICollection<EngagmentTb> EngagmentTbs { get; set; } = new List<EngagmentTb>();

    public virtual ICollection<OrganizationTb> OrganizationTbs { get; set; } = new List<OrganizationTb>();

    public virtual ICollection<UserEngagmentTb> UserEngagmentTbs { get; set; } = new List<UserEngagmentTb>();

    public virtual ICollection<UserOrganizationTb> UserOrganizationTbs { get; set; } = new List<UserOrganizationTb>();
}
