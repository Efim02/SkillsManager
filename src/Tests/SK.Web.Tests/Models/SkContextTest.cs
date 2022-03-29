namespace SK.Web.Tests.Models
{
    using Microsoft.EntityFrameworkCore;

    using SK.DB;
    using SK.DB.Models;

    /// <summary>
    /// Тестовый контекст для инициализации бд.
    /// </summary>
    public class SkContextTest : SkContext
    {
        /// <inheritdoc cref="SkContextTest"/>
        public SkContextTest()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    DisplayName = "Федор", Name = "fedor", Id = 1
                });
        }
    }
}