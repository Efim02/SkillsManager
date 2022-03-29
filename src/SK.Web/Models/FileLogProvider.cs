namespace SkillsManager.Models
{
    using System;

    using Microsoft.Extensions.Logging;

    public class FileLogProvider : ILoggerProvider
    {
        /// <inheritdoc />
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger();
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}