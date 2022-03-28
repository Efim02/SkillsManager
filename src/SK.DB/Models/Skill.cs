namespace SK.DB.Models
{
    /// <summary>
    /// Навык.
    /// </summary>
    public class Skill
    {
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
        public Person OwnerPerson { get; set; }
    }
}