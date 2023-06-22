using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using payc.Models;

namespace payc.Controllers
{
    public class TaxCalculationsController : Controller
    {
       
            private readonly AppDbContext _dbContext;

            public TaxCalculationsController(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public IActionResult Index()
            {
                var taxCalculations = _dbContext.TaxCalculations;
                return View(taxCalculations);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(TaxCalculation taxCalculation)
            {
                if (ModelState.IsValid)
                {
                    taxCalculation.TaxAmount = new TaxCalculator().CalculateTax(taxCalculation.PostalCode, taxCalculation.AnnualIncome);
                    taxCalculation.CalculationDate = DateTime.Now;

                    _dbContext.TaxCalculations.Add(taxCalculation);
                    _dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(taxCalculation);
            }






        // GET: TaxCalculations/EditIncome/5
        public IActionResult EditIncome(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxCalculation = _dbContext.TaxCalculations.Find(id);
            if (taxCalculation == null)
            {
                return NotFound();
            }
            return View(taxCalculation);
        }

        // POST: TaxCalculations/EditIcome/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditIncome(int id, TaxCalculation taxCalculation)
        {
            if (id != taxCalculation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.TaxCalculations.Update(taxCalculation);
                    _dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taxCalculation);
        }

        // GET: TaxCalculations/DeleteIncome/5
        public IActionResult DeleteIncome(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxCalculation = _dbContext.TaxCalculations.Find(id);
            if (taxCalculation == null)
            {
                return NotFound();
            }

            return View(taxCalculation);
        }

        // POST: TaxCalculations/DeleteIncome/5
        [HttpPost, ActionName("DeleteIncome")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var taxCalculation = _dbContext.TaxCalculations.Find(id);
            if (taxCalculation == null)
            {
                return NotFound();
            }

            _dbContext.TaxCalculations.Remove(taxCalculation);
           _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



    }

}
