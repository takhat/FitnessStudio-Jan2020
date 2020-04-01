using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessStudioApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace FitnessStudioUI.Controllers
{
    [Authorize]
    public class CustomerAccountsController : Controller
    {
        // GET: CustomerAccounts
        public IActionResult Index()
        {
            return View(FitnessStudio.GetAccountInfoByEmailAddress(HttpContext.User.Identity.Name));
        }

        // GET: CustomerAccounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAccount = FitnessStudio.GetAccountInfoByCustomerID(id.Value);
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
        public IActionResult Create([Bind("CustomerName,EmailAddress,CustomerPhone,DateofBirth")] CustomerAccount customerAccount)
        {
            if (ModelState.IsValid)
            {
                FitnessStudio.CreateAccount(customerAccount.CustomerName, customerAccount.EmailAddress, customerAccount.CustomerPhone, customerAccount.DateofBirth);
                return RedirectToAction(nameof(Index));
            }
            return View(customerAccount);
        }

        // GET: CustomerAccounts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAccount = FitnessStudio.GetAccountInfoByCustomerID(id.Value);
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
        public IActionResult Edit(int id, [Bind("CustomerID,CustomerName,EmailAddress,CustomerPhone,DateofBirth")] CustomerAccount customerAccount)
        {
            if (id != customerAccount.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                FitnessStudio.Update(customerAccount);
                return RedirectToAction(nameof(Index));
            }
            return View(customerAccount);
        }
        public IActionResult GetClassPass(int? id)
        {
            var account = FitnessStudio.GetAccountInfoByCustomerID(id.Value);
            return View(account);

        }
        [HttpPost]
        public IActionResult GetClassPass(IFormCollection controls)
        {
            var custID = Convert.ToInt32(controls["CustomerID"]);
            var classtitle = Enum.Parse<TitleOfClass>(controls["ClassTitle"]);
            var classpassOption = Enum.Parse<ClassPassOption>(controls["TypeOfClassPass"]);
            FitnessStudio.BuyAClassPass(custID, classtitle, classpassOption);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Membership(int? id)
        {
            var account = FitnessStudio.GetAccountInfoByCustomerID(id.Value);
            return View(account);

        }
        [HttpPost]
        public IActionResult Membership(IFormCollection controlsMembership)
        {
            var CustID = Convert.ToInt32(controlsMembership["CustomerID"]);
            var membershipType = Enum.Parse<MembershipOption>(controlsMembership["TypeOfMembership"]);
            FitnessStudio.BuyAMembership(CustID, membershipType);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Transactions(int? id)
        {
            var transactions = FitnessStudio.GetAllTransactionsByCustomerID(id.Value);
            return View(transactions);
        }
    }
}
