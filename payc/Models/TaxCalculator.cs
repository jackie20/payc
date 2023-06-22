namespace payc.Models
{
    public class TaxCalculator
    {
        public decimal CalculateTax(string postalCode, decimal annualIncome)
        {
            // Tax calculation logic based on postal code and annual income
            decimal tax = 0;

            if (postalCode == "7441")
            {
                // Progressive tax calculation
                if (annualIncome >= 0 && annualIncome <= 8350)
                    tax = annualIncome * 0.1m;
                else if (annualIncome > 8350 && annualIncome <= 33950)
                    tax = 8350 * 0.1m + (annualIncome - 8350) * 0.15m;
                else if (annualIncome > 33950 && annualIncome <= 82250)
                    tax = 8350 * 0.1m + (33950 - 8350) * 0.15m + (annualIncome - 33950) * 0.25m;
                else if (annualIncome > 82250 && annualIncome <= 171550)
                    tax = 8350 * 0.1m + (33950 - 8350) * 0.15m + (82250 - 33950) * 0.25m + (annualIncome - 82250) * 0.28m;
                else if (annualIncome > 171550 && annualIncome <= 372950)
                    tax = 8350 * 0.1m + (33950 - 8350) * 0.15m + (82250 - 33950) * 0.25m + (171550 - 82250) * 0.28m + (annualIncome - 171550) * 0.33m;
                else if (annualIncome > 372950)
                    tax = 8350 * 0.1m + (33950 - 8350) * 0.15m + (82250 - 33950) * 0.25m + (171550 - 82250) * 0.28m + (372950 - 171550) * 0.33m + (annualIncome - 372950) * 0.35m;
            }
            else if (postalCode == "A100")
            {
                // Flat value tax calculation
                tax = 10000;
            }
            else if (postalCode == "7000")
            {
                // Flat rate tax calculation
                tax = annualIncome * 0.175m;
            }
            else if (postalCode == "1000")
            {
                // Progressive tax calculation
                if (annualIncome < 200000)
                    tax = annualIncome * 0.05m;
                else
                    tax = annualIncome * 0.33m;
            }

            return tax;
        }
    }
}
