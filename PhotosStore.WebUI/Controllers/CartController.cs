using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Concrete;
using PhotosStore.Domain.Entities;
using PhotosStore.WebUI.Models;

namespace PhotosStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IPhotoTechniqueRepository repository; //репозиторий
        private IOrderProcessor orderProcessor; //обработчик заказов
        public CartController(IPhotoTechniqueRepository repo, IOrderProcessor orderProcessor)
        {
            repository = repo;
            this.orderProcessor = orderProcessor;
        }
        //для отображение формы введения данных
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (!cart.Lines.Any())
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails); //обработка заказа
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        //отображение корзины
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart, //содержимое карты
                ReturnUrl = returnUrl //строка возврата
            });
        }
        //добавление товара в корзину
        public RedirectToRouteResult AddToCart(Cart cart, int photoTechniqueId, string returnUrl)
        {
            PhotoTechnique photoTechnique = repository.PhotoTechniques
                .FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);

            if (photoTechnique != null)
            {
                cart.AddItem(photoTechnique, 1); //добавление товара в корзину
            }
            return RedirectToAction("Index", new { returnUrl }); // редирект в корзину
        }
        //удаление товара из корзины
        public RedirectToRouteResult RemoveFromCart(Cart cart, int photoTechniqueId, string returnUrl)
        {
            PhotoTechnique photoTechnique = repository.PhotoTechniques.FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);

            if (photoTechnique != null)
            {
                cart.RemoveLine(photoTechnique);
            }
            return RedirectToAction("Index", new { returnUrl }); //перенаправление по адресу возврата
        }
        //дочерние действие для выводы короткой информации о корзине вверху
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

    }
}