namespace SkillsManager.Services
{
    using System.Net;
    using System.Threading.Tasks;

    using AutoMapper;

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
        /// Картограф.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Контекст бд.
        /// </summary>
        private readonly SkContext _skContext;

        /// <inheritdoc cref="PersonService" />
        public PersonService(SkContext skContext, IMapper mapper)
        {
            _skContext = skContext;
            _mapper = mapper;
        }

        /// <inheritdoc cref="PersonController.AddPerson" />
        public async Task<long> AddPerson(Person person)
        {
            await _skContext.Persons.AddAsync(person);
            await _skContext.SaveChangesAsync();
            return person.Id;
        }

        /// <inheritdoc cref="PersonController.GetPerson" />
        public async Task<Person> GetPerson(long personId)
        {
            var person = await _skContext.Persons.FirstOrDefaultAsync(p => p.Id == personId);
            if (person is null)
                throw new BadRequestException($"Сотрудник с Id {personId} не найден.", HttpStatusCode.NotFound);

            return person;
        }

        /// <inheritdoc cref="PersonController.GetPersons" />
        public async Task<Person[]> GetPersons()
        {
            return await _skContext.Persons.ToArrayAsync();
        }

        /// <inheritdoc cref="PersonController.PutPerson" />
        public async Task PutPerson(long personId, Person person)
        {
            var dbPerson = await _skContext.Persons.FirstOrDefaultAsync(p => p.Id == personId);
            if (person is null)
                throw new BadRequestException($"Сотрудник с Id {personId} не найден.", HttpStatusCode.NotFound);

            _mapper.Map(person, dbPerson);
            dbPerson.Id = personId;

            await _skContext.SaveChangesAsync();
        }
    }
}