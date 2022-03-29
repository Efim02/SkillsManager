namespace SkillsManager.Models
{
    using System;
    using System.IO;
    using System.Reflection;

    using Microsoft.Extensions.Logging;

    using SkillsManager.Constants;

    /// <summary>
    /// Класс отвечающий на за логирования в файл.
    /// </summary>
    public class FileLogger : ILogger
    {
        /// <summary>
        /// Путь к лог файлу.
        /// </summary>
        private static readonly string FilePath;

        /// <summary>
        /// Объект заглушка.
        /// </summary>
        private static readonly object Lock;

        /// <inheritdoc cref="FileLogger" />
        static FileLogger()
        {
            Lock = new object();

            var executingAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                                        ?? throw new NullReferenceException();
            var pathDirectory = Path.Combine(executingAssemblyPath, PathContants.LOGS_DIRECTORY);
            Directory.CreateDirectory(pathDirectory);

            FilePath = Path.Combine(pathDirectory, $"{DateTime.Now:ss.mm.hh-dd.MM.yyyy}.txt");
        }

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                case LogLevel.Information:
                    return false;
                default:
                    return true;
            }
        }

        /// <inheritdoc />
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (formatter is null)
                return;

            lock (Lock)
            {
                File.AppendAllText(FilePath, $"{formatter(state, exception)}\n");
            }
        }
    }
}