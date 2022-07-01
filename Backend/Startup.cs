using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Backend
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Hosting.IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DatabaseConnection");

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
