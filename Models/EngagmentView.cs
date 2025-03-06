using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class EngagmentView
{
    public int EngagmentId { get; set; }

    public string EngagmentName { get; set; }

    public string EngagmentDescription { get; set; }

    public DateOnly EngagmentCreatedDate { get; set; }

    public bool? EngagmentStatus { get; set; }

    public string EngagmentFile { get; set; }

    public int? UserId { get; set; }

    public string UserName { get; set; }

    public string UserImage { get; set; }

    public int? OrganizationId { get; set; }

    public string OrganizationName { get; set; }

    public int? CopmanySicid { get; set; }

    public string CopmanySicname { get; set; }

    public string CopmanySicindustry { get; set; }

    public int? ReportingFrequencyId { get; set; }

    public string ReportingFrequencyName { get; set; }

    public int? FinancialMangmentSystemId { get; set; }

    public string LibraryId { get; set; }

    public string LibraryName { get; set; }
}
