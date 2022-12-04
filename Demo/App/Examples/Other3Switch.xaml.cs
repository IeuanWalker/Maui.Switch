using System.Windows.Input;
using CustomSwitch.Helpers;

namespace App.Examples;

public partial class Other3Switch : ContentView
{
	public Other3Switch()
	{
		InitializeComponent();
	}

	public event EventHandler<ToggledEventArgs>? Toggled = null;
	public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(Other3Switch), false, BindingMode.TwoWay);
	public bool IsToggled
	{
		get => (bool)GetValue(IsToggledProperty);
		set => SetValue(IsToggledProperty, value);
	}

	public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(Other3Switch));
	public ICommand ToggledCommand
	{
		get => (ICommand)GetValue(ToggledCommandProperty);
		set => SetValue(ToggledCommandProperty, value);
	}
	
	void CustomSwitch_SwitchPanUpdate(object sender, CustomSwitch.Events.SwitchPanUpdatedEventArgs e)
	{
		//Color Animation
		Color fromColor = e.IsToggled ? Color.FromArgb("#33b68d") : Color.FromArgb("#e7640f");
		Color toColor = e.IsToggled ? Color.FromArgb("#e7640f") : Color.FromArgb("#33b68d");

		double t = e.Percentage * 0.01;

		CustomSwitch.CustomSwitch customSwitch = (CustomSwitch.CustomSwitch)sender;
		customSwitch.BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
	}

	void CustomSwitch_Toggled(object sender, ToggledEventArgs e)
	{
		Toggled?.Invoke(sender, e);
	}
}