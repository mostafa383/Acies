using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class AnlysManualEntry
{
    public int Id { get; set; }

    public int TransId { get; set; }

    public string Entries { get; set; }

    public string ColName { get; set; }
}
