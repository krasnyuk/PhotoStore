using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;

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

        private void AddBindings()
        {
            Mock<IPhotoTechniqueRepository> mock = new Mock<IPhotoTechniqueRepository>();
            mock.Setup(m => m.PhotoTechniques).Returns(new List<PhotoTechnique>
    {
        new PhotoTechnique { Name = "Canon 5d mk II", Price = 1499 },
        new PhotoTechnique { Name = "Nikon D90", Price=2299 },
        new PhotoTechnique { Name = "Nikon D810", Price=899.4M }
    });
            kernel.Bind<IPhotoTechniqueRepository>().ToConstant(mock.Object);
        }
    }
}