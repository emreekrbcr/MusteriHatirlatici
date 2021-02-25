using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.Feedback.Abstract;
using Core.Tools.MyExceptions;

namespace Core.Tools.Feedback.Concrete
{
    public class LogSender : IMailSender
    {
        public void SendMail()
        {
            MailMessage message = new MailMessage();
            SmtpClient client = new SmtpClient(@"smtp.live.com", 587);
            client.Credentials = new NetworkCredential(@"csharp_icin06@hotmail.com", @"hot.1071C#1701");
            client.EnableSsl = true; //Socket Secure Layer: Sunucuyla istemci arasındaki verileri doğru adrese gönderene kadar şifreleyen komut
            message.From = new MailAddress(@"csharp_icin06@hotmail.com");
            message.To.Add(@"eekbr96@gmail.com");
            message.Subject = @"Musteri Hatirlatici C#";
            message.Body = @"Log dosyaları ektedir.";

            if (!Directory.Exists(@"Temp"))
            {
                Directory.CreateDirectory("Temp");
            }

            if (!File.Exists(@"Temp\tempLogKnowns.lg") && File.Exists(@"Logs\LogKnowns.lg"))
            {
                File.Copy(@"Logs\LogKnowns.lg", @"Temp\tempLogKnowns.lg");
            }

            if (!File.Exists(@"Temp\tempLogUnknowns.lg") && File.Exists(@"Logs\LogUnknowns.lg"))
            {
                File.Copy(@"Logs\LogUnknowns.lg", @"Temp\tempLogUnknowns.lg");
            }

            string path1= @"Temp\tempLogKnowns.lg", path2= @"Temp\tempLogUnknowns.lg";
            Attachment att1 = null, att2 = null;

            if (!File.Exists(path1) && !File.Exists(path2)) //Log dosyalarının ikisi de yoksa hata fırlatsın
            {
                throw new MissingFileException("Gönderilecek hata kaydı bulunmuyor");
            }
            if (File.Exists(path1))
            {
                using (FileStream fs1 = new FileStream(path1, FileMode.Open))
                {
                    fs1.Flush(); //fs1 kullanılıyorsa hafızadan temizler
                    fs1.Close(); //fs1'i kapatır
                }
                att1=new Attachment(path1);
                message.Attachments.Add(att1);
            }
            if (File.Exists(path2))
            {
                using (FileStream fs2 = new FileStream(path2, FileMode.Open))
                {
                    fs2.Flush();
                    fs2.Close();
                }
                att2=new Attachment(path2);
                message.Attachments.Add(att2);
            }
            try
            {
                client.Send(message); //Bu adımları geçtikten sonra mail'i göndermeyi denesin
            }
            finally
            {
                //Eğer Attachment'leri dispose etmezsem dosya kullanılıyor gibisinden hata mesajı veriyor ve Temp klasörünü silemiyordum
                att1?.Dispose(); //null değilse dispose etsin
                att2?.Dispose(); //bu şekilde yazmaya null propogation deniyormuş, Resharper önerdi :)
                Directory.Delete(@"Temp", true); //Mail gönderilse de gönderilmese de bu dosya silinecek o yüzden finally
            }
            throw new ActionSuccessfulException(@"Hata kayıtları başarıyla gönderildi"); //Messagebox'ta göstermek için exception fırlattım
        }
    }
}
