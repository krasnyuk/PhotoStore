using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;

namespace PhotosStore.WebUI.Controllers
{
    //для доступа нужна авторизация (указана в Web.config)
    [Authorize]
    public class AdminController : Controller
    {
        IPhotoTechniqueRepository repository;

        public AdminController(IPhotoTechniqueRepository repo)
        {
            repository = repo;
        }
        //GET с параметром, который вызывается при нажатии редактирования товара
        public ViewResult Edit(int photoTechniqueId)
        {
            //поиск товара по ID 
            PhotoTechnique photoTecnique = repository.PhotoTechniques
                .FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);
            return View(photoTecnique);
        }
        //вызывается при сабмите на редактировании товара
        //как параметр получает объект товара и данные изображения
        [HttpPost]
        public ActionResult Edit(PhotoTechnique photoTechnique, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    photoTechnique.ImageMimeType = image.ContentType;
                    photoTechnique.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(photoTechnique.ImageData, 0, image.ContentLength);
                }
                repository.SavePhotoTechnique(photoTechnique); //сохранение в базу
                //объект TempData получает информацию и отображается на Admin-Layout
                TempData["message"] = $"Изменения в товаре \"{photoTechnique.Name}\" были сохранены";
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(photoTechnique);
            }
        }
        //при создании нового товара вызывается редактор с моделью пустого объекта
        public ViewResult Create()
        {
            return View("Edit", new PhotoTechnique());
        }

        [HttpPost]
        public ActionResult Delete(int photoTechniqueId)
        {
            PhotoTechnique deletePhotoTechnique = repository.DeletePhotoTechnique(photoTechniqueId);
            if (deletePhotoTechnique != null)
            {
                TempData["message"] = $"Товар \"{deletePhotoTechnique.Name}\" был удалён";
            }
            return RedirectToAction("Index");
        }

        public ViewResult Index()
        {
            return View(repository.PhotoTechniques);
        }
    }
}