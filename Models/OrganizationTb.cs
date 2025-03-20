using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class OrganizationTb
{
    public int OrganizationId { get; set; }

    public string OrganizationName { get; set; }

    public string OrganizationDescription { get; set; }

    public DateOnly OrganizationCreatedDate { get; set; }

    public bool? OrganizationStatus { get; set; }

    public int OwnerId { get; set; }

    public int? CompanySicid { get; set; }

    public int? IndustryCode { get; set; }

    public int ReportingFrequencyId { get; set; }

    public int FinancialMangmentSystemId { get; set; }

    public virtual CompanySic CompanySic { get; set; }

    public virtual ICollection<EngagmentTb> EngagmentTbs { get; set; } = new List<EngagmentTb>();

    public virtual Industry IndustryCodeNavigation { get; set; }

    public virtual UserTb Owner { get; set; }

    public virtual ReportingFrequencyTb ReportingFrequency { get; set; }

    public virtual ICollection<UserOrganizationTb> UserOrganizationTbs { get; set; } = new List<UserOrganizationTb>();
}
