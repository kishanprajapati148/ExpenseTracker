using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Models;

namespace Expense_Tracker.Controllers
{
    public class ExpenseLimitController : Controller
    {
        private readonly ExpenseDbContextcs _context;

        public ExpenseLimitController(ExpenseDbContextcs context)
        {
            _context = context;
        }

        // GET: ExpenseLimit
        public IActionResult Index()
        {
            var data = _context.ExpenseLimit.ToList();
            return View(data);
        }

        // GET: ExpenseLimit/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new ExpenseLimit());
            else
                return View(_context.ExpenseLimit.Find(id));
        }

        // POST: ExpenseLimit/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("ExpenseLimitId,Expense_Limit")] ExpenseLimit expenseLimit)
        {
            if (ModelState.IsValid)
            {
                if (expenseLimit.ExpenseLimitId == 0)
                    _context.Add(expenseLimit);
                else
                    _context.Update(expenseLimit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseLimit);
        }
        // POST: ExpenseLimit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExpenseLimit == null)
            {
                return Problem("Entity set 'ExpenseDbContextcs.ExpenseLimit'  is null.");
            }
            var expenseLimit = await _context.ExpenseLimit.FindAsync(id);
            if (expenseLimit != null)
            {
                _context.ExpenseLimit.Remove(expenseLimit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
