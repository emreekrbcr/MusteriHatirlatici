using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.Logger.Abstract;

namespace Core.Tools.Logger.Concrete
{
    public class FileLogger : ILogger
    {
        public void Log(Exception exception)
        {
            var type = exception.GetType();
            if (!Directory.Exists("Logs")) //Logs klasörü yoksa oluştursun, varsa oluşturmasın
            {
                Directory.CreateDirectory("Logs");
            }

            if (IsKnown(type))
            {
                //Hata bildiğimiz bir hataysa buraya loglasın. Fantezi niyetine bakarız sonra :)
                LogOperations(exception, @"Logs\LogKnowns.lg");
            }
            else
            {
                //Hata bilmediğimiz bir hataysa, programda düzeltilmesi gereken bir durum vardır. Dolayısıyla bildiğimiz hatalarla karışıp
                //işimiz zorlaşmasın diye ayrı bir dosyaya logluyorum
                LogOperations(exception, @"Logs\LogUnknowns.lg");
            }

        }

        private static void LogOperations(Exception exception, string path)
        {
            using (StreamWriter writer=new StreamWriter(path,true)) // true parametresi üzerine yazmasın diye
            {
                writer.Write(Environment.MachineName+@"\"+Environment.UserName);
                writer.Write(" Tarih: "+DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                writer.WriteLine();
                writer.Write("Error message: "+exception.Message);
                writer.WriteLine();
                writer.Write("Stack Trace:"+Environment.NewLine);
                writer.WriteLine(exception.StackTrace);
                writer.WriteLine("*********************************************"+Environment.NewLine);
                writer.Flush();
                writer.Close();

                //File.AppendAllText(path, Environment.MachineName + @"\" + Environment.UserName);
                //File.AppendAllText(path, "  Tarih: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                //File.AppendAllText(path, Environment.NewLine);
                //File.AppendAllText(path, "Error message: " + exception.Message);
                //File.AppendAllText(path, Environment.NewLine);
                //File.AppendAllText(path, "Stack Trace:" + Environment.NewLine);
                //File.AppendAllText(path, exception.StackTrace);
                //File.AppendAllText(path, Environment.NewLine + "*********************************************" + Environment.NewLine);
            }
            
        }

        private static bool IsKnown(Type type) //Gelen hatanın bilinip, bilinmediğinin kontrolünü yapar
        {
            var attributes = type.GetCustomAttributes(true); //Class'ın attribute bilgisini çekmek için
            string attributeString = "";
            foreach (var attribute in attributes)
            {
                attributeString += attribute.ToString();
            }

            if (attributeString.Contains("KnownException"))
            {
                return true;
            }
            return false;
        }
    }
}
