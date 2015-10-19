<h1><img src="https://raw.github.com/eladnava/chrome-visualizer/master/ChromeVisualizer/Resources/App.png" align="right" height="40">Chrome Visualizer for Visual Studio</h1>

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/eladnava/chrome-visualizer?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

A custom Visual Studio debug visualizer that displays HTML strings in Chrome.

![Preview](https://raw.github.com/eladnava/chrome-visualizer/master/ChromeVisualizerIntegration/Resources/Screenshot.png)

# Features

* Extremely fast (utilizes [CefSharp](https://github.com/cefsharp/CefSharp))
* Responsive, unlike the built-in HTML Visualizer
* Built-in Chrome Developer Tools (F12)

# Hotkeys

* **Ctrl + U** for View Source
* **F12** for Chrome Developer Tools

# Installation

* Clone the repository and head over to the **Installation/** directory, where you'll find a `README.txt` with detailed instructions.

# Roadmap

* **XPath Tester** - an input text field that can help debug XPaths by highlighting matched elements
* Got any ideas? Create an issue and let us know!

# Architecture

* **ChromeVisualizer** - a WPF application that contains a Window with a `CefSharp.Wpf.ChromiumWebBrowser`
* **ChromeVisualizerIntegration** - a library project that adds the Chrome Visualizer option for strings in Visual Studio's debugging context menu
* **ChromeVisualizerDemo** - a console application that simulates clicking the Chrome Visualizer in the debugger context menu

# Collaborating

* If you find a bug or wish to make some kind of change, please create an issue first
* Make your commits as tiny as possible - one feature or bugfix at a time
* Write detailed commit messages, in-line with the project's commit naming conventions
* Make sure your code conventions are in-line with the project

# License

Apache 2.0
