namespace SK.DB
{
    using System;

    using Microsoft.EntityFrameworkCore;

    using SK.DB.Models;
    using SK.DB.Utils;

    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class SkContext : DbContext
    {
        /// <inheritdoc cref="SkContext" />
        public SkContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;

            // Загружаем таблицы, т.к. иначе данные навыков для сотрудников не отобразятся.
            Skills.Load();
            Persons.Load();
        }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            base.OnModelCreating(modelBuilder);
        }
    }
}