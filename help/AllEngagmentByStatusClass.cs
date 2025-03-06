using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject.help
{
    public class AllEngagmentByStatusClass
    {
        public int PageNumber { get; set; }
        public int RowCount { get; set; }
        public int UserId { get; set; }
        public int OrganizationtId { get; set; }
        public bool? EngagmentStatus { get; set; }

    }
}
