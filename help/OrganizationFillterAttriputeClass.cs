using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject.help
{
    public class OrganizationFillterAttriputeClass
    {
        public int PageNumber { get; set; }
        public int RowCount { get; set; }
        public int OwnerId { get; set; }
        public DateTime OrganizationStartTime { get; set; }
        public DateTime OrganizationFinishTime { get; set; }
        //public int EngagmentCount { get; set; }
        public bool OrganizationStatus { get; set; }
    }
}
