using AuthService.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using AppDbContext context = scope.ServiceProvider.GetService<AppDbContext>();
            context.Database.Migrate();
        }
    }
}
