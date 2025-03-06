using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class SampleTransactionsLrg1
{
    public decimal? CompanyNum { get; set; }

    public decimal? TransId { get; set; }

    public decimal? AccountId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public string Type { get; set; }

    public string Reference { get; set; }

    public string Debit { get; set; }

    public string Credit { get; set; }

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
