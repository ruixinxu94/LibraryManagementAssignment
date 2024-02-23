using LibraryManagementAssignment.ViewModels;
using LibraryManagementAssignment.Data;
using LibraryManagementAssignment.models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAssignment.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;

        public AuthorController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var authorsWithBooks = _context.Authors
                .Select(author => new
                {
                    Author = author,
                    BookTitle = _context.Books
                        .Where(book => book.AuthorId == author.Id)
                        .Select(book => book.Title)
                        .FirstOrDefault()
                })
                .ToList()
                .Select(x => new AuthorViewModel
                {
                    Id = x.Author.Id,
                    Name = x.Author.Name,
                }).ToList();

            return View(authorsWithBooks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AuthorViewModel model)
        {
            var author = new Author { Name = model.Name };
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            var authorViewModel = new AuthorViewModel
            {
                Id = author.Id,
                Name = author.Name
            };

            return View(authorViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AuthorViewModel authorViewModel)
        {
            var author = new Author
            {
                Id = authorViewModel.Id,
                Name = authorViewModel.Name
            };

            _context.Update(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var authorExists = _context.Books.Any(book => book.AuthorId == id);
            if (authorExists)
            {
                TempData["ErrorMessage"] = "Cannot delete this author because they have associated books.";
                return RedirectToAction("Index");
            }

            var author = _context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}