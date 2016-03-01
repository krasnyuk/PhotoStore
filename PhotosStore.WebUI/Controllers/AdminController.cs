using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;

namespace PhotosStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IPhotoTechniqueRepository repository;

        public AdminController(IPhotoTechniqueRepository repo)
        {
            repository = repo;
        }
        public ViewResult Edit(int photoTechniqueId)
        {
            PhotoTechnique game = repository.PhotoTechniques
                .FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);
            return View(game);
        }
        [HttpPost]
        public ActionResult Edit(PhotoTechnique photoTechnique)
        {
            if (ModelState.IsValid)
            {
                repository.SavePhotoTechnique(photoTechnique);
                TempData["message"] = string.Format("Изменения в игре \"{0}\" были сохранены", photoTechnique.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(photoTechnique);
            }
        }
        public ViewResult Index()
        {
            return View(repository.PhotoTechniques);
        }
    }
}