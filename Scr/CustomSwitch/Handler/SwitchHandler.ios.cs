using Microsoft.Maui.Handlers;
using UIKit;

namespace CustomSwitch.Handler;
public partial class SwitchHandler : ViewHandler<SwitchView, UIView>
{
	protected override UIView CreatePlatformView()	
	{
		return new UIView();
	}

	public static void MapIsToggled(object handler, SwitchView switchView) => throw new NotImplementedException();
	public static void MapContent(object handler, SwitchView switchView) => throw new NotImplementedException();

}
