using System.Windows.Input;
using IeuanWalker.Maui.Switch;
using IeuanWalker.Maui.Switch.Events;
using IeuanWalker.Maui.Switch.Helpers;

namespace App.Controls.CustomSwitchExamples;

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

	public static readonly BindableProperty AccessibilityHintProperty = BindableProperty.Create(nameof(AccessibilityHint), typeof(string), typeof(IosSwitch), string.Empty);

	public string AccessibilityHint
	{
		get => (string)GetValue(AccessibilityHintProperty);
		set => SetValue(AccessibilityHintProperty, value);
	}

	public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(CustomSwitch), false);
	public bool IsBusy
	{
		get => (bool)GetValue(IsBusyProperty);
		set => SetValue(IsBusyProperty, value);
	}

	public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(IosSwitch));

	public ICommand ToggledCommand
	{
		get => (ICommand)GetValue(ToggledCommandProperty);
		set => SetValue(ToggledCommandProperty, value);
	}

	static void CustomSwitch_SwitchPanUpdate(CustomSwitch customSwitch, SwitchPanUpdatedEventArgs e)
	{
		//Color Animation
		Color fromColor = e.IsToggled ? Color.FromArgb("#4ACC64") : Color.FromArgb("#EBECEC");
		Color toColor = e.IsToggled ? Color.FromArgb("#EBECEC") : Color.FromArgb("#4ACC64");

		double t = e.Percentage * 0.01;

		customSwitch.BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
	}

	void CustomSwitch_Toggled(object sender, ToggledEventArgs e)
	{
		Toggled?.Invoke(sender, e);
	}
}