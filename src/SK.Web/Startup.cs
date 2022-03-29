namespace SkillsManager
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    using SkillsManager.Extensions;
    using SkillsManager.Models;

    /// <summary>
    /// Класс - конфигурация сервера.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            loggerFactory.AddProvider(new FileLogProvider());

            app.UseRouting();
            app.UseEndpoints(
                endPoints =>
                    endPoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvcCore();

            services.ConnectAutoMapper();
            services.ConnectSkContext();

            services.ConnectPersonService();

            services.ConnectSwagger();
        }
    }
}