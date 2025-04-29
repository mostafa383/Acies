using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class AnlysCpsValue
{
    public long Id { get; set; }

    public long Transid { get; set; }

    public int ControlPoint { get; set; }

    public int? Cpcase { get; set; }

    public virtual Transaction Trans { get; set; }
}
