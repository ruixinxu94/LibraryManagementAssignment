using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementAssignment.models;

public class Book
{
    [Key] public int Id { get; set; }

    public string Title { get; set; }

    [ForeignKey("Author")] public int AuthorId { get; set; }

    public Author Author { get; set; }

    [ForeignKey("LibraryBranch")] public int LibraryBranchId { get; set; }

    public LibraryBranch LibraryBranch { get; set; }
}