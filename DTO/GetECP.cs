using System.Collections.Generic;

namespace AciesManagmentProject.DTO
{
    public class GetECP
    {
        public int ControlPointId { get; set; }
        public double ControlPointValue { get; set; }
        public string ControlPointName { get; set; }
        public List<GetECPC> Cases { get; set; }

    }
    public class GetECPC
    {
        public int? ControlPointCaseId { get; set; }
        public double? ControlPointCaseValue { get; set; }
        public string ControlPointCaseName { get; set; }
    }
}
