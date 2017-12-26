using ASPKnowledgeBase.Models;
using DataAccess.Entities;
using DataAccess.Repositories.Base;
using Services.BuisnessLogic.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ASPKnowledgeBase.Controllers
{
    public class HomeController : Controller
    {
        IThemeService themeService = null;
        IQuestionLineService questionLineService = null;

        public HomeController(IThemeService themeService, IQuestionLineService questionLineService)
        {
            this.themeService = themeService;
            this.questionLineService = questionLineService;
        }

        public ActionResult Index()
        {
            ViewBag.Themes = themeService.GetThemes().Select(x => x.Description);

            IEnumerable<QuestionLine> questions = questionLineService.GetQuestionLines();

            return View(questions);
        }

        public PartialViewResult ShowContent()
        {
            ViewBag.Themes = themeService.GetThemes().Select(x => x.Description);

            return PartialView("_ShowContent");
        }

        [HttpGet]
        public PartialViewResult AddQuestion()
        {
            ViewBag.Themes = themeService.GetThemes().Select(x => x.Description);

            return PartialView("_UserQuestionForm");
        }

        [HttpPost]
        public PartialViewResult AddQuestion(QuestionLine line)
        {
            ViewBag.Themes = themeService.GetThemes().Select(x => x.Description);

            line.Date = DateTime.Now;
            line.IsPublic = false;

            if (ModelState.IsValid)
            {
                ViewBag.SuccessMessage = "Вопрос задан";
                questionLineService.AddQuestionLine(line);
                ModelState.Clear();
                return PartialView("_UserQuestionForm");
            }

            return PartialView("_UserQuestionForm", line);
        }


        public PartialViewResult ShowAnswers(int themeId=0)
        {
            ViewBag.Themes = themeService.GetThemes().Select(x => x.Description);

            Expression<Func<QuestionLine, bool>> constraints = 
                x => (themeId==0?true:x.ThemeId == themeId) && x.IsPublic && !(x.Answer == null || x.Answer.Trim() == string.Empty);

            IEnumerable<QuestionLine> questions = questionLineService.GetQuestionLines(constraints).ToArray();

            return PartialView("_UserAnswers", questions);
        }

        public PartialViewResult SearchAnswers(int themeId, string keyword)
        {
            ViewBag.Themes = themeService.GetThemes().Select(x => x.Description);

            Expression<Func<QuestionLine, bool>> constraints =
                x => (themeId == 0 ? true : x.ThemeId == themeId) && x.IsPublic && !(x.Answer == null || x.Answer.Trim() == string.Empty); 

            IEnumerable<QuestionLine> questions = questionLineService.SearchByString(constraints, keyword).ToArray();

            return PartialView("_UserAnswers", questions);
        }
    }
}