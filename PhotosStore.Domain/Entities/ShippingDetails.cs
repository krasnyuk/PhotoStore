using System.ComponentModel.DataAnnotations;

namespace PhotosStore.Domain.Entities
{
   public class ShippingDetails
    {
        [Required(ErrorMessage = "Укажите как вас зовут")]
        public string Name { get; set; }

<<<<<<< HEAD
        [Required(ErrorMessage = "Введите e-mail")]
        [Display(Name = "Электронная почта")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage ="Некорректный email")]
        public string Email { get; set; }
=======
        [Required(ErrorMessage = "Вставьте первый адрес доставки")]
        [Display(Name = "Первый адрес")]
        public string Line1 { get; set; }
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6

        [Display(Name = "Второй адрес")]
        public string Line2 { get; set; }

        [Display(Name = "Третий адрес")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
