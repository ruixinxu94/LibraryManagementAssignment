namespace LibraryManagementAssignment.ViewModels;

public class BookCreateEditViewModel
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public int AuthorId { get; set; }
    public int LibraryBranchId { get; set; }
    public List<AuthorViewModel> Authors { get; set; } = new List<AuthorViewModel>();
    public List<LibraryBranchModel> LibraryBranches { get; set; } = new List<LibraryBranchModel>();
}