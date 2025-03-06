using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject.help
{
    public class GeneralLedgerClass
    {
       
        public DateTime? Date { get; set; }
        public string Reference { get; set; }
        public double? Debit { get; set; }
        public double? Credit { get; set; }
        public string Account { get; set; }
        public string Tt { get; set; }
        public string Nominal { get; set; }
        public string Details { get; set; }
        public string Notes { get; set; }
    }
}
