using AutoMapper;
using BookStore.BLL;
using BookStore.BLL.Interfaces;
using BookStore.BLL.Services;
using BookStore.DAL.Data;
using BookStore.DAL.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

namespace BookStore.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpContextAccessor();

            // Data services
            //builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(
            //    builder.Configuration.GetConnectionString("BookStore")!));
            builder.Services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DB"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var jwtIssuer = builder.Configuration["Jwt:Issuer"];
            var jwtAudience = builder.Configuration["Jwt:Audience"];
            var jwtSecret = builder.Configuration["Jwt:Secret"];

            builder.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
                        ValidateIssuer = true,
                        ValidIssuer = jwtIssuer,
                        ValidateAudience = true,
                        ValidAudience = jwtAudience,
                        ValidateLifetime = true,
                    };
                });

            // Bll services
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IPublisherService, PublisherService>();
            builder.Services.AddScoped<IAuthService, AuthenticationService>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
