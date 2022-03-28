namespace SK.DB.Models
{
    /// <summary>
    /// Навык.
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Id навыка в бд.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Уровень навыка.
        /// </summary>
        public byte Level { get; set; }

        /// <summary>
        /// Название навыка.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Владелец навыка.
        /// </summary>
        public virtual Person OwnerPerson { get; set; }

        /// <summary>
        /// Идентификатор сотрудника.
        /// </summary>
        public long PersonId { get; set; }
    }
}