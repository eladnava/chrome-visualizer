using ChromeVisualizerVSIntegration;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

// Visualizer metadata
[assembly: DebuggerVisualizer(typeof(DebuggerIntegration), typeof(VisualizerObjectSource), Target = typeof(String), Description = "Chrome Visualizer")]

namespace ChromeVisualizerVSIntegration
{
    public class DebuggerIntegration : DialogDebuggerVisualizer
    {
        /// <summary>
        /// The ChromeVisualizer.exe executable path
        /// </summary>
        private static readonly string chromeVisualizerPath = @"C:\Program Files\ChromeVisualizer\ChromeVisualizer.exe";

        /// <summary>
        /// Contains the code that actually creates the ChromeVisualizer (by starting its process)
        /// </summary>
        /// <param name="windowService"></param>
        /// <param name="objectProvider"></param>
        override protected void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            // Get the HTML we want to visualize
            string html = objectProvider.GetObject().ToString();

            // Get temp file path
            string htmlFilePath = Path.GetTempFileName() + ".html";

            try
            {
                // Try to write it out
                File.WriteAllText(htmlFilePath, html, Encoding.UTF8);
            }
            catch (Exception exc)
            {
                // Report it to the user
                MessageBox.Show("Failed to save HTML to a temporary text file: " + exc.Message);
                return;
            }

            // Create a new process to launch our chrome visualizer
            Process process = new Process();

            // Link to the ChromeVisualizer.exe file
            process.StartInfo.FileName = chromeVisualizerPath;

            // Pass the HTML temp file path as argument
            process.StartInfo.Arguments = htmlFilePath;

            // Maximize the window
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;

            try
            {
                // Finally, start the process!
                process.Start();
            }
            catch (Exception exc)
            {
                // Report it to the user
                MessageBox.Show("Failed to start the Chrome Visualizer executable: " + exc.Message);
                return;
            }

            // Wait for user to close window
            process.WaitForExit();

            try
            {
                // Finally, try to delete the temp file
                File.Delete(htmlFilePath);
            }
            catch (Exception exc)
            {
                // Report it to the user
                MessageBox.Show("Failed to delete the temporary HTML file: " + exc.Message);
                return;
            }
        }

        /// <summary>
        /// Provides a way to test the debugger visualizer.
        /// </summary>
        /// <param name="objectToVisualize"></param>
        public static void TestVisualizer(object objectToVisualize)
        {
            // Obtain a visualizer development host with this class as the target visualizer
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(DebuggerIntegration));

            // Run it
            visualizerHost.ShowVisualizer();
        }
    }
}
