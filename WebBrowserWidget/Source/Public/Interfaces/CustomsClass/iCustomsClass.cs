using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowserWidget.Source.Public.Interfaces.CustomsClass
{
    public interface iCustomsClass
    {
        public static abstract string Customize(BrowserUI ?instance = null, string ?myDeferral = null, dynamic? local_configs = null);
    }
}
