using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using payc.Models;

namespace payc.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculationsApiController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public TaxCalculationsApiController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CalculateTax([FromBody] TaxCalculation taxCalculation)
        {
            if (ModelState.IsValid)
            {
                taxCalculation.TaxAmount = new TaxCalculator().CalculateTax(taxCalculation.PostalCode, taxCalculation.AnnualIncome);
                taxCalculation.CalculationDate = DateTime.Now;

                _dbContext.TaxCalculations.Add(taxCalculation);
                _dbContext.SaveChanges();

                return Ok(taxCalculation);
            }

            return BadRequest(ModelState);
        }
    }
}
