using LibraryManagementAssignment.models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAssignment.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LibraryBranch> LibraryBranches { get; set; }

        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
        // }
    }
}