using System.Diagnostics;
using WebBrowserWidget.Source.Internal.BrowserClass;

namespace WebBrowserWidget
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            Thread ThreadA = new Thread(() => NewThread());
            ThreadA.SetApartmentState(ApartmentState.STA);
            ThreadA.Start();

            /*Thread ThreadB = new Thread(() => NewThread());
            ThreadB.SetApartmentState(ApartmentState.STA);
            ThreadB.Start();*/
        }

        public static void NewThread() 
        {
            ApplicationConfiguration.Initialize();
            Browser.init();
        }
    }
}