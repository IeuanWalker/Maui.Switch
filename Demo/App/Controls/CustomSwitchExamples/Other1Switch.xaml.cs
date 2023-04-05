using System.Windows.Input;
using IeuanWalker.Maui.Switch;
using IeuanWalker.Maui.Switch.Events;
using IeuanWalker.Maui.Switch.Helpers;
using Microsoft.Maui.Controls.Shapes;

namespace App.Controls.CustomSwitchExamples;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Other1Switch : ContentView
{
	public Other1Switch()
	{
		InitializeComponent();
	}

	public event EventHandler<ToggledEventArgs>? Toggled = null;

	public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(Other1Switch), false, BindingMode.TwoWay);

	public bool IsToggled
	{
		get => (bool)GetValue(IsToggledProperty);
		set => SetValue(IsToggledProperty, value);
	}

	public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(Other1Switch));

	public ICommand ToggledCommand
	{
		get => (ICommand)GetValue(ToggledCommandProperty);
		set => SetValue(ToggledCommandProperty, value);
	}

	void CustomSwitch_SwitchPanUpdate(CustomSwitch customSwitch, SwitchPanUpdatedEventArgs e)
	{
		KnobContent.TranslationX = -(e.TranslateX + e.XRef);

		Color fromColorLight = e.IsToggled ? Color.FromArgb("#cdf4cc") : Color.FromArgb("#f7cccc");
		Color toColorLight = e.IsToggled ? Color.FromArgb("#f7cccc") : Color.FromArgb("#cdf4cc");

		Color fromColorDark = e.IsToggled ? Color.FromArgb("#46d744") : Color.FromArgb("#dd2424");
		Color toColorDark = e.IsToggled ? Color.FromArgb("#dd2424") : Color.FromArgb("#46d744");

		double t = e.Percentage * 0.01;

		double zeroToFive = Calculate(0, 5, t);
		double fiveToZero = Calculate(5, 0, t);

		customSwitch.KnobStrokeShape = new RoundRectangle
		{
			CornerRadius = e.IsToggled ?
				new CornerRadius(zeroToFive, fiveToZero, zeroToFive, fiveToZero) :
				new CornerRadius(fiveToZero, zeroToFive, fiveToZero, zeroToFive)
		};
		customSwitch.KnobBackgroundColor = ColorAnimationUtil.ColorAnimation(fromColorLight, toColorLight, t);
		customSwitch.KnobStroke = ColorAnimationUtil.ColorAnimation(fromColorDark, toColorDark, t);
	}

	void CustomSwitch_Toggled(object sender, ToggledEventArgs e)
	{
		Toggled?.Invoke(sender, e);
	}

	public static double Calculate(double from, double to, double percentage)
	{
		return from + ((to - from) * percentage);
	}
}