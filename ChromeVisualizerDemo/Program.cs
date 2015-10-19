using ChromeVisualizerVSIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChromeVisualizerDemo
{
    class Program
    {
        /// <summary>
        /// A URL to a web page that returns HTML to inject into the chrome visualizer
        /// Preferably, a URL that also freezes the built-in HTML Visualizer
        /// </summary>
        private static readonly string TEST_URL = "http://github.com";

        /// <summary>
        /// The application's main entry point
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
            // Get a disposable WebClient
            using (WebClient webClient = new WebClient())
            {
                // Set client encoding to support UTF8 pages
                webClient.Encoding = Encoding.UTF8;

                // Download HTML from the TEST_URL web page
                string html = webClient.DownloadString(TEST_URL);

                // Inject it into the chrome visualizer
                DebuggerIntegration.TestVisualizer(html);
            }
        }
    }
}
