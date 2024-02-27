using System.ComponentModel.DataAnnotations;

namespace LibraryManagementAssignment.models;

public class Author
{
    [Key] public int Id { get; set; }
    public string? Name { get; set; }
}