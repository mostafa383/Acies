using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class EngagmentTb
{
    public int EngagmentId { get; set; }

    public string EngagmentName { get; set; }

    public string EngagmentDescription { get; set; }

    public DateOnly EngagmentCreatedDate { get; set; }

    public bool? EngagmentStatus { get; set; }

    public string EngagmentFile { get; set; }

    public int OwnerId { get; set; }

    public int OrganizationId { get; set; }

    public int? IndustryCode { get; set; }

    public int ReportingFrequencyId { get; set; }

    public int FinancialMangmentSystemId { get; set; }

    public int? LibraryId { get; set; }

    public byte? FiscalStartDay { get; set; }

    public byte? FiscalStartMonth { get; set; }

    public string Type { get; set; }

    public int? Currency { get; set; }

    public virtual ICollection<ControlPointCase> ControlPointCases { get; set; } = new List<ControlPointCase>();

    public virtual ICollection<ControlPoint> ControlPoints { get; set; } = new List<ControlPoint>();

    public virtual Currency CurrencyNavigation { get; set; }

    public virtual FinancialMangmentSystemTb FinancialMangmentSystem { get; set; }

    public virtual Industry IndustryCodeNavigation { get; set; }

    public virtual LibraryTb Library { get; set; }

    public virtual OrganizationTb Organization { get; set; }

    public virtual UserTb Owner { get; set; }

    public virtual ReportingFrequencyTb ReportingFrequency { get; set; }
}
