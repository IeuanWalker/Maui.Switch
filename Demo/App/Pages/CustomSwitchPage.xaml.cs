using App.ViewModels;

namespace App.Pages;

public partial class CustomSwitchPage : ContentPage
{
	readonly SwitchViewModel _viewModel;

	public CustomSwitchPage()
	{
		InitializeComponent();

		BindingContext = _viewModel = new SwitchViewModel();
	}

	async void Switch_OnToggled(object sender, ToggledEventArgs e)
	{
		if (_viewModel.EnableEvents)
		{
			await Application.Current!.MainPage!.DisplayAlert("Switch toggled (Event)", $"New value: {e.Value}", "OK").ConfigureAwait(false);
		}
	}
}