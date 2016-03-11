using PhotosStore.Domain.Entities;

namespace PhotosStore.Domain.Abstract
{
    //интерфейс обработчика заказов
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);

     }
}