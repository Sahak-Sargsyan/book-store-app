using BookStore.DAL.Data;
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
