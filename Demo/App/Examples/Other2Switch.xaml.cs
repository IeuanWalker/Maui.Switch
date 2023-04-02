using System.Windows.Input;
using IeuanWalker.Maui.Switch;
using IeuanWalker.Maui.Switch.Events;
using IeuanWalker.Maui.Switch.Helpers;

namespace App.Examples;

public partial class Other2Switch : ContentView
{
	public Other2Switch()
	{
		InitializeComponent();
	}

	public event EventHandler<ToggledEventArgs>? Toggled = null;

	public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(Other2Switch), false, BindingMode.TwoWay);

	public bool IsToggled
	{
		get => (bool)GetValue(IsToggledProperty);
		set => SetValue(IsToggledProperty, value);
	}

	public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(Other2Switch));

	public ICommand ToggledCommand
	{
		get => (ICommand)GetValue(ToggledCommandProperty);
		set => SetValue(ToggledCommandProperty, value);
	}

	static void CustomSwitch_SwitchPanUpdate(CustomSwitch customSwitch, SwitchPanUpdatedEventArgs e)
	{
		Color fromColorGradient1 = e.IsToggled ? Color.FromArgb("#a8ff78") : Color.FromArgb("#FF512F");
		Color toColorGradient1 = e.IsToggled ? Color.FromArgb("#FF512F") : Color.FromArgb("#a8ff78");

		Color fromColorGradient2 = e.IsToggled ? Color.FromArgb("#78ffd6") : Color.FromArgb("#DD2476");
		Color toColorGradient2 = e.IsToggled ? Color.FromArgb("#DD2476") : Color.FromArgb("#78ffd6");

		double t = e.Percentage * 0.01;

		customSwitch.KnobBackground = new LinearGradientBrush(new GradientStopCollection
		{
			new GradientStop
			{
				Color =  ColorAnimationUtil.ColorAnimation(fromColorGradient1, toColorGradient1, t),
				Offset = 0
			},
			new GradientStop
			{
				Color = ColorAnimationUtil.ColorAnimation(fromColorGradient2, toColorGradient2, t),
				Offset = 1
			}
		}, new Point(0.6, 1), new Point(1, 0));
	}

	void CustomSwitch_Toggled(object sender, ToggledEventArgs e)
	{
		Toggled?.Invoke(sender, e);
	}
}