using System.Text.Json;

namespace AciesManagmentProject.Models
{
    public class Res
    {
        public int ControlPointId { get; set; }
        public double ControlPointValue { get; set; }
        public double? ControlPointCaseValue { get; set; }
        public string ControlPointName { get; set; }
        public string ControlPointCaseName { get; set; }
        public int? ControlPointCaseId { get; set; }
    }
}
