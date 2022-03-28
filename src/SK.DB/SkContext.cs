namespace SK.DB
{
    using System;

    using Microsoft.EntityFrameworkCore;

    using SK.DB.Models;

    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class SkContext : DbContext
    {
        public const string CONNECTION_ADDRESS = "localhost";

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
                $"server={CONNECTION_ADDRESS};user=user;password=password;port=3306;database=manager",
                new MySqlServerVersion(new Version(5, 7, 37)));
            base.OnConfiguring(optionsBuilder);
        }
    }
}