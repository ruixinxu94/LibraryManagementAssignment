# Library Management System

## Description
This is a Library Management System designed to manage books, authors, customers, and library branches.

## Features
- Add, edit, and delete books
- Add, edit, and delete authors
- Add, edit, and delete customers
- Add, edit, and delete library branches

## Getting Started
1. Clone this repository.
2. Open the solution in Visual Studio.
3. Ensure that Entity Framework tools are installed globally on your system. You can install them using the following command:
   ```bash
   dotnet tool install --global dotnet-ef
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Microsoft.EntityFrameworkCore.Design
   dotnet add package Microsoft.EntityFrameworkCore.SQLite
4. Run the following commands in the Package Manager Console to apply migrations and update the database:
    ```bash
    dotnet ef database drop
    dotnet ef database update
    ```
5. Run the application:
    ```bash
    dotnet run
    ```
6. Open your browser and navigate to [https://localhost:5134](https://localhost:5134).

### Dependencies
Ensure you have the following dependencies installed:
- .NET Core SDK
- Visual Studio (or Visual Studio Code)
- Entity Framework Core

If any of the dependencies are missing, you can install them from the following sources:
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/get-started/install/)