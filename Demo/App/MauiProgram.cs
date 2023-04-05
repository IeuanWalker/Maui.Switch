using CommunityToolkit.Maui;
using IeuanWalker.Maui.Switch;
using StateButton;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("FA-Solid-900.otf", "FASolid900");
			})
			.UseCustomSwitch()
			.UseSkiaSharp()
			.ConfigureStateButton();

		return builder.Build();
	}
}