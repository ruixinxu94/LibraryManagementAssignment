using System.ComponentModel.DataAnnotations;

namespace LibraryManagementAssignment.models;

public class LibraryBranch
{
    [Key] public int Id { get; set; }
    public string? BranchName { get; set; }
}