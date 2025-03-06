using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class UserEngagmentTb
{
    public int UserEngagmentId { get; set; }

    public int UserId { get; set; }

    public int EngagmentId { get; set; }

    public virtual EngagmentTb Engagment { get; set; }

    public virtual UserTb User { get; set; }
}
