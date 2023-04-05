| :memo:        | This is a MAUI version of my [Xamarin NuGet](https://github.com/IeuanWalker?tab=repositories&q=switch&type=&language=&sort=)      |
|---------------|:------------------------|

# Maui.CustomSwitch [![Nuget](https://img.shields.io/nuget/v/IeuanWalker.Maui.Switch)](https://www.nuget.org/packages/IeuanWalker.Maui.Switch) [![Nuget](https://img.shields.io/nuget/dt/IeuanWalker.Maui.Switch)](https://www.nuget.org/packages/IeuanWalker.Maui.Switch) 

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Build](https://github.com/IeuanWalker/Maui.Switch/actions/workflows/build.yml/badge.svg)](https://github.com/IeuanWalker/Maui.Switch/actions/workflows/build.yml)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FIeuanWalker%2FMaui.Switch.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FIeuanWalker%2FMaui.Switch?ref=badge_shield)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/e27a4d0f0b92409283583e65ffc7e10b)](https://app.codacy.com/gh/IeuanWalker/Maui.Switch/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)

This is a switch/ toggle control that would allow you to create any style switch you'd like. <br>
This component is built on top/ from this great libary - https://github.com/Phenek/Global.InputForms. Fixes a few issues, adds more options for styling and improved accessibility.

Take a look at the sample app included within this project

## 1. How to use it?
Install the [NuGet package](https://www.nuget.org/packages/IeuanWalker.Maui.Switch) into your shared project project
```
Install-Package IeuanWalker.Maui.Switch
```

Then in the `MauiProgram.cs` file, and the using statement - 
```csharp
using IeuanWalker.Maui.Switch;
```
And call `.UseSwitch()` on `MauiAppBuilder` - 
```csharp
var builder = MauiApp.CreateBuilder();
builder
    .UseMauiApp<App>()
    .UseSwitch()
```



## 2. Choose a control
This control contains 2 seperate controls, `CustomSwitch` and `SwitchView`.

Essentially `CustomSwitch` allows you to design the induvidual parts of the switch, and the control handles all the logic for animating and changing the switch between the true/ false states

`SwitchView` gives you a blank canves to design any type of switch you want. It gives you the standard properties of a switch and makes it completely accessible.

Check the wiki guide for how to use them, and to view the examples - 
- [CustomSwitch](https://github.com/IeuanWalker/Maui.Switch/wiki/CustomSwitch)
- [SwitchView](https://github.com/IeuanWalker/Maui.Switch/wiki/SwitchView)

## 3. Accessibility
Both iOS and android see's this control as a native switch. So from an accessibility POV it behaves like a native switch.

To make the switch even for accessible set the [`SemanticProperties.Hint`](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/accessibility?view=net-maui-7.0#hint) property on the control



## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FIeuanWalker%2FMaui.Switch.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2FIeuanWalker%2FMaui.Switch?ref=badge_large)
