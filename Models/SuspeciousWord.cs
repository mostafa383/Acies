using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class SuspeciousWord
{
    public int Id { get; set; }
    public int EngagementId { get; set; }

    public string Word { get; set; }
}
