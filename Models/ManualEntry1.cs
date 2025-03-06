using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class ManualEntry1
{
    public int Id { get; set; }

    public int EngagementId { get; set; }

    public string ColumnName { get; set; }

    public string Entries { get; set; }

    public string ExecludedKeywords { get; set; }
}
