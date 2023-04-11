using Microsoft.Maui.Handlers;
using IeuanWalker.Maui.Switch.Platform;

namespace IeuanWalker.Maui.Switch.Handler;
public partial class SwitchViewHandler : ContentViewHandler, ISwitchViewHandler
{
	protected override CustomContentView CreatePlatformView()
	{
		_ = VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} must be set to create a CustomContentView");
		_ = MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null");

		return new CustomContentView(VirtualView);
	}
}