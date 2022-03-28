namespace SkillsManager.Extensions
{
    using AutoMapper;

    using Microsoft.Extensions.DependencyInjection;

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
        }
    }
}