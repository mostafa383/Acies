using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class Currency
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string ShortName { get; set; }

    public string Symbol { get; set; }

    public virtual ICollection<EngagmentTb> EngagmentTbs { get; set; } = new List<EngagmentTb>();
}
