using IeuanWalker.Maui.Switch.Interfaces;
using UIKit;
using ContentView = Microsoft.Maui.Platform.ContentView;

namespace IeuanWalker.Maui.Switch.Platform;
public class CustomContentView : ContentView
{
	readonly UIAccessibilityTrait _switchUIAccessibilityTrait;
	readonly ISwitchView _switchView;
	public CustomContentView(IContentView virtualView)
	{
		_switchView = (ISwitchView)virtualView;
		_switchUIAccessibilityTrait = new UISwitch().AccessibilityTraits;

		IsAccessibilityElement = true;
	}

	public override string? AccessibilityValue
	{
		get => _switchView.IsToggled ? "1" : "0";
	}

	public override UIAccessibilityTrait AccessibilityTraits
	{
		get => _switchUIAccessibilityTrait;
	}
}