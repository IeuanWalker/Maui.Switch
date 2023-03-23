using Microsoft.Maui.Handlers;
namespace CustomSwitch.Handler;
public partial class SwitchViewHandler : ViewHandler<SwitchView, object>
{
	/// <inheritdoc/>
	protected override object CreatePlatformView() => throw new NotImplementedException();

	public static void MapIsToggled(object handler, SwitchView switchView) => throw new NotImplementedException();
	public static void MapContent(object handler, SwitchView switchView) => throw new NotImplementedException();

}
