namespace AciesManagmentProject.Models
{
    public class account_monthly
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string RiskLevel { get; set; }
        public int  TransactionCount { get; set; }
        public double  AverageRiskPercent { get; set; }
    }
}
