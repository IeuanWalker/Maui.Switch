using Microsoft.Maui.Handlers;

namespace IeuanWalker.Maui.Switch.Handler;
public partial class SwitchViewHandler : ContentViewHandler, ISwitchViewHandler
{
	protected override CustomContentView CreatePlatformView()
	{
		return new CustomContentView();
	}
	public static void MapIsToggled(ISwitchViewHandler handler, IContentView contentView)
	{
		if (handler.PlatformView is CustomContentView platformView && contentView is ISwitchView switchView)
		{
			platformView.SetIsToggled(switchView.IsToggled);
		}
	}
}
