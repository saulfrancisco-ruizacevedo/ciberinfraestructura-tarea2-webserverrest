using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ciberinfraestructura_tarea2_webserver_rest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Apply pending migrations at startup. This will create/update tables
            // in the configured PostgreSQL database (e.g., your AWS RDS instance).
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataAccess.AppDbContext>();

                    // Wait for DB to be available with retries (useful when DB container is starting)
                    var maxAttempts = 15;
                    var attempt = 0;
                    var delayMs = 2000;
                    var canConnect = false;
                    while (attempt < maxAttempts && !canConnect)
                    {
                        try
                        {
                            attempt++;
                            System.Console.WriteLine($"Attempting DB connection (attempt {attempt}/{maxAttempts})...");
                            canConnect = context.Database.CanConnect();
                            if (canConnect) break;
                        }
                        catch (System.Exception ex)
                        {
                            System.Console.WriteLine($"DB connect attempt failed: {ex.Message}");
                        }
                        System.Threading.Thread.Sleep(delayMs);
                    }

                    if (!canConnect)
                    {
                        System.Console.WriteLine("Could not connect to DB after retries; skipping migrations/EnsureCreated.");
                    }
                    else
                    {
                        // If the assembly contains EF migrations, apply them.
                        // Otherwise fall back to EnsureCreated() so the schema for the model is created.
                        var migrations = context.Database.GetMigrations();
                        if (migrations != null && migrations.Any())
                        {
                            context.Database.Migrate();
                        }
                        else
                        {
                            // No migrations found in assembly; create schema based on model
                            context.Database.EnsureCreated();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    // If migration/creation fails, log to console. The host will still start.
                    System.Console.WriteLine($"An error occurred applying migrations/creating DB: {ex.Message}");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
