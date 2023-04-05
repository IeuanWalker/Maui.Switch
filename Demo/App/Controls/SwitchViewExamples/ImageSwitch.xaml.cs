using IeuanWalker.Maui.Switch;

namespace App.Controls.SwitchViewExamples;

public partial class ImageSwitch : SwitchView
{
	public ImageSwitch()
	{
		InitializeComponent();
	}

	void SwitchImage_Loaded(object sender, EventArgs e)
	{
		StyleSwitch();
	}

	void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		IsToggled = !IsToggled;
		InvokeToggled();
		StyleSwitch();
	}

	void StyleSwitch()
	{
		SwitchImage.Source = ImageSource.FromFile(IsToggled ? "sun_icon" : "moon_icon");
	}
}