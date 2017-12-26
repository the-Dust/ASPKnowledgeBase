using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.BuisnessLogic.Base
{
    public interface IQuestionLineService
    {
        IEnumerable<QuestionLine> GetQuestionLines();

        IEnumerable<QuestionLine> GetQuestionLines(Expression<Func<QuestionLine, bool>> func);

        IEnumerable<QuestionLine> SearchByString(Expression<Func<QuestionLine, bool>> func, string keyword);

        QuestionLine GetQuestionLine(int id);

        QuestionLine GetQuestionLine(Expression<Func<QuestionLine, bool>> func);

        void RemoveQuestionLine(int questionLineId);

        void UpdateQuestionLine(QuestionLine questionLine);

        void AddQuestionLine(QuestionLine questionLine);
    }
}
