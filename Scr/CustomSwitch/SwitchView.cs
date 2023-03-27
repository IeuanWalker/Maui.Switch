namespace CustomSwitch.Handler;

[ContentProperty("Content")]
public class SwitchView : TemplatedView
{
	public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(CustomSwitch), false, BindingMode.TwoWay);

	public bool IsToggled
	{
		get => (bool)GetValue(IsToggledProperty);
		set => SetValue(IsToggledProperty, value);
	}

	public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(ContentView), null);

	public View Content
	{
		get { return (View)GetValue(ContentProperty); }
		set { SetValue(ContentProperty, value); }
	}
}
