using IeuanWalker.Maui.Switch.Interfaces;

namespace IeuanWalker.Maui.Switch;

public class SwitchView : ContentView, ISwitchView
{
	public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(CustomSwitch), false, BindingMode.TwoWay);

	public bool IsToggled
	{
		get => (bool)GetValue(IsToggledProperty);
		set => SetValue(IsToggledProperty, value);
	}
}