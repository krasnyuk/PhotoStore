using PhotosStore.Domain.Entities;

namespace PhotosStore.Domain.Abstract
{
<<<<<<< HEAD
    //интерфейс обработчика заказов
=======
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);

<<<<<<< HEAD
     }
=======
       // void SendEmail(string email, string subject, string body);
    }
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
}