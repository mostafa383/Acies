using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class ManualEntriesExecludedKeyword
{
    public int ManualEntryId { get; set; }

    public string Keyword { get; set; }

    public virtual ManualEntry1 ManualEntry { get; set; }
}
