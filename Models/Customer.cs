using System.ComponentModel.DataAnnotations;

namespace LibraryManagementAssignment.models;

public class Customer
{
    [Key] public int Id { get; set; }
    public string? Name { get; set; }
}