﻿namespace AciesManagmentProject.Models
{
    public class breakdownYearly
    {
        public int Period { get; set; }
        public string RiskLevel { get; set; }
        public string AggType { get; set; }
        public int TransactionCount { get; set; }
        public double AverageRiskPercent { get; set; }
    }
}
