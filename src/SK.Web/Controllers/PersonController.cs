namespace SkillsManager.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;

    using SK.BL.Models;

    using SkillsManager.Services;

    /// <summary>
    /// Контроллер сотрудников.
    /// </summary>
    [ApiController]
    [Route("api/persons")]
    public class PersonController : ControllerBase
    {
        /// <summary>
        /// Картограф.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Сервис сотрудника.
        /// </summary>
        private readonly PersonService _personService;

        /// <inheritdoc cref="PersonController" />
        public PersonController(IMapper mapper, PersonService personService)
        {
            _mapper = mapper;
            _personService = personService;
        }

        /// <summary>
        /// Добавить сотрудника.
        /// </summary>
        /// <param name="person">Сотрудник.</param>
        /// <returns>Id сотрудника.</returns>
        [HttpPost]
        public async Task<long> AddPerson(Person person)
        {
            var dbPerson = _mapper.Map<SK.DB.Models.Person>(person);
            return await _personService.AddPerson(dbPerson);
        }

        /// <summary>
        /// Получить сотрудника по Id.
        /// </summary>
        /// <param name="personId">Id сотрудника.</param>
        /// <returns>Сотрудник.</returns>
        [HttpGet]
        [Route("{personId:long}")]
        public async Task<Person> GetPerson(long personId)
        {
            var dbPerson = await _personService.GetPerson(personId);
            return _mapper.Map<Person>(dbPerson);
        }

        /// <summary>
        /// Получить всех сотрудников.
        /// </summary>
        /// <returns>Сотрудников.</returns>
        [HttpGet]
        public async Task<Person[]> GetPersons()
        {
            var dbPersons = await _personService.GetPersons();
            return _mapper.Map<SK.DB.Models.Person[], IEnumerable<Person>>(dbPersons).ToArray();
        }

        /// <summary>
        /// Изменить существующего сотрудника.
        /// </summary>
        /// <param name="personId">Id сотрудника.</param>
        /// <param name="person">Тело сотрудника.</param>
        [HttpPut]
        [Route("{personId:long}")]
        public async Task PutPerson(long personId, Person person)
        {
            var dbPerson = _mapper.Map<SK.DB.Models.Person>(person);
            await _personService.PutPerson(personId, dbPerson);
        }

        /// <summary>
        /// Удалить сотрудника.
        /// </summary>
        /// <param name="personId">Id сотрудника.</param>
        [HttpDelete]
        [Route("{personId:long}")]
        public async Task DeletePerson(long personId)
        {
            await _personService.DeletePerson(personId);
        }
    }
}