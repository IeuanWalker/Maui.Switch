using IeuanWalker.Maui.Switch;
using IeuanWalker.Maui.Switch.Events;
using IeuanWalker.Maui.Switch.Helpers;

namespace App.Pages;

public partial class PanGestureTestPage : ContentPage
{
	public PanGestureTestPage()
	{
		InitializeComponent();

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

		customSwitch.KnobBackgroundColor = ColorAnimationUtil.ColorAnimation(fromSwitchColor, toSwitchColor, t);
		customSwitch.BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
	}

	async void Switch_OnToggled(object sender, ToggledEventArgs e)
	{
		await Application.Current!.MainPage!.DisplayAlert("Switch toggled (Event)", $"New value: {e.Value}", "OK").ConfigureAwait(false);
	}
}