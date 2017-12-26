using ASPKnowledgeBase.Models;
using DataAccess.Entities;
using Services.BuisnessLogic.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPKnowledgeBase.Controllers
{
    [Authorize(Users = "admin")]
    public class AdminController : Controller
    {
        IThemeService themeService = null;
        IQuestionLineService questionLineService = null;

        public AdminController(IThemeService themeService, IQuestionLineService questionLineService)
        {
            this.themeService = themeService;
            this.questionLineService = questionLineService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region Themes Methods

        public PartialViewResult GetThemes()
        {
            IEnumerable<Theme> themes = themeService.GetThemes();

            return PartialView("Modal/_Themes", themes);
        }

        public PartialViewResult EditTheme(int themeId)
        {
            return PartialView("Modal/_EditTheme", themeId);
        }

        public PartialViewResult GetTheme(int themeId)
        {
            Theme theme = themeService.GetTheme(themeId);

            return PartialView("Modal/_ThemePartial", theme);
        }

        [HttpPost]
        public ActionResult UpdateTheme(Theme theme)
        {
            if (ModelState.IsValid)
            {
                if (theme.Id == 0)
                {
                    themeService.AddTheme(theme);
                }

                themeService.UpdateTheme(theme);

                ViewBag.Message = "Изменения в теме были сохранены";

            }
            return PartialView("Modal/_ThemePartial", theme);
        }

        [HttpPost]
        public ActionResult AddTheme([Bind(Exclude = "Id")]Theme theme)
        {
            return UpdateTheme(theme);
        }

        [HttpPost]
        public PartialViewResult RemoveTheme(int themeId)
        {
            themeService.RemoveTheme(themeId);

            return GetThemes();
        }

        #endregion

        #region QuestionLines Methods

        public PartialViewResult GetQuestions()
        {
            //New questions are on the top
            IEnumerable<QuestionLine> questions = questionLineService.GetQuestionLines().OrderByDescending(x=>x.Id);

            return PartialView("Modal/_Questions", questions);
        }

        public PartialViewResult EditQuestion(int questionId)
        {
            return PartialView("Modal/_EditQuestion", questionId);
        }

        public PartialViewResult GetAnswer(int questionId)
        {
            QuestionLine question = questionLineService.GetQuestionLine(questionId);

            return PartialView("Modal/_QuestionPartial", question);
        }

        [HttpPost]
        public PartialViewResult UpdateQuestion(QuestionLine question)
        {
            QuestionLine refer = questionLineService.GetQuestionLine(question.Id);

            refer.IsPublic = question.IsPublic;

            refer.Answer = question.Answer;

            questionLineService.UpdateQuestionLine(refer);

            ViewBag.Message = "Изменения в вопросе были сохранены";

            return PartialView("Modal/_QuestionPartial", question);
        }
        #endregion
    }
}