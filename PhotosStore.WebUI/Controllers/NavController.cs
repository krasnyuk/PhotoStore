using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;

namespace PhotosStore.WebUI.Controllers
{
<<<<<<< HEAD
    //контроллер навигации 
=======
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
    public class NavController : Controller
    {
        private IPhotoTechniqueRepository repository;

        public NavController(IPhotoTechniqueRepository repo)
        {
            repository = repo;
        }
<<<<<<< HEAD
        //меню категорий
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category; //выделить категорию как btn-primary
            //получение категорий из БД
            IEnumerable<string> categories = repository.PhotoTechniques 
                .Select(technique => technique.Category)    //по категории
                .Distinct()
                .OrderBy(x => x);                           //отсортировать
=======

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.PhotoTechniques
                .Select(technique => technique.Category)
                .Distinct()
                .OrderBy(x => x);
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
            return PartialView(categories);
        }
    }
}