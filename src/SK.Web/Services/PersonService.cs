namespace SkillsManager.Services
{
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using SK.DB;
    using SK.DB.Models;

    using SkillsManager.Controllers;
    using SkillsManager.Exceptions;

    /// <summary>
    /// Сервис сотрудника.
    /// </summary>
    public class PersonService
    {
        /// <summary>
        /// Контекст бд.
        /// </summary>
        private readonly SkContext _skContext;

        /// <inheritdoc cref="PersonService" />
        public PersonService(SkContext skContext)
        {
            _skContext = skContext;
        }

        /// <inheritdoc cref="PersonController.AddPerson" />
        public async Task<long> AddPerson(Person person)
        {
            await _skContext.Persons.AddAsync(person);
            await _skContext.SaveChangesAsync();
            return person.Id;
        }

        /// <inheritdoc cref="PersonController.DeletePerson" />
        public async Task DeletePerson(long personId)
        {
            var dbPerson = await GetPerson(personId);
            _skContext.Persons.Remove(dbPerson);

            await _skContext.SaveChangesAsync();
        }

        /// <inheritdoc cref="PersonController.GetPerson" />
        public async Task<Person> GetPerson(long personId)
        {
            var person = await _skContext.Persons.Include(p => p.Skills).FirstOrDefaultAsync(p => p.Id == personId);
            if (person is null)
                throw new BadRequestException($"Сотрудник с Id {personId} не найден.", HttpStatusCode.NotFound);

            return person;
        }

        /// <inheritdoc cref="PersonController.GetPersons" />
        public async Task<Person[]> GetPersons()
        {
            return await _skContext.Persons.Include(p => p.Skills).ToArrayAsync();
        }

        /// <inheritdoc cref="PersonController.PutPerson" />
        public async Task PutPerson(long personId, Person person)
        {
            var dbPerson = await GetPerson(personId);

            dbPerson.DisplayName = person.DisplayName;
            dbPerson.Name = person.Name;
            dbPerson.Skills = person.Skills;

            await _skContext.SaveChangesAsync();
        }
    }
}