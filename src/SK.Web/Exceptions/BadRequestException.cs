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
        /// <inheritdoc cref="BadHttpRequestException(string, int)"/>
        /// <param name="message">Сообщение ошибки.</param>
        /// <param name="httpStatusCode">Код ошибки.</param>
        public BadRequestException(string message, HttpStatusCode httpStatusCode)
            : base(message, (int)httpStatusCode)
        {
        }
    }
}