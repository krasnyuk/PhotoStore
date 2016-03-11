using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;

namespace PhotosStore.WebUI.Controllers
{
    //контроллер навигации 
    public class NavController : Controller
    {
        private IPhotoTechniqueRepository repository;

        public NavController(IPhotoTechniqueRepository repo)
        {
            repository = repo;
        }
        //меню категорий
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category; //выделить категорию как btn-primary
            //получение категорий из БД
            IEnumerable<string> categories = repository.PhotoTechniques 
                .Select(technique => technique.Category)    //по категории
                .Distinct()
                .OrderBy(x => x);                           //отсортировать
            return PartialView(categories);
        }
    }
}