using App.Pages;

namespace App;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	async void CustomSwitchBtn_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CustomSwitchPage());
	}

	async void SwitchViewBtn_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new SwitchViewPage());
	}

	async void AccessibilityBtn_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AccessiblityTestPage());
	}

	async void IsEnabledBtn_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new IsEnabledTestPage());
	}

	async void PanGestureBtn_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new PanGestureTestPage());
	}
}