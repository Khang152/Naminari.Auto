 [nuget-url]: https://www.nuget.org/packages/Naminari.Auto
 [source-url]: https://github.com/Khang152/Naminari.Auto
 [logo-url]: https://raw.githubusercontent.com/Khang152/Naminari.Auto/develop/Naminari.Auto/Naminari.Auto/Images/icon.png
 [sampleApp-url]: https://raw.githubusercontent.com/Khang152/Naminari.Auto/develop/Naminari.Auto/Naminari.Auto.SampleApp/Images/SampleApp.png

![logo][logo-url]
# Naminari.Auto

Naminari.Auto is a library designed to simplify task automation by providing users with the ability to control their mouse and keyboard inputs. With Naminari.Auto, you can easily create scripts that simulate user input without the need for manual input.

## Prerequisites
 - **Windows:** .NET 7

## Installation and sources
[![nuget][nuget-badge]][nuget-url]

[nuget-badge]: https://img.shields.io/badge/nuget-v1.0.0-blue.svg
```
  NuGet\Install-Package Naminari.Auto
```

 - [NuGet package][nuget-url]
 - [Source code][source-url]

# Usage

### Import package
```csharp
using AutoClicker.Actions;
```

## Support for mouse input:
### Get the Mouse Position
```csharp
var position = Mouse.GetPosition();
```

### Get the pixel color at the mouse position
```csharp
var color = Mouse.GetPosition().GetPixelColor();
```

## Support for keyboard input:
### Obtain the process list by clicking
```csharp
// Declare
Keyboard keyboard = new Keyboard();

// Only keep lastest process
keyboard.IsKeepLatestProcess = true;

// Click to any proccess windows and get list
keyboard.Processes
```

### Send raw text input to the selected process
```csharp
Task.Run(async () =>
{
    await Naminari.Auto.Keyboard.TypingAsync("Hello World!!!", "notepad++");
});
```

### Send command key input to the process
```csharp
// To select all text in Notepad++, hold down the Ctrl key and press the A key.
Task.Run(async () =>
{
    await Auto.Keyboard.CommandAsync("Ctrl+A", "notepad++");
});

// To open Test Explorer in Visual Studio 2022, hold down the Ctrl key and press the A key, then release both keys and press the T key
Task.Run(async () =>
{
    await Auto.Keyboard.CommandAsync("Ctrl+E,T", "devenv");
});
```

## Support for image:
### Capture a screenshot in Windows
```csharp
Naminari.Auto.Utils.GetScreenShot()
```

### Obtain an image from a selected area
```csharp
Rectangle area = new Rectangle
                (Math.Min(startPoint.X, e.Location.X),
                Math.Min(startPoint.Y, e.Location.Y),
                Math.Abs(startPoint.X - e.Location.X),
                Math.Abs(startPoint.Y - e.Location.Y));

Bitmap bmp = Naminari.Auto.Utils.GetImageFromSelect(area);
pictureBox.Image = bmp;
```

### Locate the position of a small image within a larger image
```csharp
var bigImage = new Bitmap(bigSource);
var smallImage = new Bitmap(smallSource);
var position = Utils.FindImagePosition(smallImage, bigImage);
```

### The Sample App

![Naminari.Auto.SampleApp][sampleApp-url]

> Take a look at the sample app that is included with the source code

# Contributing Guide
 
We welcome contributions to our project! 
Before getting started, please take a moment to read through the following guidelines:

 ## Reporting Bugs
 If you have found a bug in our project, please open an issue on GitHub. When reporting a bug, please include as much detail as possible about the issue and steps to reproduce it.
 
 ## Submitting Changes
 1. Clone "contributors" branch.
 2. Add some nice features.
 3. Create a Pull Request to "develop" branch.

# License
By contributing to our project, you agree that your contributions will be licensed under the [LICENSE.txt](/LICENSE.txt)
