using System.Net;
using System.Net.Mail;
using System.Text;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;

namespace PhotosStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "krasnyuk-photo@mail.ru";
        public string MailFromAddress = "krasnyuk.photo@gmail.com";
        public bool UseSsl = true;
        public string Username = "krasnyuk.photo@gmail.com";
        public string Password = "bafnet123";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"D:\Programming\photo_store_emails";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("Новый заказ обработан")
                    .AppendLine("---")
                    .AppendLine("Товары:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.PhotoTechnique.Price*line.Quantity;
                    body.AppendFormat("{0} x {1} (итого: {2:c}",
                        line.Quantity, line.PhotoTechnique.Name, subtotal);
                }

                body.AppendFormat("Общая стоимость: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Доставка:")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Line1)
                    .AppendLine(shippingInfo.Line2 ?? "")
                    .AppendLine(shippingInfo.Line3 ?? "")
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.Country)
                    .AppendLine("---")
                    .AppendFormat("Подарочная упаковка: {0}",
                        shippingInfo.GiftWrap ? "Да" : "Нет");

                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress, // От кого
                    emailSettings.MailToAddress, // Кому
                    "Новый заказ отправлен!", // Тема
                    body.ToString()); // Тело письма

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
