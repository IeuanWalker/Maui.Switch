using App.ViewModels;

namespace App.Pages;

public partial class SwitchViewPage : ContentPage
{
	readonly SwitchViewModel _viewModel;

	public SwitchViewPage()
	{
		InitializeComponent();

		BindingContext = _viewModel = new SwitchViewModel();
	}

	async void Switch_OnToggled(object sender, ToggledEventArgs e)
	{
		if (_viewModel.EnableEvents)
		{
			await Application.Current!.Windows[0].Page!.DisplayAlert("Switch toggled (Event)", $"New value: {e.Value}", "OK").ConfigureAwait(false);
		}
	}
}