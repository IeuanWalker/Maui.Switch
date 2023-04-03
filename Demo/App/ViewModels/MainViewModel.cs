using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App.ViewModels;

public partial class MainViewModel : ObservableObject
{
	public bool EnableCommands { get; set; }
	public bool EnableEvents { get; set; }

	[RelayCommand]
	public async Task Toggled(bool value)
	{
		if (EnableCommands)
		{
			await Application.Current!.MainPage!.DisplayAlert("Switch toggled (Command)", $"New value: {value}", "OK").ConfigureAwait(false);
		}
	}
}