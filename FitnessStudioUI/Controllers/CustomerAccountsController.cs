using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessStudioApp;
using Microsoft.AspNetCore.Authorization;

namespace FitnessStudioUI.Controllers
{
    [Authorize]
    public class CustomerAccountsController : Controller
    {
        private readonly FitnessStudioContext _context;

        public CustomerAccountsController(FitnessStudioContext context)
        {
            _context = context;
        }

        // GET: CustomerAccounts
        public async Task<IActionResult> Index()
        {
            return View(FitnessStudio.GetAccountInfoByEmailAddress(HttpContext.User.Identity.Name));
        }

        // GET: CustomerAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAccount = await _context.CustomerAccounts
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customerAccount == null)
            {
                return NotFound();
            }

            return View(customerAccount);
        }

        // GET: CustomerAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,EmailAddress,CustomerPhone,DateofBirth")] CustomerAccount customerAccount)
        {
            if (ModelState.IsValid)
            {
                FitnessStudio.CreateAccount(customerAccount.CustomerName, customerAccount.CustomerPhone, customerAccount.EmailAddress, customerAccount.DateofBirth);
                return RedirectToAction(nameof(Index));
            }
            return View(customerAccount);
        }

        // GET: CustomerAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAccount = await _context.CustomerAccounts.FindAsync(id);
            if (customerAccount == null)
            {
                return NotFound();
            }
            return View(customerAccount);
        }

        // POST: CustomerAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerID,CustomerName,EmailAddress,CustomerPhone,DateofBirth")] CustomerAccount customerAccount)
        {
            if (id != customerAccount.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerAccountExists(customerAccount.CustomerID))
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
            return View(customerAccount);
        }

        // GET: CustomerAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAccount = await _context.CustomerAccounts
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customerAccount == null)
            {
                return NotFound();
            }

            return View(customerAccount);
        }

        // POST: CustomerAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerAccount = await _context.CustomerAccounts.FindAsync(id);
            _context.CustomerAccounts.Remove(customerAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerAccountExists(int id)
        {
            return _context.CustomerAccounts.Any(e => e.CustomerID == id);
        }
    }
}
