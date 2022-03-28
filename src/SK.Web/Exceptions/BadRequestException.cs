namespace SkillsManager.Exceptions
{
    using System;
    using System.Net;

    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Исключение о плохом запросе.
    /// </summary>
    /// <remarks>
    /// Создан, для использования в конструкторе <see cref="BadHttpRequestException" /> перечисление
    /// <see cref="HttpStatusCode" />.
    /// </remarks>
    public class BadRequestException : BadHttpRequestException
    {
        /// <inheritdoc />
        public BadRequestException(string message, int statusCode)
            : base(message, statusCode)
        {
        }

        /// <inheritdoc />
        public BadRequestException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public BadRequestException(string message, int statusCode, Exception innerException)
            : base(message, statusCode, innerException)
        {
        }

        /// <inheritdoc />
        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <inheritdoc cref="BadRequestException(string, int)"/>
        /// <param name="message">Сообщение ошибки.</param>
        /// <param name="httpStatusCode">Код ошибки.</param>
        public BadRequestException(string message, HttpStatusCode httpStatusCode)
            : base(message, (int)httpStatusCode)
        {
        }
    }
}