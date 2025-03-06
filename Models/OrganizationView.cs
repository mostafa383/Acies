using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class OrganizationView
{
    public int OrganizationId { get; set; }

    public string OrganizationName { get; set; }

    public string OrganizationDescription { get; set; }

    public DateOnly OrganizationCreatedDate { get; set; }

    public bool? OrganizationStatus { get; set; }

    public int? UserId { get; set; }

    public string UserName { get; set; }

    public string UserImage { get; set; }

    public int? CopmanySicid { get; set; }

    public string CopmanySicname { get; set; }

    public string CopmanySicindustry { get; set; }

    public int? ReportingFrequencyId { get; set; }

    public string ReportingFrequencyName { get; set; }

    public int? FinancialMangmentSystemId { get; set; }

    public string FinancialMangmentSystemName { get; set; }
}
