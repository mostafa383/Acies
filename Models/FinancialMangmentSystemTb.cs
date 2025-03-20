using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class FinancialMangmentSystemTb
{
    public int FinancialMangmentSystemId { get; set; }

    public string FinancialMangmentSystemName { get; set; }

    public string FinancialMangmentSystemDescription { get; set; }

    public virtual ICollection<EngagmentTb> EngagmentTbs { get; set; } = new List<EngagmentTb>();
}
