# Chrome Visualizer for Visual Studio
A custom Visual Studio debug visualizer that displays HTML strings in Chrome.

![Preview](https://raw.github.com/eladnava/chrome-visualizer/master/ChromeVisualizerIntegration/Resources/Screenshot.png)

# Features
* Extremely fast (utilizes [CefSharp](https://github.com/cefsharp/CefSharp))
* Responsive, unlike the built-in HTML Visualizer

# Hotkeys
* **Ctrl + U** for View Source
* **F12** for Chrome Developer Tools

# Installation
* Currently, simply building the solution will copy the necessary files to **Visual Studio 2012**'s installation directory:
C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\Packages\Debugger\Visualizers
* An installer will be added to the repository in the future to ease the install process, and to support other Visual Studio versions.

# Roadmap
* XPath tester - an input text field that can help debug XPaths by highlighting matched elements
