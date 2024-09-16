using BookStore.DAL.Entitites;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Data;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<Publisher> Publishers { get; set; }

    public DbSet<BookGenre> BookGenres { get; set; }

    public DbSet<BookAuthor> BookAuthors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired();

            entity.HasOne(e => e.Publisher)
                  .WithMany(p => p.Books);
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.BirthDate).IsRequired();
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.HasKey(e => new { e.BookId, e.AuthorId });
            entity.HasOne(e => e.Book)
                  .WithMany(b => b.Authors)
                  .HasForeignKey(e => e.BookId);
            entity.HasOne(e => e.Author)
                  .WithMany(b => b.Books)
                  .HasForeignKey(e => e.AuthorId);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<BookGenre>(entity =>
        {
            entity.HasKey(e => new { e.BookId, e.GenreId });
            entity.HasOne(e => e.Book)
                  .WithMany(b => b.Genres)
                  .HasForeignKey(e => e.BookId);
            entity.HasOne(e => e.Genre)
                  .WithMany(g => g.Books)
                  .HasForeignKey(e => e.GenreId);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.CompanyName).IsUnique();
            entity.Property(e => e.CompanyName).IsRequired();
        });
    }
}
