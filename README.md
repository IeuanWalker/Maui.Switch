| :memo:        | This is a MAUI version of my [Xamarin NuGet](https://github.com/IeuanWalker?tab=repositories&q=switch&type=&language=&sort=)      |
|---------------|:------------------------|

| :warning:        | The control works from a visual and functionality POV. But it is not currently accessible. </br> Once the control is accessible version 1.0.0 will be released. </br> If accessibility isnt a requirement for you, feel free to use the preview NuGet.  |
|---------------|:------------------------|


# Maui.CustomSwitch [![Nuget](https://img.shields.io/nuget/v/IeuanWalker.Maui.Switch)](https://www.nuget.org/packages/IeuanWalker.Maui.Switch) [![Nuget](https://img.shields.io/nuget/dt/IeuanWalker.Maui.Switch)](https://www.nuget.org/packages/IeuanWalker.Maui.Switch) 

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FIeuanWalker%2FMaui.Switch.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FIeuanWalker%2FMaui.Switch?ref=badge_shield)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/e27a4d0f0b92409283583e65ffc7e10b)](https://app.codacy.com/gh/IeuanWalker/Maui.Switch/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)

This is a switch/ toggle control that would allow you to create any style switch you'd like. <br>
This component is built on top/ from this great libary - https://github.com/Phenek/Global.InputForms. Fixes a few issues, adds more options for styling and improved accessibility.

Take a look at the sample app included within this project -

## How to use it?
Install the [NuGet package](https://www.nuget.org/packages/IeuanWalker.Maui.Switch) into your shared project project
```
Install-Package IeuanWalker.Maui.Switch
```
____

The best place to learn how to create a new switch is by looking at the [samples](/Demo/App/Examples/).

These are the key things to know - 
- `BackgroundContent` is used to set the content of the switch
- `KnobContent` is used to set the content on the knob. The content on the knob is hidden/shown by utilising the `IsClippedToBounds` property.
So essentially, as the knob moves from one side to the other it is just revealing a different part of the content.
- The `SwitchPanUpdate` is used transition from true to false, i.e. color fading etc. 

## What can I do with it?
### Properties
| Property | What it does | Extra info |
|---|---|---- |
| IsToggled | A `bool` to indicate the togles status of the switch | Default value is **false** |
| KnobHeight | The height of the knob on the switch | Default value is **0** |
| KnobWidth | The width of the knob on the switch | Default value is **0** |
| KnobColor | The solid color of the knob | Default value is **Color.Default** |
| KnobBackground | The background for the knob, this supports XF brushes to enable gradients, lean more on [MS docs](https://devblogs.microsoft.com/xamarin/xamarinforms-4-8-gradients-brushes/) | Default value is **Brush.Default** |
| KnobCornerRadius | A `CornerRadius` object representing each individual corner's radius for the knob. <br> This is property is implemented using XF corner radius object  | More info on how to use this in the [MS docs](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.cornerradius?view=xamarin-forms) <br> Default value is **default(CornerRadius)** |
| HeightRequest | The Height of the switch  | Default value is **0** |
| WidthRequest | The width of the switch  | Default value is **0** |
| CornerRadius | A `CornerRadius` object representing each individual corner's radius for the knob. <br> This is property is implemented using XF corner radius object  | More info on how to use this in the [MS docs](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.cornerradius?view=xamarin-forms) <br> Default value is **default(CornerRadius)** |
| BackgroundColor | The solid color of the switch | Default value is **Color.Default** |
| Background | The background for the switch, this supports XF brushes to enable gradients, lean more on [MS docs](https://devblogs.microsoft.com/xamarin/xamarinforms-4-8-gradients-brushes/) | Default value is **Brush.Default** |
| BackgroundContent | Sets the content of the switch.  <br> See [samples](/Sample/Sample/Sample/Examples/) for an  idea how to utilise it  | Default value is **null** |
| KnobContent | Sets the content of the knob.  <br> See [samples](/Sample/Sample/Sample/Examples/) for an  idea how to utilise it | Default value is **null** |
| HorizontalKnobMargin | Adds a margin to the max distance the knob can travel | Default value is **0** |
| KnobLimit | Used to calculate the knob position.  <br> See [samples](/Sample/Sample/Sample/Examples/) for an  idea how to utilise it | Default value is **KnobLimitEnum.Boundary** |
| ToggleAnimationDuration | Used to set the duration of the toggle animation | Default value is **100** <br> To disble the animation set the value to `0` |

### Events
| Event | What it does 
|---|---|
| Toggled | Triggered when the switch is toggled |
| SwitchPanUpdate | Triggered when the switch is toggled or dragged. Used to handle the transition of the switch from one side to the other. <br> See [samples](/Demo/App/Examples/) for an  idea how to utilise it | 

### Commands
| Command | What it does 
|---|---|
| ToggledCommand | Triggered when the switch is toggled |

### Accessibility
Both iOS and android see's this control as a native switch. So from an accessibility POV it behaves like a native switch.

## Examples
### iOS ([xaml](/Demo/App/Examples/IosSwitch.xaml) / [code behind](/Demo/App/Examples/IosSwitch.xaml.cs))
![iOS example](Doc/iOS.gif)

### Android ([xaml](/Demo/App/Examples/AndroidSwitch.xaml) / [code behind](/Demo/App/Examples/AndroidSwitch.xaml.cs))
![iOS example](Doc/Android.gif)

### Theme 1 ([xaml](/Demo/App/Examples/Theme1Switch.xaml) / [code behind](/Demo/App/Examples/Theme1Switch.xaml.cs))
![Theme 1 example](Doc/Theme1.gif)

### Theme 2 ([xaml](/Demo/App/Examples/Theme2Switch.xaml) / [code behind](/Demo/App/Examples/Theme2Switch.xaml.cs))
![Theme 2 example](Doc/Theme2.gif)

### Other 1 ([xaml](/Demo/App/Examples/Other1Switch.xaml) / [code behind](/Demo/App/Examples/Other1Switch.xaml.cs))
![Other 1 example](Doc/Other1.gif)

### Other 2 ([xaml](/Demo/App/Examples/Other2Switch.xaml) / [code behind](/Demo/App/Examples/Other2Switch.xaml.cs))
![Other 2 example](Doc/Other2.gif)

### Other 3 ([xaml](/Demo/App/Examples/Other3Switch.xaml) / [code behind](/Demo/App/Examples/Other3Switch.xaml.cs))
![Other 3 example](Doc/Other3.gif)

### Other 4 ([xaml](/Demo/App/Examples/Other4Switch.xaml) / [code behind](/Demo/App/Examples/Other4Switch.xaml.cs))
![Other 4 example](Doc/Other4.gif)

### Other 5 ([xaml](/Demo/App/Examples/Other5Switch.xaml) / [code behind](/Demo/App/Examples/Other5Switch.xaml.cs))
![Other 5 example](Doc/Other5.gif)

## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FIeuanWalker%2FMaui.Switch.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2FIeuanWalker%2FMaui.Switch?ref=badge_large)
