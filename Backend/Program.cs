namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            CreateDefaultBuilder(args).UseStartup<Startup>()
            .Build();

        public static IWebHostBuilder CreateDefaultBuilder(string[] args)
        {
            var builder = new WebHostBuilder().UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration();
            return builder;
        }
    }
}