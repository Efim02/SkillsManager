namespace SkillsManager
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// ������� �����.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// ���������� �������.
        /// </summary>
        /// <param name="args">���������.</param>
        /// <returns>���������.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }

        /// <summary>
        /// ��������� ����� �������.
        /// </summary>
        /// <param name="args">���������.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}