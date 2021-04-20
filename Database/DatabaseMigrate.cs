using Sample.Database.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.Database
{
    public static class DatabaseMigrate
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetService<SampleContext>()?.Database.Migrate();
            return app;
        }
    }
}
