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
       
        public ViewResult List(string category, int page = 1)
        {

            PhotoTechniqueListViewModel model = new PhotoTechniqueListViewModel
            {
                PhotoTechniques = repository.PhotoTechniques
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(game => game.PhotoTechniqueId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
        repository.PhotoTechniques.Count() :
        repository.PhotoTechniques.Count(game => game.Category == category)
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}