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
    public class CartController : Controller
    {
        private IPhotoTechniqueRepository repository;
        public CartController(IPhotoTechniqueRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int photoTechniqueId, string returnUrl)
        {

            PhotoTechnique photoTechnique = repository.PhotoTechniques.FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);

            if (photoTechnique != null)
            {
                cart.AddItem(photoTechnique, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int photoTechniqueId, string returnUrl)
        {
            PhotoTechnique photoTechnique = repository.PhotoTechniques.FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);

            if (photoTechnique != null)
            {
                cart.RemoveLine(photoTechnique);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

    }
}