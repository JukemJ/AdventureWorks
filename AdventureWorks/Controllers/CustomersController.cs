using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Data;
using AdventureWorks.Models;
using AdventureWorks.Services;
using Microsoft.AspNetCore.Authorization;

namespace AdventureWorks.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AdventureWorksContext _context;

        public CustomersController(AdventureWorksContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            CustomerDAO customers = new CustomerDAO();
            return View(customers.GetAllCustomers());
            //return _context.Customer != null ? 
            //              View(await _context.Customer.ToListAsync()) :
            //              Problem("Entity set 'AdventureWorksContext.Customer'  is null.");
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            CustomerDAO customer = new CustomerDAO();
            return View(customer.GetCustomer((int)id));
            //if (id == null || _context.Customer == null)
            //{
            //    return NotFound();
            //}

            //var customer = await _context.Customer
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (customer == null)
            //{
            //    return NotFound();
            //}

            //return View(customer);
        }
        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult SearchResults(string searchTerm)
        {
            CustomerDAO customer = new CustomerDAO();
            List<Customer> customersList = customer.SearchCustomers(searchTerm);
            return View("index", customersList);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EmailAddress,PhoneNumber,Company")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EmailAddress,PhoneNumber,Company")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            CustomerDAO customer = new CustomerDAO();
            List<Customer> customersList = customer.DeleteCustomer((int)id);
            return View("index", customersList);

            //if (id == null || _context.Customer == null)
            //{
            //    return NotFound();
            //}

            //var customer = await _context.Customer
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (customer == null)
            //{
            //    return NotFound();
            //}

            //return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'AdventureWorksContext.Customer'  is null.");
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer != null)
            {
                _context.Customer.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return (_context.Customer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
