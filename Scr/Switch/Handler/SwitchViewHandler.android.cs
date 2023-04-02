using Microsoft.Maui.Handlers;

namespace IeuanWalker.Maui.Switch.Handler;
public partial class SwitchViewHandler : ContentViewHandler, ISwitchViewHandler
{
	protected override CustomContentViewGroup CreatePlatformView()
	{
		if (VirtualView == null)
		{
			throw new InvalidOperationException($"{nameof(VirtualView)} must be set to create a ContentViewGroup");
		}

		var viewGroup = new CustomContentViewGroup(Context, VirtualView);
		viewGroup.SetClipChildren(false);

		return viewGroup;
	}
	public static void MapIsToggled(ISwitchViewHandler handler, IContentView contentView)
	{
		if (handler.PlatformView is CustomContentViewGroup platformView && contentView is ISwitchView switchView)
		{
			platformView.SetIsToggled(switchView.IsToggled);
		}
	}
}