using App.ViewModels;

namespace App;

public partial class MainPage : ContentPage
{
	readonly MainViewModel _viewModel;
	public MainPage()
	{
		InitializeComponent();

		BindingContext = _viewModel = new MainViewModel();
	}

	async void Switch_OnToggled(object sender, ToggledEventArgs e)
	{
		if (_viewModel.EnableEvents)
		{
			await Application.Current!.MainPage!.DisplayAlert("Switch toggled (Event)", $"New value: {e.Value}",  "OK").ConfigureAwait(false);
		}
	}
}