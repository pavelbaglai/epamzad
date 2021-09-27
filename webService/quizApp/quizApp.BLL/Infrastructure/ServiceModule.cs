using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using quizApp.Data.Interfaces;
using quizApp.Data.Repositories;

namespace quizApp.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;

        public ServiceModule(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<AdoUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
