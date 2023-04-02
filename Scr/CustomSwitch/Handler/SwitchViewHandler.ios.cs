using System.Diagnostics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace CustomSwitch.Handler;
public partial class SwitchViewHandler : ContentViewHandler, ISwitchViewHandler
{
	public static void MapIsToggled(ISwitchViewHandler handler, IContentView page)
	{
		if (handler is ISwitchViewHandler invh && invh.ContainerView != null)
		{
			if (page is ISwitchView switchView)
			{
				Debug.WriteLine(switchView.IsToggled);
			}
		}
	}
}
