using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Utils;
using Windows.ApplicationModel.Email;
using Windows.Storage;
using Windows.Storage.Streams;

namespace PhotoboothApp.Services.EmailService
{
    class EmailService
    {
        public async void Send(string email, string subject, string body, params StorageFile[] file)
        {
            var message = new EmailMessage()
            {
                Body = body,
                Subject = subject,
            };
            message.To.Add(new EmailRecipient(email));
            file?.ForEach(f =>
            {
                var stream = RandomAccessStreamReference.CreateFromFile(f);
                var attachment = new EmailAttachment(f.Name, stream);
                message.Attachments.Add(attachment);
            });
            await EmailManager.ShowComposeNewEmailAsync(message);
        }
    }
}
