using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class Industry
{
    public int Code { get; set; }

    public string Description { get; set; }

    public int? CompanySic { get; set; }
}
