
# 📚 BookStoreApp

A multi-layered .NET Web API project for managing a bookstore, including user authentication, business logic, data access with PostgreSQL, and DTO support using AutoMapper.

## 🏗️ Project Structure

- AuthService           – Handles user authentication
- BookStore.BLL         – Business Logic Layer
- BookStore.DAL         – Data Access Layer (migrating to PostgreSQL)
- BookStore.Dtos        – Data Transfer Objects (AutoMapper profiles added)
- BookStore.WebAPI      – Main API endpoints

## 🚀 Features

- ✅ Layered architecture
- 🔐 Authentication module (AuthService)
- 🧠 Business logic separated in `BookStore.BLL`
- 💾 Data layer using PostgreSQL `BookStore.DAL`
- 🔄 AutoMapper integration for DTOs
- 🌐 ASP.NET Core Web API `BookStore.WebAPI`

## 🛠️ Tech Stack

- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- AutoMapper
- JWT Authentication
- RESTful API


## Getting Started
### Prerequisites
- .NET SDK
- SQL Server or any supported database


### 📦 Setup Instructions

1. Clone the repository
    ```bash
    git clone https://github.com/Sahak-Sargsyan/book-store-app.git
    cd BookStoreApp
    ```

2. Configure PostgreSQL connection

    Update your connection string in `appsettings.json` under `BookStore.WebAPI`.

3. Run Migrations
    ```bash
    cd BookStore.WebAPI
    dotnet ef database update
    ```

5. Run the App
    ```bash
    dotnet run --project BookStore.WebAPI
    ```

## 🚧 Status

This project is currently under active development.
New features, refactoring, and improvements are being added continuously.

---


## 📄 License

This project is licensed under the MIT License.
See the [LICENSE](LICENSE) file for more information.
