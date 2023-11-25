using System;
using System.IO;

namespace Veriket.Service
{
    public class Log
    {
        public static void writeEventLog(String Message)
        {
            StreamWriter sw = null;
            string path = "LogFolder";
            try
            {
                string Date = System.DateTime.Now.ToString("dd-MM-yyyy");
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path, $"ServiceLog {Date}.txt");

                string directoryPath = Path.GetDirectoryName(fullPath);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(DateTime.Now.ToString() + ": " + Message);
                    sw.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                throw;
            }

        }
    }
}
