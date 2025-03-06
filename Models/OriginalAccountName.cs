using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class OriginalAccountName
{
    public int Id { get; set; }

    public int Engagementid { get; set; }

    public string AccountName { get; set; }

    public int? MappedAccountId { get; set; }

    public string Tags { get; set; }

    public virtual EngagmentTb Engagement { get; set; }

    public virtual ICollection<GeneralLedger> GeneralLedgers { get; set; } = new List<GeneralLedger>();

    public virtual Mapping MappedAccount { get; set; }
}
