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
<<<<<<< HEAD
        private IPhotoTechniqueRepository repository; //репозиторий
        private IOrderProcessor orderProcessor; //обработчик заказов
=======
        private IPhotoTechniqueRepository repository;
        private IOrderProcessor orderProcessor;
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
        public CartController(IPhotoTechniqueRepository repo, IOrderProcessor orderProcessor)
        {
            repository = repo;
            this.orderProcessor = orderProcessor;
        }
<<<<<<< HEAD
        //для отображение формы введения данных
=======

>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
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
<<<<<<< HEAD
                orderProcessor.ProcessOrder(cart, shippingDetails); //обработка заказа
=======
                orderProcessor.ProcessOrder(cart, shippingDetails);
                //orderProcessor.SendEmail("krasnyuk.photo@gmail.com","Заказ","Some text");
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
<<<<<<< HEAD

        //отображение корзины
=======
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
<<<<<<< HEAD
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
=======
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

>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
        public RedirectToRouteResult RemoveFromCart(Cart cart, int photoTechniqueId, string returnUrl)
        {
            PhotoTechnique photoTechnique = repository.PhotoTechniques.FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);

            if (photoTechnique != null)
            {
                cart.RemoveLine(photoTechnique);
            }
<<<<<<< HEAD
            return RedirectToAction("Index", new { returnUrl }); //перенаправление по адресу возврата
        }
        //дочерние действие для выводы короткой информации о корзине вверху
=======
            return RedirectToAction("Index", new { returnUrl });
        }
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

    }
}