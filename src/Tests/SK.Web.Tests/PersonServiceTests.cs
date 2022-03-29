namespace SK.Web.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SK.DB;
    using SK.DB.Models;
    using SK.Web.Tests.Models;
    using SK.Web.Tests.Utils;

    using SkillsManager.Services;

    /// <summary>
    /// Тест сервиса сотрудников.
    /// </summary>
    [TestClass]
    public class PersonServiceTests
    {
        /// <summary>
        /// Инициализация переменных.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            using var skContext = new SkContextTest();
        }

        /// <summary>
        /// Проверка добавления нового сотрудника.
        /// </summary>
        [TestMethod]
        public void CheckAddPerson()
        {
            var service = ServiceUtils.GetPersonService();

            const string DisplayName = "Онтипенко Иван";
            const string Name = "ontipenkoi";
            var person = new Person
            {
                DisplayName = DisplayName, Name = Name
            };
            service.AddPerson(person).Wait();

            var taskGet = service.GetPerson(person.Id);
            taskGet.Wait();

            Assert.IsTrue(DisplayName == taskGet.Result.DisplayName);
            Assert.IsTrue(Name == taskGet.Result.Name);
        }

        /// <summary>
        /// Проверка добавления нового сотрудника, со списком навыков.
        /// </summary>
        [TestMethod]
        public void CheckAddPersonWithSkills()
        {
            var serviceBefore = ServiceUtils.GetPersonService();
            var person = new Person
            {
                DisplayName = "Онтипенко Иван",
                Name = "ontipenkoi",
                Skills = new List<Skill>
                {
                    new Skill { Level = 255, Name = "Dota" },
                    new Skill { Level = 1, Name = "Minecraft" },
                    new Skill { Level = 124, Name = "Lolepop" }
                }
            };
            serviceBefore.AddPerson(person).Wait();

            var serviceAfter = ServiceUtils.GetPersonService();
            var taskGet = serviceAfter.GetPerson(person.Id);
            taskGet.Wait();

            Assert.IsTrue(taskGet.Result.Skills.Count == person.Skills.Count);
            for (var index = 0; index < person.Skills.Count; index++)
            {
                var skillS = person.Skills[index];
                var skillD = taskGet.Result.Skills[index];

                Assert.IsTrue(skillS.Name == skillD.Name);
                Assert.IsTrue(skillS.Level == skillD.Level);
            }
        }
    }
}