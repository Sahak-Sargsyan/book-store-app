using AutoMapper;
using BookStore.BLL;
using BookStore.BLL.Interfaces;
using BookStore.BLL.Services;
using BookStore.DAL.Data;
using BookStore.DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Data services
            builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("BookStore")!));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Bll services
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IPublisherService, PublisherService>();

            // Automapper
            builder.Services.AddSingleton(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperProfile>();
            }).CreateMapper());

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
