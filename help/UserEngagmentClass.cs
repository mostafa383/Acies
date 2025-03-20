using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject.help
{
    public class UserEngagmentClass
    {
        public int? EngagmentId { get; set; }
        public string EngagmentName { get; set; }
        public string EngagmentDescription { get; set; }
        public DateTime EngagmentCreatedDate { get; set; }
        public bool? EngagmentStatus { get; set; }
        public int OrganizationId { get; set; }
        public string OwnerName { get; set; }
        public int? CopmanySicid { get; set; }
        public int? Code{ get; set; }
        public int ReportingFrequencyId { get; set; }
        public int FinancialMangmentSystemId { get; set; }
        public byte? FiscalStartDay { get; set; }
        public byte? FiscalStartMonth { get; set; }
        public int? CurrrencyId { get; set; }

        public string CurrrencyName { get; set; }

        public string CurrrencyShortName { get; set; }

        public string CurrrencySymbol { get; set; }
        public List<UserOrganizationAttriputeClass> Users { get; set; }
    }
}
