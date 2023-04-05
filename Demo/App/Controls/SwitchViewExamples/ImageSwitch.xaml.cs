using IeuanWalker.Maui.Switch;

namespace App.Controls.SwitchViewExamples;

public partial class ImageSwitch : SwitchView
{
	public ImageSwitch()
	{
		InitializeComponent();

		Loaded += (sender, args) => StyleSwitch();
	}
	void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		IsToggled = !IsToggled;
	}

	protected override void IsToggledChanged()
	{
		StyleSwitch();
		InvokeToggled();
	}

	void StyleSwitch()
	{
		SwitchImage.Source = ImageSource.FromFile(IsToggled ? "sun_icon" : "moon_icon");
	}
}