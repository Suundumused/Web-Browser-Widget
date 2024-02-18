using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowserWidget.Source.Internal.BrowserClass;

namespace WebBrowserWidget.Source.Public.Utils
{
    public static class SpawnActor
    {
        public static void CreateInstance(dynamic? manager, string ? Deferral = null) 
        {
            Thread ThreadA = new Thread(() => NewThread(manager, Deferral));
            ThreadA.SetApartmentState(ApartmentState.STA);
            ThreadA.Start();
        }

        public static void NewThread(dynamic? masterObject = null, string? Deferral = null)
        {
            ApplicationConfiguration.Initialize();
            Browser.init(masterObject, Deferral);
        }
    }
}
