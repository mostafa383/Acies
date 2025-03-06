using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class ManualEntry
{
    public int Id { get; set; }

    public int EngId { get; set; }

    public string ColName { get; set; }

    public string Entries { get; set; }

    public string ExcludedKeywords { get; set; }
}
