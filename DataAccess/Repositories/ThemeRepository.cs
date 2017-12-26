using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class ThemeRepository : AbstractRepository, IThemeRepository
    {
        public void AddTheme(Theme theme)
        {
            context.Themes.Add(theme);
            context.SaveChanges();
        }

        public Theme GetTheme(int id)
        {
            return context.Themes.FirstOrDefault(x => x.Id == id);
        }

        public Theme GetTheme(Expression<Func<Theme, bool>> func)
        {
            return context.Themes.FirstOrDefault(func);
        }

        public IEnumerable<Theme> GetThemes()
        {
            return context.Themes;
        }

        public IEnumerable<Theme> GetThemes(Expression<Func<Theme, bool>> func)
        {
            return context.Themes.Where(func);
        }

        public void RemoveTheme(int themeId)
        {
            Theme theme = GetTheme(themeId);
            context.Themes.Remove(theme);
            context.SaveChanges();
        }

        public void UpdateTheme(Theme theme)
        {
            Theme oldTheme = GetTheme(theme.Id);
            oldTheme.Description = theme.Description;

            context.SaveChanges();
        }
    }
}
