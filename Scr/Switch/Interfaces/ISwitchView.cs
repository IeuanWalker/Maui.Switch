﻿using System.Windows.Input;

namespace IeuanWalker.Maui.Switch.Interfaces;

public interface ISwitchView : IContentView
{
	bool IsToggled { get; set; }
	ICommand ToggledCommand { get; set; }

	event EventHandler<ToggledEventArgs>? Toggled;
}