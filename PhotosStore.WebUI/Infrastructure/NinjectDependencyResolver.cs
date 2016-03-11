using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;
using PhotosStore.Domain.Concrete;
using PhotosStore.WebUI.Infrastructure.Abstract;
using PhotosStore.WebUI.Infrastructure.Concrete;

namespace PhotosStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
<<<<<<< HEAD
        //создание привязок DI
=======

>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
        private void AddBindings()
        {
            kernel.Bind<IPhotoTechniqueRepository>().To<EFPhotoTechniqueRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
<<<<<<< HEAD
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
=======
                WriteAsFile = bool.Parse(ConfigurationManager
                .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
            kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }
    }
}