# N-Tier WebApi Application
**Note:** This project is currently under development.

## Introduction
This repository contains an N-tier architecture WebApi application developed using ASP.NET. The application manages entities such as Books, Authors, Publishers, and Genres. It implements repository and UnitOfWork patterns, along with Dependency Injection (DI) for enhanced modularity and maintainability. The application utilizes EntityFramework as the ORM and is built on .NET 6.

## Features
- **CRUD Operations** for Books, Authors, Publishers, and Genres.
- **Many-to-Many Relationships** managed through `BookAuthor` and `BookGenre` entities.
- **Repository Pattern** for data access abstraction.
- **UnitOfWork Pattern** to manage transaction consistency.
- **Dependency Injection** configured in `Program.cs`.
- **Data Transfer Objects (DTOs)** for transferring data between layers.
- **Automapper** for mapping between domain models and DTOs.

## Entities
### Book
Represents a book with properties such as `Id`, `Title`, `PublisherId`, `GenreId`, `Isbn13`, `Description` etc.

### Author
Represents an author with properties such as `Id`, `FirstName`, `LastName`, etc.

### Publisher
Represents a publisher with properties such as `Id`, `CompanyName`.

### Genre
Represents a genre with properties such as `Id`, `Name`.

### BookAuthor
Manages the many-to-many relationship between Books and Authors.

### BookGenre
Manages the many-to-many relationship between Books and Genres.

## Getting Started
### Prerequisites
- .NET SDK
- SQL Server or any supported database

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/Sahak-Sargsyan/book-store-app.git
    ```
2. Navigate to the project directory:
    ```bash
    cd book-store-app
    ```
3. Restore dependencies:
    ```bash
    dotnet restore
    ```

### Configuration
1. Configure the database connection string in `appsettings.json`.
2. Apply migrations to set up the database schema:
    ```bash
    dotnet ef database update
    ```

### Running the Application
1. Build the project:
    ```bash
    dotnet build
    ```
2. Run the application:
    ```bash
    dotnet run
    ```

## Usage
Once the application is running, you can interact with the API endpoints using tools like Postman or curl. Here are some example requests:

### AuthorController
- `GET /authors` - Get all authors.
- `POST /authors` - Add a new author.
- `PUT /authors` - Update an existing author.
- `GET /authors/find/{isbn13}` - Find an author by ISBN13.
- `GET /authors/{id}` - Get an author by ID.
- `DELETE /authors/{id}` - Delete an author by ID.

### BookController
- `GET /books` - Get all books.
- `POST /books` - Add a new book.
- `PUT /books` - Update an existing book.
- `GET /books/{id}` - Get a book by ID.
- `GET /books/find/{isbn13}` - Find a book by ISBN13.
- `GET /books/{authorId}/authors` - Get books by author ID.
- `GET /books/{genreId}/genres` - Get books by genre ID.
- `GET /books/{publisherId}/publishers` - Get books by publisher ID.
- `DELETE /books/{isbn13}` - Delete a book by ISBN13.

### GenreController
- `GET /genres` - Get all genres.
- `POST /genres` - Add a new genre.
- `PUT /genres` - Update an existing genre.
- `GET /genres/find/{isbn13}` - Find a genre by ISBN13.
- `GET /genres/{id}` - Get a genre by ID.
- `DELETE /genres/{id}` - Delete a genre by ID.

### PublisherController
- `GET /publishers` - Get all publishers.
- `POST /publishers` - Add a new publisher.
- `PUT /publishers` - Update an existing publisher.
- `GET /publishers/{id}` - Get a publisher by ID.
- `DELETE /publishers/{id}` - Delete a publisher by ID.
- `GET /publishers/find/{isbn13}` - Find a publisher by ISBN13.


## Contributing
Contributions are welcome! Please fork the repository and submit pull requests.

## License
This project is licensed under the MIT License - see the LICENSE file for details.

