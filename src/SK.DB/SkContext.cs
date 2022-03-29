namespace SK.DB
{
    using System;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using SK.DB.Models;
    using SK.DB.Utils;

    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class SkContext : DbContext
    {
        /// <summary>
        /// Сотрудники.
        /// </summary>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        /// Навыки.
        /// </summary>
        public DbSet<Skill> Skills { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                SkContextUtils.GetConnectionStrings(),
                new MySqlServerVersion(new Version(5, 7, 37)));

            base.OnConfiguring(optionsBuilder);
        }
    }
}