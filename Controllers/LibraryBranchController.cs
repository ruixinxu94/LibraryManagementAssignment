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

        public IActionResult Edit(int id)
        {
            var libraryBranch = _context.LibraryBranches.Find(id);
            if (libraryBranch == null)
            {
                return NotFound();
            }

            var model = new LibraryBranchModel
            {
                LibraryBranchId = libraryBranch.Id,
                BranchName = libraryBranch.BranchName
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(LibraryBranchModel model)
        {
            var libraryBranch = new LibraryBranch
            {
                Id = model.LibraryBranchId,
                BranchName = model.BranchName
            };
            _context.Update(libraryBranch);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
            var branchExists = _context.Books.Any(book => book.LibraryBranchId == id);
            if (branchExists)
            {
                TempData["ErrorMessage"] = "Cannot delete this library branch because it has associated books.";
                return RedirectToAction("Index");
            }

            var libraryBranch = _context.LibraryBranches.Find(id);
            if (libraryBranch == null)
            {
                return NotFound();
            }

            _context.LibraryBranches.Remove(libraryBranch);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}