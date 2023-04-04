using System.Windows.Input;
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

	public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(CustomSwitch));
	public ICommand ToggledCommand
	{
		get => (ICommand)GetValue(ToggledCommandProperty);
		set => SetValue(ToggledCommandProperty, value);
	}

	public event EventHandler<ToggledEventArgs>? Toggled;

	/// <summary>
	/// Invokes and executes the Toggled event and command.
	/// </summary>
	protected virtual void InvokeToggled()
	{
		Toggled?.Invoke(this, new ToggledEventArgs(IsToggled));
		ToggledCommand?.Execute(IsToggled);
	}
}