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
    }
}