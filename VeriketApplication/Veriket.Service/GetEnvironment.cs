using System.Linq;
using System.Management;


namespace Veriket.Service
{
    public class GetEnvironment
    {
        public static string UserName()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();
            string fullUserName = (string)collection.Cast<ManagementBaseObject>().First()["UserName"];
            string[] userParts = fullUserName.Split('\\');
            string userName = userParts.Length > 1 ? userParts[1] : fullUserName;
            return userName;
        }
        public static string MachineName() 
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();
            string computerName = (string)collection.Cast<ManagementBaseObject>().First()["Name"];
            return computerName;
        }
    }
}
