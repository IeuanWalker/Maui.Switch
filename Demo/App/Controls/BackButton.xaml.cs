namespace App.Controls;

public partial class BackButton : ContentView
{
	public BackButton()
	{
		InitializeComponent();
	}

	async void StateButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}