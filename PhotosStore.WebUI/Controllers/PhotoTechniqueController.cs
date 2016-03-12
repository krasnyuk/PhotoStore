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
<<<<<<< HEAD
            // формирование модели фототехники
=======

>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
            PhotoTechniqueListViewModel model = new PhotoTechniqueListViewModel
            {
                PhotoTechniques = repository.PhotoTechniques
                    .Where(p => category == null || p.Category == category)
<<<<<<< HEAD
                    .OrderBy(t => t.PhotoTechniqueId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo //информация для навигации
=======
                    .OrderBy(game => game.PhotoTechniqueId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
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
<<<<<<< HEAD
        //получение изображения из базы
        public FileContentResult GetImage(int photoTechniqueId)
        {
            PhotoTechnique technique = repository.PhotoTechniques
                .FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);
            
            if (technique != null)
            {
                return File(technique.ImageData, technique.ImageMimeType);
=======
        public FileContentResult GetImage(int photoTechniqueId)
        {
            PhotoTechnique game = repository.PhotoTechniques
                .FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);

            if (game != null)
            {
                return File(game.ImageData, game.ImageMimeType);
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
            }
            else
            {
                return null;
            }
        }
    }
}