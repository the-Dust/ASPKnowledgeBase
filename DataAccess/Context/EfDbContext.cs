using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("EfDbContext")
        {

        }

        public DbSet<Theme> Themes { get; set; }

        public DbSet<QuestionLine> Questions { get; set; }
    }

    public class EfDbInitializer : DropCreateDatabaseAlways<EfDbContext>
    {
        protected override void Seed(EfDbContext context)
        {
            context.Themes.AddRange(new List<Theme> {
                new Theme { Description = "Спорт" },
                new Theme { Description = "Политика" },
                new Theme { Description = "Космос" },
            });

            context.SaveChanges();

            context.Questions.AddRange(new List<QuestionLine> {
                new QuestionLine { Date = DateTime.Now, IsPublic = true, Author = "Петя",
                    Email ="petya@mail.ru", ThemeId = 1, Question="Это тестовый вопрос про спорт", Answer = "Это тестовый ответ про спорт"},

                new QuestionLine { Date = DateTime.Now, IsPublic = true, Author = "Вася",
                    Email ="vasya@mail.ru", ThemeId = 2, Question="Это тестовый вопрос про политику", Answer = "Это тестовый ответ про политику"},

                new QuestionLine { Date = DateTime.Now, IsPublic = true, Author = "Дима",
                    Email ="dima@mail.ru", ThemeId = 3, Question="Это тестовый вопрос про космос", Answer = "Это тестовый ответ про космос"}
            });

            context.SaveChanges();

        }
    }



}
