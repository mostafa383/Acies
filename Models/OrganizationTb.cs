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

    public int CopmanySicid { get; set; }

    public int ReportingFrequencyId { get; set; }

    public int FinancialMangmentSystemId { get; set; }

    public virtual CopmanySictb CopmanySic { get; set; }

    public virtual ICollection<EngagmentTb> EngagmentTbs { get; set; } = new List<EngagmentTb>();

    public virtual FinancialMangmentSystemTb FinancialMangmentSystem { get; set; }

    public virtual UserTb Owner { get; set; }

    public virtual ReportingFrequencyTb ReportingFrequency { get; set; }

    public virtual ICollection<UserOrganizationTb> UserOrganizationTbs { get; set; } = new List<UserOrganizationTb>();
}
