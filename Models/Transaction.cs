using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class Transaction
{
    public long Id { get; set; }

    public int? EngagementId { get; set; }

    public DateTime? Date { get; set; }

    public string Reference { get; set; }

    public double? Debit { get; set; }

    public double? Credit { get; set; }

    public int? Account { get; set; }

    public string Tt { get; set; }

    public string Nominal { get; set; }

    public string Details { get; set; }

    public string Notes { get; set; }

    public double? TotalCp { get; set; }

    public double? Riskpercent { get; set; }

    public virtual OriginalAccountName AccountNavigation { get; set; }

    public virtual ICollection<AnlysCpsValue> AnlysCpsValues { get; set; } = new List<AnlysCpsValue>();

    public virtual EngagmentTb Engagement { get; set; }
}
