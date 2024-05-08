using Microsoft.EntityFrameworkCore;

namespace _4Tables.Extensions
{
    public static class DbContextExtension
    {
        public static void RunMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var contexts = (from asm in AppDomain.CurrentDomain.GetAssemblies()
                                from type in asm.GetTypes()
                                where type.IsClass && type.BaseType == typeof(DbContext)
                                select type).ToArray();

                foreach (var item in contexts)
                {
                    (scope.ServiceProvider.GetRequiredService(item) as DbContext)
                        .Database.Migrate();
                }
            }
        }
    }
}
