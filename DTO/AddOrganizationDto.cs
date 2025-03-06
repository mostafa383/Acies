using System;

namespace AciesManagmentProject.DTO
{
    public class AddOrganizationDto
    {
        public string OrganizationName { get; set; }

        public string OrganizationDescription { get; set; }

        public DateOnly OrganizationCreatedDate { get; set; }

        public bool? OrganizationStatus { get; set; }

        public int OwnerId { get; set; }

        public int CopmanySicid { get; set; }

        public int ReportingFrequencyId { get; set; }

        public int FinancialMangmentSystemId { get; set; }
    }
}
