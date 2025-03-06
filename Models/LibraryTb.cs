using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class LibraryTb
{
    public int LibraryId { get; set; }

    public string LibraryName { get; set; }

    public string LibraryDescription { get; set; }

    public virtual ICollection<EngagmentTb> EngagmentTbs { get; set; } = new List<EngagmentTb>();
}
