using System.Collections.Generic;

namespace quizApp.Data.Interfaces
{
    public interface ISqlRepository<T> : IRepository<T> where T : class
    {
        IEnumerable<T> ExecSelect(string sqlExpression);
    }

}
