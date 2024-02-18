namespace WebBrowserWidget.Source.Public.Utils
{
    public class Diagnostics
    {
        public virtual bool IsDebug
        {
            get {
                bool isDebug = false;

                #if (DEBUG)
                isDebug = true;
                #else
                isDebug = false;
                #endif
                                
                return isDebug;
            }
        }

        public bool IsRelease
        {
            get { return !IsDebug; }
        }
    }
}
