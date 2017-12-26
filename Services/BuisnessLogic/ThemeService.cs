using Services.BuisnessLogic.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Linq.Expressions;
using DataAccess.Repositories.Base;

namespace Services.BuisnessLogic
{
    public class ThemeService : IThemeService
    {
        private IThemeRepository themeRepository = null;

        public ThemeService(IThemeRepository themeRepository)
        {
            this.themeRepository = themeRepository;
        }

        public void AddTheme(Theme theme)
        {
            themeRepository.AddTheme(theme);
        }

        public Theme GetTheme(int id)
        {
            return themeRepository.GetTheme(id);
        }

        public Theme GetTheme(Expression<Func<Theme, bool>> func)
        {
            return themeRepository.GetTheme(func);
        }

        public IEnumerable<Theme> GetThemes()
        {
            return themeRepository.GetThemes();
        }

        public IEnumerable<Theme> GetThemes(Expression<Func<Theme, bool>> func)
        {
            return themeRepository.GetThemes(func);
        }

        public void RemoveTheme(int themeId)
        {
            themeRepository.RemoveTheme(themeId);
        }

        public void UpdateTheme(Theme theme)
        {
            themeRepository.UpdateTheme(theme);
        }
    }
}
