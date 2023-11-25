using System.ServiceProcess;

namespace Veriket.Service
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if (DEBUG)
            VeriketService service = new VeriketService();
            service.onDebug();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new VeriketService()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}