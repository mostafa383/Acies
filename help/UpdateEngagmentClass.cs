using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject.help
{
    public class UpdateEngagmentClass
    {
        public string? EngagmentName { get; set; }
        public string? EngagmentDescription { get; set; }
        public DateOnly? EngagmentCreatedDate { get; set; }
        public bool? EngagmentStatus { get; set; }
        public IFormFile? EngagmentFile { get; set; }
        public int? OwnerId { get; set; }
        public int? OrganizationId { get; set; }
        public int? CopmanySicid { get; set; }
        public int? ReportingFrequencyId { get; set; }
        public int? CurrencyId { get; set; }
        public int? Code { get; set; }
        public int? FinancialMangmentSystemId { get; set; }
        public int? LibraryId { get; set; }
        public byte? AnalysisType { get; set; }

    }
}
