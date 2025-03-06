using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class Gen
{
    public int Id { get; set; }

    public byte UserId { get; set; }

    public byte CompanyId { get; set; }

    public DateTime Date { get; set; }

    public string Details { get; set; }

    public string Reference { get; set; }

    public string Notes { get; set; }

    public double? Debit { get; set; }

    public double? Credit { get; set; }

    public short Nominal { get; set; }

    public string Tt { get; set; }

    public string Account { get; set; }
}
