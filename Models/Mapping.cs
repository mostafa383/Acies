using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class Mapping
{
    public int Id { get; set; }

    public string Account { get; set; }

    public string Category { get; set; }

    public string FullPath { get; set; }

    public virtual ICollection<OriginalAccountName> OriginalAccountNames { get; set; } = new List<OriginalAccountName>();
}
