<<<<<<< HEAD
﻿using System.Web.Mvc;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
using PhotosStore.Domain.Entities;

namespace PhotosStore.WebUI.Infrastructure.Binders
{
<<<<<<< HEAD
    //связыватель модели для класса корзины
=======
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Получить объект Cart из сеанса
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }

            // Создать объект Cart если он не обнаружен в сеансе
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            // Возвратить объект Cart
            return cart;
        }
    }
}