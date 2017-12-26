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
    public class QuestionLineService : IQuestionLineService
    {
        private IQuestionLineRepository questionLineRepository = null;

        public QuestionLineService(IQuestionLineRepository questionLineRepository)
        {
            this.questionLineRepository = questionLineRepository;
        }

        public void AddQuestionLine(QuestionLine questionLine)
        {
            questionLineRepository.AddQuestionLine(questionLine);
        }

        public QuestionLine GetQuestionLine(int id)
        {
            return questionLineRepository.GetQuestionLine(id);
        }

        public QuestionLine GetQuestionLine(Expression<Func<QuestionLine, bool>> func)
        {
            return questionLineRepository.GetQuestionLine(func);
        }

        public IEnumerable<QuestionLine> GetQuestionLines()
        {
            return questionLineRepository.GetQuestionLines();
        }

        public IEnumerable<QuestionLine> GetQuestionLines(Expression<Func<QuestionLine, bool>> func)
        {
            return questionLineRepository.GetQuestionLines(func);
        }

        public IEnumerable<QuestionLine> SearchByString(Expression<Func<QuestionLine, bool>> func, string keyword)
        {
            return questionLineRepository.SearchByString(func, keyword);
        }

        public void RemoveQuestionLine(int questionLineId)
        {
            questionLineRepository.RemoveQuestionLine(questionLineId);
        }

        public void UpdateQuestionLine(QuestionLine questionLine)
        {
            questionLineRepository.UpdateQuestionLine(questionLine);
        }
    }
}
