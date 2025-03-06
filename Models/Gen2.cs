using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class Gen2
{
    public int? CompanyNum { get; set; }

    public int? TransId { get; set; }

    public int? AccountId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public string Type { get; set; }

    public string Reference { get; set; }

    public double? Debit { get; set; }

    public double? Credit { get; set; }

    public string Bank { get; set; }

    public string Branch { get; set; }

    public string Account { get; set; }

    public string Tt { get; set; }

    public string Nominal { get; set; }

    public string Currency { get; set; }

    public string CreatedUser { get; set; }

    public string CreatedDate { get; set; }

    public string SpareText { get; set; }

    public string SpareNum { get; set; }

    public string SpareDate { get; set; }
}
