namespace SK.DB.Utils
{
    using System.IO;

    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Утилита для доп. функционала работы с бд.
    /// </summary>
    public static class SkContextUtils
    {
        /// <summary>
        /// Путь к файлу с конфигурацией приложения.
        /// </summary>
        public const string APP_SETTINGS_PATH = "appsettings.json";

#if DEBUG
        /// <summary>
        /// Название подключения к бд.
        /// </summary>
        public const string CONNECTION_NAME = "DebugConnection";
#endif
        /// <summary>
        /// Получить строку подключения к бд.
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionStrings()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(APP_SETTINGS_PATH);

            var config = builder.Build();
            return config.GetConnectionString(CONNECTION_NAME);
        }
    }
}