using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class EngagmentUserView
{
    public int EngagmentId { get; set; }

    public string EngagmentName { get; set; }

    public string EngagmentDescription { get; set; }

    public DateOnly EngagmentCreatedDate { get; set; }

    public bool? EngagmentStatus { get; set; }

    public string EngagmentFile { get; set; }

    public int? OrganizationId { get; set; }

    public string OrganizationName { get; set; }

    public int? UserId { get; set; }

    public string UserName { get; set; }

    public string UserImage { get; set; }
}
