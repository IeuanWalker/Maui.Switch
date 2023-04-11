using Microsoft.Maui.Handlers;
using IeuanWalker.Maui.Switch.Interfaces;
using IeuanWalker.Maui.Switch.Platform;

namespace IeuanWalker.Maui.Switch.Handler;
public partial class SwitchViewHandler : ContentViewHandler, ISwitchViewHandler
{
	protected override CustomContentViewGroup CreatePlatformView()
	{
		_ = VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} must be set to create a CustomContentViewGroup");
		_ = MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null");

		var viewGroup = new CustomContentViewGroup(Context, VirtualView);
		viewGroup.SetClipChildren(false);

		return viewGroup;
	}
	public static void MapIsToggled(ISwitchViewHandler handler, IContentView contentView)
	{
		if (handler.PlatformView is CustomContentViewGroup platformView && contentView is ISwitchView switchView)
		{
			platformView.SetIsToggled();
		}
	}
}