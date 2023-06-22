namespace payc.Models
{
    public class TaxCalculation
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal TaxAmount { get; set; }
        public DateTime CalculationDate { get; set; }
    }
}
