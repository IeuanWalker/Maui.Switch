﻿using IeuanWalker.Maui.Switch.Handler;

namespace IeuanWalker.Maui.Switch;

/// <summary>
/// This class contains CustomSwitch <see cref="MauiAppBuilder"/> extensions.
/// </summary>
public static class AppBuilderExtensions
{
	/// <summary>
	/// Initializes the Switch control
	/// </summary>
	/// <param name="builder"><see cref="MauiAppBuilder"/> generated by <see cref="MauiApp"/>.</param>
	/// <returns><see cref="MauiAppBuilder"/> initialized for <see cref="CustomSwitch"/>.</returns>
	public static MauiAppBuilder UseSwitch(this MauiAppBuilder builder)
	{
		builder.ConfigureMauiHandlers(h => h.AddHandler<SwitchView, SwitchViewHandler>());

		return builder;
	}
}