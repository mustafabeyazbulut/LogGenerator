using System;
using System.IO;

namespace Veriket.Service
{
    public static class VeriketLog
    {
        public static void writeEventLog(DateTime dateNow,string computerName,string userName)
        {
            StreamWriter sw = null;
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "VeriketApp");
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filePath = Path.Combine(path, "VeriketAppTest.txt");
                if (!File.Exists(filePath))
                {
                    using (StreamWriter headerWriter = new StreamWriter(filePath))
                    {
                        headerWriter.WriteLine("Tarih,Bilgisayar Adı,Windowsta Oturum Açan Kullanıcı Adı");
                    }
                }
                sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{dateNow},{computerName},{userName}");
                sw.Flush();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sw?.Close();
            }
        }
    }
}
