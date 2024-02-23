using LibraryManagementAssignment.Data;
using LibraryManagementAssignment.models;
using LibraryManagementAssignment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAssignment.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.Select(c => new CustomerViewModel
            {
                CustomerId = c.Id,
                Name = c.Name
            }).ToList();

            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(customer => customer.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            var customerViewModel = new CustomerViewModel
            {
                CustomerId = customer.Id,
                Name = customer.Name
            };

            return View(customerViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CustomerViewModel customerViewModel)
        {
            var customer = _context.Customers.FirstOrDefault(customer => customer.Id == customerViewModel.CustomerId);
            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = customerViewModel.Name;
            _context.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}