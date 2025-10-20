# 📚 Library Management System API

A comprehensive RESTful API for managing a library system built with ASP.NET Core Web API.

## 🎯 Project Overview

This API provides complete library management functionality including author management, book cataloging, user registration, category organization, and book borrowing/return operations.

## ✨ Features

- **Author Management** - CRUD operations for authors
- **Book Management** - Manage books with author and category relationships
- **User Management** - Register and manage library members
- **Category Management** - Organize books by categories
- **Borrowing System** - Track book borrowing and returns with due dates

## 🏗️ Technologies Used

- **ASP.NET Core 9.0** - Web API Framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Database
- **Dependency Injection** - Built-in DI container
- **Custom Middleware** - Global exception handling
- **Data Annotations** - Validation attributes

## 📊 Database Schema

The system uses **5 tables** with the following relationships:

```
Authors (1) ────→ (Many) Books
Category (1) ───→ (Many) Books
User (1) ────────→ (Many) Borrows
Books (1) ───────→ (Many) Borrows
```

### Tables:

1. **Authors** - Stores author information

   - Id, FirstName, LastName, Email, Age

2. **Books** - Stores book information

   - Id, Title, AuthorId, CategoryId, Language, PublishedYear

3. **Categories** - Book categories/genres

   - Id, Name, Description

4. **Users** - Library members

   - Id, Name, Email, PhoneNumber, RegistrationDate

5. **Borrows** - Borrowing transactions
   - Id, UserId, BookId, BorrowDate, DueDate, ReturnDate

## 🔌 API Endpoints

### Authors

- `GET /api/Authors` - Get all authors
- `GET /api/Authors/{id}` - Get author by ID
- `POST /api/Authors` - Create new author
- `DELETE /api/Authors/{id}` - Delete author

### Books

- `GET /api/Books` - Get all books
- `GET /api/Books/{id}` - Get book by ID
- `POST /api/Books` - Create new book
- `DELETE /api/Books/{id}` - Delete book

### Categories

- `GET /api/Categories` - Get all categories
- `GET /api/Categories/{id}` - Get category by ID
- `POST /api/Categories` - Create new category
- `DELETE /api/Categories/{id}` - Delete category

### Users

- `GET /api/Users` - Get all users
- `GET /api/Users/{id}` - Get user by ID
- `POST /api/Users` - Create new user
- `DELETE /api/Users/{id}` - Delete user

### Borrows

- `GET /api/Borrows` - Get all borrows
- `GET /api/Borrows/{id}` - Get borrow by ID
- `GET /api/Borrows/user/{userId}` - Get borrows by user
- `POST /api/Borrows` - Borrow a book
- `PUT /api/Borrows/{id}/return` - Return a book
- `DELETE /api/Borrows/{id}` - Delete borrow record

## 🛠️ Key Implementation Features

### 1. Object-Oriented Programming (OOP)

- Proper class structure with entities, DTOs, services, and controllers
- Encapsulation with properties and methods
- Separation of concerns across layers

### 2. Dependency Injection

- Services registered in `Program.cs`
- Automatic injection into controllers
- Scoped lifetime for database operations

### 3. Service Layer Pattern

- Business logic separated into service classes
- Entity ↔ DTO conversion in services
- Clean, testable code

### 4. Exception Handling

- Custom exception classes (`NotFoundException`, `BadRequestException`)
- Global exception middleware
- Consistent error responses with proper HTTP status codes

### 5. Data Validation

- Custom attributes (`[Email]`, `[Age]`, `[Year]`)
- Built-in attributes (`[Required]`, `[StringLength]`, `[EmailAddress]`)
- Automatic validation in controllers

### 6. Middleware

- `ExceptionMiddleware` - Catches and handles all exceptions
- Returns JSON error responses
- Proper HTTP status codes (404, 400, 500)

## 📝 Example Requests

### Create a User

```json
POST /api/Users
Content-Type: application/json

{
  "name": "John Doe",
  "email": "john@example.com",
  "phoneNumber": "555-1234"
}
```

### Create a Book

```json
POST /api/Books
Content-Type: application/json

{
  "title": "The Great Gatsby",
  "authorId": 1,
  "categoryId": 2,
  "language": "English",
  "publishedYear": 1925
}
```

### Borrow a Book

```json
POST /api/Borrows
Content-Type: application/json

{
  "userId": 1,
  "bookId": 3
}
```

### Return a Book

```json
PUT /api/Borrows/1/return
Content-Type: application/json

{}
```

## 🔒 Error Handling

The API returns consistent JSON error responses:

```json
{
  "statusCode": 404,
  "message": "User with ID 5 was not found",
  "error": "NotFoundException"
}
```

### HTTP Status Codes:

- `200 OK` - Successful GET request
- `201 Created` - Successful POST request
- `204 No Content` - Successful DELETE request
- `400 Bad Request` - Invalid input or business rule violation
- `404 Not Found` - Resource doesn't exist
- `500 Internal Server Error` - Unexpected error

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 SDK
- SQL Server
- Visual Studio 2022 or JetBrains Rider

### Setup

1. Clone the repository

```bash
git clone https://github.com/Ciugiu/library-backend.git
cd library-backend
```

2. Update connection string in `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

3. Run migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. Run the application

```bash
dotnet run
```

## 🌐 Deployment

### Azure SQL Database

1. Create Azure SQL Database
2. Update connection string in Azure App Service configuration
3. Run migrations against Azure database

### Azure App Service

1. Publish project to Azure App Service
2. Configure application settings
3. Test endpoints with public URL

## 📂 Project Structure

```
WebApplication1/
├── Controllers/          # API endpoints
├── Services/            # Business logic
├── Entities/            # Database models
├── DTOs/                # Data transfer objects
├── Data/                # DbContext
├── Middleware/          # Custom middleware
├── Exceptions/          # Custom exceptions
├── Attributes/          # Custom validation attributes
└── Migrations/          # EF migrations
```

## 👨‍💻 Author

Created as a final project for C# course demonstrating:

- ASP.NET Core Web API development
- Entity Framework Core
- Clean architecture principles
- RESTful API design
- Exception handling
- Dependency injection

## 📄 License

This project is for educational purposes.

---

**🎓 EPITA - C# Final Project - 2025**
