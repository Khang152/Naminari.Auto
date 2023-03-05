 [nuget-url]: https://www.nuget.org/packages/Naminari.Auto
 [source-url]: https://github.com/Khang152/Naminari.Auto
 [logo-url]: https://github.com/Khang152/Naminari.Auto/blob/develop/Naminari.Auto/Naminari.Auto/Images/icon.png
 [sampleApp-url]: https://github.com/Khang152/Naminari.Auto/blob/develop/Naminari.Auto/Naminari.Auto.SampleApp/Images/SampleApp.png

![logo][logo-url]
# Naminari.Auto

Naminari.Auto is a library designed to simplify task automation by providing users with the ability to control their mouse and keyboard inputs. With Naminari.Auto, you can easily create scripts that simulate user input without the need for manual input.

## Prerequisites
 - **Windows:** .NET 7

## Installation and sources
[![nuget][nuget-badge]][nuget-url]

[nuget-badge]: https://img.shields.io/badge/nuget-v1.0.0-blue.svg
```
  nuget install Naminari.Auto
```

 - [NuGet package][nuget-url]
 - [Source code][source-url]

# Usage

### Import package
```csharp
using AutoClicker.Actions;
```
 
### Get the Mouse Position
```csharp
var position = Mouse.GetPosition();
```

### Get the pixel color at the mouse position
```csharp
var color = Mouse.GetPosition().GetPixelColor();
```
(Also, take a look at the sample app that is included with the source code)

![Naminari.Auto.SampleApp][sampleApp-url]

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
