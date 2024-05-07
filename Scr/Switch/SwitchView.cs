using System.Diagnostics;
using System.Windows.Input;
using IeuanWalker.Maui.Switch.Interfaces;

namespace IeuanWalker.Maui.Switch;

public class SwitchView : ContentView, ISwitchView
{
	public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(SwitchView), false, BindingMode.TwoWay);

	public bool IsToggled
	{
		get => (bool)GetValue(IsToggledProperty);
		set => SetValue(IsToggledProperty, value);
	}

	public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(SwitchView));

	public ICommand ToggledCommand
	{
		get => (ICommand)GetValue(ToggledCommandProperty);
		set => SetValue(ToggledCommandProperty, value);
	}

	public event EventHandler<ToggledEventArgs>? Toggled;

	public SwitchView()
	{
		PropertyChanged += (sender, args) =>
		{
			if (args.PropertyName?.Equals(nameof(IsToggled)) ?? false)
			{
				IsToggledChanged();
			}
		};
	}

	/// <summary>
	/// Invokes and executes the Toggled event and command.
	/// </summary>
	protected virtual void InvokeToggled()
	{
		if (!IsEnabled)
		{
			return;
		}

		Toggled?.Invoke(this, new ToggledEventArgs(IsToggled));
		ToggledCommand?.Execute(IsToggled);
	}

	protected virtual void IsToggledChanged()
	{
		if (!IsEnabled)
		{
			return;
		}
		
		Debug.WriteLine($"{nameof(IsToggled)} changed from {!IsToggled} to {IsToggled}");
	}
}