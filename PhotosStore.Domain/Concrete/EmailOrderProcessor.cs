using System.Net;
using System.Net.Mail;
using System.Text;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;

namespace PhotosStore.Domain.Concrete
{
    //класс с дефолтными значениями настроек почты
    public class EmailSettings
    {
        public string MailToAddress = "krasnyuk-photo@mail.ru"; //куда придёт по дефолту
        public string MailFromAddress = "krasnyuk.photo@gmail.com"; //кто отправитель
        public bool UseSsl = true;
        public string Username = "krasnyuk.photo@gmail.com"; // логин отправителя
        public string Password = "bafnet123";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true; //сохранять как файл на жёстком диске
        public string FileLocation = @"D:\Programming\photo_store_emails"; //путь к папке
    }
    //реализация обработчика заказов
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings _emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            _emailSettings = settings;
        }
       
        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                smtpClient.Host = _emailSettings.ServerName;
                smtpClient.Port = _emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailSettings.Username,_emailSettings.Password);
                MailMessage msg = new MailMessage
                {
                    From = new MailAddress(_emailSettings.MailFromAddress) //от кого
                };
                msg.To.Add(new MailAddress(shippingInfo.Email)); //кому
                msg.Subject = "Заказ"; //тема письма
                //формирование тела письма
                StringBuilder body = new StringBuilder()
                    .AppendLine("Новый заказ обработан")
                    .AppendLine("---")
                    .AppendLine("Товары:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.PhotoTechnique.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (итого: {2:c}",
                        line.Quantity, line.PhotoTechnique.Name, subtotal);
                }

                body.AppendFormat("Общая стоимость: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Доставка:")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Email)
                    .AppendLine(shippingInfo.Line2 ?? "")
                    .AppendLine(shippingInfo.Line3 ?? "")
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.Country)
                    .AppendLine("---")
                    .AppendFormat("Подарочная упаковка: {0}",
                        shippingInfo.GiftWrap ? "Да" : "Нет");
                msg.Body = body.ToString();
                smtpClient.Send(msg);
                
            }
        }
    }
}
