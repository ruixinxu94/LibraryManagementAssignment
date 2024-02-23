using LibraryManagementAssignment.Data;
using LibraryManagementAssignment.models;
using LibraryManagementAssignment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAssignment.Controllers;

public class CustomerController : Controller
{
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        try
        {
            var customers = _context.Customers.Select(c => new CustomerViewModel
            {
                CustomerId = c.Id,
                Name = c.Name
            }).ToList();

            return View(customers);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "An error occurred while retrieving customers from the database:" + e.Message;
            return RedirectToAction("Index");
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Customer customer)
    {
        try
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "An error occurred while creating the customer:" + e.Message;
            return RedirectToAction("Index");
        }
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
        try
        {
            var customer =
                _context.Customers.FirstOrDefault(customer => customer.Id == customerViewModel.CustomerId);
            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = customerViewModel.Name;
            _context.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "An error occurred while editing the customer:" + e.Message;
            return RedirectToAction("Index");
        }
    }

    public IActionResult Delete(int id)
    {
        try
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
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "An error occurred while deleting the customer:" + e.Message;
            return RedirectToAction("Index");
        }
    }
}