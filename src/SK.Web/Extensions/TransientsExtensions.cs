﻿namespace SkillsManager.Extensions
{
    using System.Reflection;
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    using SK.BL.Models;
    using SK.DB;

    using SkillsManager.Services;

    /// <summary>
    /// Расширение интерфейса сервисов <see cref="IServiceCollection" />, для внедрения зависимостей.
    /// </summary>
    public static class TransientsExtensions
    {
        /// <summary>
        /// Конфигурация картографа.
        /// </summary>
        private static readonly MapperConfiguration _mapperConfiguration = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Person, SK.DB.Models.Person>().ReverseMap();
                cfg.CreateMap<Skill, SK.DB.Models.Skill>().ForMember(dest => dest.OwnerPerson, source => source.Ignore()).
                    ForMember(dest => dest.Id, source => source.Ignore()).
                    ReverseMap();
            });

        /// <summary>
        /// Подключение <see cref="IMapper" />.
        /// </summary>
        /// <param name="serviceCollection">Коллекция сервисов.</param>
        public static void ConnectAutoMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(_mapperConfiguration.CreateMapper());
        }

        /// <summary>
        /// Подключение <see cref="PersonService" />.
        /// </summary>
        /// <param name="serviceCollection">Коллекция сервисов.</param>
        public static void ConnectPersonService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<PersonService>();
        }

        /// <summary>
        /// Подключение <see cref="SkContext" />.
        /// </summary>
        /// <param name="serviceCollection">Коллекция сервисов.</param>
        public static void ConnectSkContext(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<SkContext>();

            using var skContext = new SkContext();

            for (var counter = 0; counter < 10; counter++)
            {
                if (skContext.Database.CanConnect())
                    break;

                Task.Delay(5000).Wait();
            }

            skContext.Database.Migrate();
        }

        /// <summary>
        /// Подключение Swagger />.
        /// </summary>
        /// <param name="serviceCollection">Коллекция сервисов.</param>
        public static void ConnectSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(
                s =>
                {
                    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Sk Api", Version = "v1" });
                    s.IncludeXmlComments($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                });
        }
    }
}