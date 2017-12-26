using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Linq.Expressions;
using System.Data.Entity;
using NinjaNye.SearchExtensions;

namespace DataAccess.Repositories
{
    public class QuestionLineRepository : AbstractRepository, IQuestionLineRepository
    {
        public void AddQuestionLine(QuestionLine questionLine)
        {
            context.Questions.Add(questionLine);
            context.SaveChanges();
        }

        public QuestionLine GetQuestionLine(int id)
        {
            return context.Questions.FirstOrDefault(x => x.Id == id);
        }

        public QuestionLine GetQuestionLine(Expression<Func<QuestionLine, bool>> func)
        {
            return context.Questions.FirstOrDefault(func);
        }

        public IEnumerable<QuestionLine> GetQuestionLines()
        {
            return context.Questions.Include(x=>x.Theme);
        }

        public IEnumerable<QuestionLine> GetQuestionLines(Expression<Func<QuestionLine, bool>> func)
        {
            return context.Questions.Include(x => x.Theme).Where(func);
        }

        public IEnumerable<QuestionLine> SearchByString(Expression<Func<QuestionLine, bool>> func, string keyword)
        {
            return context.Questions.Include(x => x.Theme).Where(func)
                .Search(x => x.Answer, x => x.Question).Containing(keyword);
        }

        public void RemoveQuestionLine(int questionLineId)
        {
            QuestionLine questionLine = GetQuestionLine(questionLineId);
            context.Questions.Remove(questionLine);
            context.SaveChanges();
        }

        public void UpdateQuestionLine(QuestionLine questionLine)
        {
            QuestionLine oldQuestionLine = GetQuestionLine(questionLine.Id);

            oldQuestionLine.Answer = questionLine.Answer;
            oldQuestionLine.IsPublic = questionLine.IsPublic;

            context.SaveChanges();
        }


    }
}
