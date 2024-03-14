using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class IncomesController : Controller
    {
        private readonly ExpenseManagerDbContext _context;
        public IncomesController(ExpenseManagerDbContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index()
        {
            return View(_context.Incomes.Include(x => x.Category).ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Income income)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _context.Incomes.AddAsync(income);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var income = await _context.Incomes.Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
            return View(income);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Incomes.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Income income)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(income);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeExists(income.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(income);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Incomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var income = await _context.Incomes.FindAsync(id);
            if (income != null)
            {
                _context.Incomes.Remove(income);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeExists(int id)
        {
            return _context.Incomes.Any(e => e.Id == id);
        }
    }
}
