using System;
using System.Collections.Generic;

namespace AciesManagmentProject.Models;

public partial class OriginalAccountName
{
    public int Id { get; set; }

    public int Engagementid { get; set; }

    public string AccountName { get; set; }

    public int? MappedAccountId { get; set; }

    public string Tags { get; set; }

    public virtual ICollection<AccountsPayable> AccountsPayables { get; set; } = new List<AccountsPayable>();

    public virtual ICollection<AccountsReceivable> AccountsReceivables { get; set; } = new List<AccountsReceivable>();

    public virtual ICollection<GeneralLedgerInternal> GeneralLedgerInternals { get; set; } = new List<GeneralLedgerInternal>();

    public virtual Mapping MappedAccount { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
