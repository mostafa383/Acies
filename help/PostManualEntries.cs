using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject.help
{
    public class PostManualEntries
    {
        public int EngId { get; set; }
        public int? CurrencyId { get; set; }
        public string ColName { get; set; }
        public string Entries { get; set; }
        public string ExcludedKeywords { get; set; }
    }
}
