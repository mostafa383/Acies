using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class GeneralLedger1
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int CompanyId { get; set; }

    public DateTime? Date { get; set; }

    public string Details { get; set; }

    public string Reference { get; set; }

    public string Notes { get; set; }

    public double? Debit { get; set; }

    public double? Credit { get; set; }

    public double? Nominal { get; set; }

    public string Tt { get; set; }

    public string Account { get; set; }
}
