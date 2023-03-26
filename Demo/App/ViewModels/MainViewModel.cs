using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App.ViewModels;

[INotifyPropertyChanged]
public partial class MainViewModel
{
	public bool EnableCommands { get; set; } = true;
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