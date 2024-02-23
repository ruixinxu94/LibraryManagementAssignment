using LibraryManagementAssignment.ViewModels;
using LibraryManagementAssignment.Data;
using LibraryManagementAssignment.models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAssignment.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.ToList();

            var bookViewModels = books.Select(book => new BookViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                AuthorName = _context.Authors
                    .Where(author => author.Id == book.AuthorId)
                    .Select(author => author.Name)
                    .FirstOrDefault() ?? "unknown author",
                BranchName = _context.LibraryBranches
                    .Where(lb => lb.Id == book.LibraryBranchId)
                    .Select(lb => lb.BranchName)
                    .FirstOrDefault() ?? "Unknown branch name"
            }).ToList();
            return View(bookViewModels);
        }

        public IActionResult Create()
        {
            var model = new BookCreateEditViewModel
            {
                Authors = _context.Authors.Select(author =>
                        new AuthorViewModel
                        {
                            Id = author.Id,
                            Name = author.Name
                        })
                    .ToList(),
                LibraryBranches = _context.LibraryBranches.Select(libraryBranch =>
                    new LibraryBranchModel
                    {
                        LibraryBranchId = libraryBranch.Id,
                        BranchName = libraryBranch.BranchName
                    }).ToList()
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Create(BookCreateEditViewModel model)
        {
            var book = new Book
            {
                Title = model.Title,
                AuthorId = model.AuthorId,
                LibraryBranchId = model.LibraryBranchId
            };
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            var editViewModel = new BookCreateEditViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                LibraryBranchId = book.LibraryBranchId,
                Authors = _context.Authors.Select(author =>
                        new AuthorViewModel
                        {
                            Id = author.Id,
                            Name = author.Name
                        })
                    .ToList(),
                LibraryBranches = _context.LibraryBranches.Select(libraryBranch =>
                    new LibraryBranchModel
                    {
                        LibraryBranchId = libraryBranch.Id,
                        BranchName = libraryBranch.BranchName
                    }).ToList()
            };
            return View(editViewModel);
        }
        
        [HttpPost]
        public IActionResult Edit(int id, BookCreateEditViewModel model)
        {
            var book = new Book
                {
                    Id = model.BookId,
                    Title = model.Title,
                    AuthorId = model.AuthorId,
                    LibraryBranchId = model.LibraryBranchId
                }
                ;
            _context.Update(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}