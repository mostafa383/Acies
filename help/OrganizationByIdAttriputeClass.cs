﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject.help
{
    public class OrganizationByIdAttriputeClass
    {
        public int OrganizationId { get; set; }
        public int? Code { get; set; }
        public int? SIC { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDescription { get; set; }
        public DateTime OrganizationCreatedDate { get; set; }
        public bool? OrganizationStatus { get; set; }
        public string OwnerName { get; set; }
        public List<UserOrganizationAttriputeClass> Users { get; set; }
    }
}
