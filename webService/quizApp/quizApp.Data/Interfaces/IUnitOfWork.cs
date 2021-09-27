using quizApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizApp.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Card> CardSet { get; }
        IRepository<CardGroup> GroupSet { get; }
        void Save();
    }
}
