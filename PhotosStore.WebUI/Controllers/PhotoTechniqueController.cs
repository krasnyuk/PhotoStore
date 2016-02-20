using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;
using PhotosStore.WebUI.Models;

namespace PhotosStore.WebUI.Controllers
{
    public class PhotoTechniqueController : Controller
    {
        private IPhotoTechniqueRepository repository;
        public int pageSize = 4;

        public PhotoTechniqueController(IPhotoTechniqueRepository repo)
        {
            repository = repo;
        }
       
        public ViewResult List(int page = 1)
        {
            PhotoTechniqueListViewModel model = new PhotoTechniqueListViewModel
            {
                PhotoTechniques = repository.PhotoTechniques
                    .OrderBy(game => game.PhotoTechniqueId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.PhotoTechniques.Count()
                }
            };
            return View(model);
        }
    }
}