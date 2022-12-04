using System.Windows.Input;
using CustomSwitch.Helpers;

namespace App.Examples;

public partial class IosSwitch : ContentView
{
	public IosSwitch()
	{
		InitializeComponent();
	}

	public event EventHandler<ToggledEventArgs>? Toggled = null;
	public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(IosSwitch), false, BindingMode.TwoWay);
	public bool IsToggled
	{
		get => (bool)GetValue(IsToggledProperty);
		set => SetValue(IsToggledProperty, value);
	}

	public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(IosSwitch));
	public ICommand ToggledCommand
	{
		get => (ICommand)GetValue(ToggledCommandProperty);
		set => SetValue(ToggledCommandProperty, value);
	}

	void CustomSwitch_SwitchPanUpdate(object sender, CustomSwitch.Events.SwitchPanUpdatedEventArgs e)
	{
		//Color Animation
		Color fromColor = e.IsToggled ? Color.FromArgb("#4ACC64") : Color.FromArgb("#EBECEC");
		Color toColor = e.IsToggled ? Color.FromArgb("#EBECEC") : Color.FromArgb("#4ACC64");

		double t = e.Percentage * 0.01;

		CustomSwitch.CustomSwitch customSwitch = (CustomSwitch.CustomSwitch)sender;
		customSwitch.BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
	}
	void CustomSwitch_Toggled(object sender, ToggledEventArgs e)
	{
		Toggled?.Invoke(sender, e);
	}
}