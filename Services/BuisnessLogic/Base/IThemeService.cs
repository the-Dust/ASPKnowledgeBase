using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.BuisnessLogic.Base
{
    public interface IThemeService
    {
        IEnumerable<Theme> GetThemes();

        IEnumerable<Theme> GetThemes(Expression<Func<Theme, bool>> func);

        Theme GetTheme(int id);

        Theme GetTheme(Expression<Func<Theme, bool>> func);

        void RemoveTheme(int themeId);

        void UpdateTheme(Theme theme);

        void AddTheme(Theme theme);
    }
}
