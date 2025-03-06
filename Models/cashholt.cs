namespace AciesManagmentProject.Models
{
    public class cashholt
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public double HoltWintersMin { get; set; }
        public double HoltWintersMax { get; set; }
        public double HoltWintersForecast { get; set; }
        public double AmountOutBy { get; set; }
        public string HoltWintersStatus { get; set; }
        public double TotalCash { get; set; }
    }
}
