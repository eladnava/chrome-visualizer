using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChromeVisualizer
{
    /// <summary>
    /// Interaction logic for Browser.xaml
    /// </summary>
    public partial class Browser : Window
    {
        /// <summary>
        /// Path to the HTML file to load into the browser
        /// </summary>
        string mHtmlFile;

        /// <summary>
        /// Window constructor
        /// </summary>
        public Browser()
        {
            // Load UI
            InitializeComponent();

            // Listen for CefSharp browser events
            WebBrowser.LoadingStateChanged += BrowserLoadingStateChanged;
            WebBrowser.IsBrowserInitializedChanged += BrowserInitialized;
        }

        /// <summary>
        /// Invoked when the browser starts or finishes loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BrowserLoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            // Done loading?
            if (! e.IsLoading)
            {
                // Find a better way to modify the UI than to invoke dispatcher
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                  {
                    // Find the loading fade out Storyboard
                    Storyboard fadeOut = (Storyboard)FindResource("FadeOutLoading");

                    // Fade out the loading image
                    fadeOut.Begin();
                }));
            }
        }

        /// <summary>
        /// Invoked when the browser has been loaded and is ready for injection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BrowserInitialized(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Load the HTML file from args
            LoadHTMLFile();
        }

        /// <summary>
        /// Extracts the HTML file from the process argument
        /// </summary>
        private void LoadHTMLFile()
        {
            // Get process arguments
            string[] args = Environment.GetCommandLineArgs();

            // Only executable path provided?
            if (args.Length == 1)
            {
                MessageBox.Show("Failed to extract HTML file path from arguments.");
                return;
            }

            // HTML file is passed as second argument
            mHtmlFile = args[1];

            // Invalid file path?
            if (!File.Exists(mHtmlFile))
            {
                // Report it to the user
                MessageBox.Show("The HTML file path is invalid.");
            }

            // Prepare page HTML
            string html;

            try
            {
                // Read it carefully from the temp file
                html = File.ReadAllText(mHtmlFile);
            }
            catch (Exception exc)
            {
                // Report it to the user
                MessageBox.Show("Failed to read from the HTML file:" + exc.Message);
                return;
            }

            // Load it into the CefSharp WebBrowser
            WebBrowserExtensions.LoadHtml(WebBrowser, html, "http://localhost");
        }

        /// <summary>
        /// Invoked when keys are pressed via the keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowPreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Escape?
            if (e.Key == Key.Escape)
            {
                // Close form
                Close();
            }

            // Ctrl + U?
            if ( e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.U)
            {
                // View source
                WebBrowser.ViewSource();
            }

            // F12?
            if (e.Key == Key.F12)
            {
                // Show dev tools
                WebBrowser.ShowDevTools();
            }
        }
    }
}
