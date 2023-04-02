using UIKit;
using ContentView = Microsoft.Maui.Platform.ContentView;

namespace IeuanWalker.Maui.Switch.Handler;
public class CustomContentView : ContentView
{
	readonly UISwitch _a11YSwitch = new();

	public void SetIsToggled(bool isToggled)
	{
		_a11YSwitch.On = isToggled;
	}

	public override string? AccessibilityValue
	{
		get => _a11YSwitch.AccessibilityValue;
	}

	public override UIAccessibilityTrait AccessibilityTraits
	{
		get => _a11YSwitch.AccessibilityTraits;
	}

	public override bool AccessibilityActivate()
	{
		_a11YSwitch.SetState(!_a11YSwitch.On, false);
		return base.AccessibilityActivate();
	}
}
