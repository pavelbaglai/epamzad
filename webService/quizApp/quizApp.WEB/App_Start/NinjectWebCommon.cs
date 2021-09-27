using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using quizApp.BLL.Interfaces;
using quizApp.BLL.Services;
using System;
using System.Web;
using System.Web.Http;
using Ninject.Web.WebApi;
using Ninject.Modules;
using quizApp.BLL.Infrastructure;
using quizApp.BLL.Models;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(quizApp.WEB.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(quizApp.WEB.App_Start.NinjectWebCommon), "Stop")]

namespace quizApp.WEB.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            // внедрение зависимостей
            LoadModules(kernel);
            RegisterServices(kernel);
            return kernel;
        }

        private static void LoadModules(StandardKernel kernel)
        {
            NinjectModule serviceModule = new ServiceModule("quizApp");
            kernel.Load(serviceModule);
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICardService>().To<CardService>();
        }
    }
}