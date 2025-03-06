using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class ManualEntriesEntry
{
    public int ManualEntryId { get; set; }

    public string Entry { get; set; }

    public virtual ManualEntry1 ManualEntry { get; set; }
}
