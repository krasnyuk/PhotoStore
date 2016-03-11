using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotosStore.Domain.Entities;

namespace PhotosStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; } //данные о объекте корзины
        public string ReturnUrl { get; set; } //адресс возврата 
    }
}