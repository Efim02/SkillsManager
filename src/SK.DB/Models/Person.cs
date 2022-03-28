namespace SK.DB.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Сотрудник.
    /// </summary>
    public class Person
    {
        /// <inheritdoc cref="Person" />
        public Person()
        {
            Skills = new List<Skill>();
        }

        /// <summary>
        /// Отображаемое имя.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Уникальный идентификатор сотрудника.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Уникальное имя сотрудника.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Навыки имеющиеся.
        /// </summary>
        public List<Skill> Skills { get; set; }
    }
}