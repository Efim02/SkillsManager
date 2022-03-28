namespace SkillsManager
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Главный класс.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Построение сервера.
        /// </summary>
        /// <param name="args">Аргументы.</param>
        /// <returns>Строитель.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }

        /// <summary>
        /// Стартовая точка сервера.
        /// </summary>
        /// <param name="args">Аргументы.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}