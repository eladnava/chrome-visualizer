using CefSharp;
using System.Windows;

namespace ChromeVisualizer
{
    public partial class App : Application
    {
        /// <summary>
        /// The application's main entry point
        /// </summary>
        public App()
        {
            // Initialize CefSharp browser
            Cef.Initialize(new CefSettings());
        }
    }
}
