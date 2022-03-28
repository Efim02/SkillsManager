namespace SK.BL.Models
{
    /// <summary>
    /// Навык.
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Название навыка.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Уровень навыка.
        /// </summary>
        public byte Level { get; set; }
    }
}