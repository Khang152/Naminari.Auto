# Naminari.Auto
Naminari.Auto is a library designed to simplify task automation by providing users with the ability to control their mouse and keyboard inputs. With Naminari.Auto, you can easily create scripts that simulate user input without the need for manual input. 

## Prerequisites
 - **Windows:** .NET 7

# Usage

### Import package
```csharp
using Naminari.Auto.SampleApp.Models;
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
