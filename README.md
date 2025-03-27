# LibraryMVCWebAPI

A comprehensive Web API developed using JavaScript, CSS, HTML, C#, and SCSS. Key features include user and role management.

## Project Features

- User and Role Management (ASP.NET Core Identity)
- Book Management
- Category-Based Book Filtering
- Image Upload Support
- Authorization and Authentication
- Database Usage with **SQL Server**

---

## Technologies Used

| Technology               | Description                    |
|--------------------------|--------------------------------|
| **.NET 7.0**             | Main development platform      |
| **ASP.NET Core MVC**     | Web application framework      |
| **Entity Framework Core**| ORM layer                      |
| **Identity Framework**   | User management                |
| **Bootstrap 5**          | Frontend design                |
| **Toastr.js**            | Notification management        |
| **MSSQL**                | Database management            |

---

## Project Folder Structure

```plaintext
LibraryMVCWebAPI
├── LibraryMVCWebAPI.Application
│   ├── DTOs
│   ├── Extensions
│   ├── Services
├── LibraryMVCWebAPI.Domain
│   ├── Core
│   ├── Entities
│   ├── Enums
│   ├── Utilities
├── LibraryMVCWebAPI.Infrastructure
│   ├── AppContext
│   ├── Configurations
│   ├── DataAccess
│   ├── Migrations
│   ├── Repositories
├── LibraryMVCWebAPI.UI
│   ├── Controllers
│   ├── Models
│   ├── Views
│   ├── wwwroot
│   ├── Areas
└── README.md
```

---

## Database Schema

This project is a content management system consisting of core components such as **user management**, **book management**, **categories**, and **tags**.

---

## Table Structures

### User and Authorization

| **Table**         | **Description**                                  |
|-------------------|--------------------------------------------------|
| `AspNetUsers`     | Stores user information                          |
| `AspNetRoles`     | Contains user roles                              |
| `AspNetUserRoles` | Manages the relationship between users and roles |
| `AspNetUserClaims`| Stores custom user claims                        |
| `AspNetUserTokens`| Stores user login tokens                         |

### Book Management

| **Table**       | **Description**                |
|-----------------|-------------------------------|
| `Books`         | Contains book information     |
| `Authors`       | Contains author information   |
| `Categories`    | Manages book categories       |
| `BookCategories`| Manages the relationship between books and categories |

### Tagging System

| **Table**       | **Description**                |
|-----------------|-------------------------------|
| `Tags`          | Contains tags used in books   |
| `BookTags`      | Manages the relationship between books and tags |

---

## Database Relationships

- **`AspNetUsers` → `Books`** → (1-N) **One user can add multiple books.**
- **`Books` → `Authors`** → (N-1) **A book can have only one author.**
- **`Books` → `Categories`** → (N-N) **A book can belong to multiple categories.**
- **`Books` → `Tags`** → (N-N) **A book can have multiple tags.**

---

## Requirements

- **.NET 7.0** or newer version
- **SQL Server** or **SQL Server Express**
- **Visual Studio** or **Visual Studio Code** (optional)

## Getting Started

### 1. Clone the Project

First, clone the project from GitHub to your computer:

```bash
git clone https://github.com/mykece/LibraryMVCWebAPI.git
```

### 2. Edit the Connection String

Edit the content of the `appsettings.Development.json` file as follows:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "AppConnectionDev": "Server=YOUR_SERVER_NAME;Database=LibraryMVCWebAPI;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 3. Apply Database Migrations

Before running the project for the first time, you need to apply database migrations to create the database schema.

a. Open the Package Manager Console (Visual Studio)

Go to Tools > NuGet Package Manager > Package Manager Console.

b. Apply the Migrations

Run the following commands to apply the migrations:

```bash
Add-Migration InitialCreate
Update-Database
```

---




### Now you can run the project...
