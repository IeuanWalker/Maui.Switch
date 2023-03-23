using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace CustomSwitch.Handler;
public partial class SwitchHandler : ViewHandler<SwitchView, ContentViewGroup>
{
	protected override ContentViewGroup CreatePlatformView()
	{
		if (VirtualView == null)
		{
			throw new InvalidOperationException($"{nameof(VirtualView)} must be set to create a ContentViewGroup");
		}

		var viewGroup = new ContentViewGroup(Context);
		viewGroup.SetClipChildren(false);

		return viewGroup;
	}

	public override void SetVirtualView(IView view)
	{
		base.SetVirtualView(view);
		_ = VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} should have been set by base class.");
		_ = PlatformView ?? throw new InvalidOperationException($"{nameof(PlatformView)} should have been set by base class.");
	}

	static void UpdateContent(SwitchHandler handler)
	{
		_ = handler.PlatformView ?? throw new InvalidOperationException($"{nameof(PlatformView)} should have been set by base class.");
		_ = handler.MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} should have been set by base class.");
		_ = handler.VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} should have been set by base class.");

		handler.PlatformView.RemoveAllViews();

		if (handler.VirtualView is IView view)
		{
			handler.PlatformView.AddView(view.ToPlatform(handler.MauiContext));
		}
	}

	public static void MapContent(SwitchHandler handler, SwitchView page)
	{
		UpdateContent(handler);
	}

	protected override void DisconnectHandler(ContentViewGroup platformView)
	{
		// If we're being disconnected from the xplat element, then we should no longer be managing its children
		platformView.RemoveAllViews();
		base.DisconnectHandler(platformView);
	}

	public static void MapIsToggled(SwitchHandler handler, SwitchView switchView) {}
}
