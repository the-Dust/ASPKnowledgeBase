using ASPKnowledgeBase.Infrastructure.Base;
using DataAccess.Repositories;
using DataAccess.Repositories.Base;
using Ninject;
using Services.BuisnessLogic;
using Services.BuisnessLogic.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASPKnowledgeBase.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public IKernel Kernel { get; private set; }

        public NinjectControllerFactory()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }

        public void AddBindings()
        {
            Kernel.Bind<IThemeRepository>().To<ThemeRepository>();
            Kernel.Bind<IQuestionLineRepository>().To<QuestionLineRepository>();


            Kernel.Bind<IThemeService>().To<ThemeService>();
            Kernel.Bind<IQuestionLineService>().To<QuestionLineService>();

            Kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType != null ? (IController)Kernel.Get(controllerType) : null;
        }
    }
}