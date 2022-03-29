namespace SK.Web.Tests.Utils
{
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using SK.DB;
    using SK.Web.Tests.Models;

    using SkillsManager.Services;

    /// <summary>
    /// Утилита сервисов для тестов.
    /// </summary>
    public static class ServiceUtils 
    {
        /// <summary>
        /// Получить сервис для работы с сотрудниками в бд.
        /// </summary>
        /// <returns></returns>
        public static PersonService GetPersonService()
        {
            var skContext = new SkContext();
            return new PersonService(skContext);
        }
    }
}