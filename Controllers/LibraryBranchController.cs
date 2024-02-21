using LibraryManagementAssignment.ViewModels;
using LibraryManagementAssignment.Data;
using LibraryManagementAssignment.models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAssignment.Controllers
{
    public class LibraryBranchController : Controller
    {
        private readonly AppDbContext _context;

        public LibraryBranchController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var branches = _context
                .LibraryBranches
                .Select(branch => new LibraryBranchModel
                {
                    LibraryBranchId = branch.Id,
                    BranchName = branch.BranchName
                }).ToList();

            return View(branches);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LibraryBranchModel model)
        {
            var libraryBranch = new LibraryBranch
            {
                BranchName = model.BranchName
            };

            _context.LibraryBranches.Add(libraryBranch);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}