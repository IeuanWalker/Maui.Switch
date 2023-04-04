using System.Windows.Input;
using IeuanWalker.Maui.Switch;
using IeuanWalker.Maui.Switch.Events;
using IeuanWalker.Maui.Switch.Helpers;

namespace App.Controls.CustomSwitchExamples;

public partial class AndroidSwitch : ContentView
{
	public AndroidSwitch()
	{
		InitializeComponent();
	}

	public event EventHandler<ToggledEventArgs>? Toggled = null;

	public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(AndroidSwitch), false, BindingMode.TwoWay);

	public bool IsToggled
	{
		get => (bool)GetValue(IsToggledProperty);
		set => SetValue(IsToggledProperty, value);
	}

	public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(AndroidSwitch));

	public ICommand ToggledCommand
	{
		get => (ICommand)GetValue(ToggledCommandProperty);
		set => SetValue(ToggledCommandProperty, value);
	}

	void CustomSwitch_Toggled(object sender, ToggledEventArgs e)
	{
		Toggled?.Invoke(sender, e);
	}

	static void CustomSwitch_SwitchPanUpdate(CustomSwitch customSwitch, SwitchPanUpdatedEventArgs e)
	{
		//Switch Color Animation
		Color fromSwitchColor = e.IsToggled ? Color.FromArgb("#6200ee") : Color.FromArgb("#fafafa");
		Color toSwitchColor = e.IsToggled ? Color.FromArgb("#fafafa") : Color.FromArgb("#6200ee");

		//BackGroundColor Animation
		Color fromColor = e.IsToggled ? Color.FromArgb("#a472ea") : Color.FromArgb("#9b9b9b");
		Color toColor = e.IsToggled ? Color.FromArgb("#9b9b9b") : Color.FromArgb("#a472ea");

		double t = e.Percentage * 0.01;

		customSwitch.KnobColor = ColorAnimationUtil.ColorAnimation(fromSwitchColor, toSwitchColor, t);
		customSwitch.BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
	}
}