namespace Veriket.Winform
{
    internal static class Program
    {
        internal static class ApplicationConfiguration
        {
            public static void Initialize()
            {
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new VeriketLogList());
        }
    }
}