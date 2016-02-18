using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;

namespace PhotosStore.WebUI.Controllers
{
    public class PhotoTechniqueController : Controller
    {
        private IPhotoTechniqueRepository repository;
        public PhotoTechniqueController(IPhotoTechniqueRepository repo)
        {
            repository = repo;
        }
        public ViewResult List()
        {
            return View(repository.PhotoTechniques);
        }
    }
}