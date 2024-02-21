using System.ComponentModel.DataAnnotations;

namespace LibraryManagementAssignment.models;

public class Book
{
    [Key] public int Id { get; set; }

    public string Title { get; set; }

    public int AuthorId { get; set; }

    public int LibraryBranchId { get; set; }
}