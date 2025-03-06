using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class OrganizationUserView
{
    public int OrganizationId { get; set; }

    public string OrganizationName { get; set; }

    public string OrganizationDescription { get; set; }

    public DateOnly OrganizationCreatedDate { get; set; }

    public bool? OrganizationStatus { get; set; }

    public int? UserId { get; set; }

    public string UserName { get; set; }

    public string UserImage { get; set; }
}
