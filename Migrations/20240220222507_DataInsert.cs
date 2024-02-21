using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementAssignment.Migrations
{
    /// <inheritdoc />
    public partial class DataInsert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for (int id = 1; id <= 20; id++)
            {
                migrationBuilder.Sql($"INSERT INTO Customers (Id, Name) VALUES ({id}, 'Customer {id}');");
                migrationBuilder.Sql($"INSERT INTO LibraryBranches (Id, BranchName) VALUES ({id}, 'Branch {id}');");
                migrationBuilder.Sql($"INSERT INTO Authors (Id, Name) VALUES ({id}, 'Author {id}')");

            }
            Random rnd = new Random();
            for (int i = 1; i <= 30; i++)
            {
                int authorId =  rnd.Next(1, 21);
                int branchId =  rnd.Next(1, 21);
                migrationBuilder.Sql($"INSERT INTO Books (Id, Title, AuthorId, LibraryBranchId) VALUES ({i}, 'Book {i}', {authorId}, {branchId})");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
