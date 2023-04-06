using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Java.Lang;
using Microsoft.Maui.Platform;
using String = Java.Lang.String;
using IeuanWalker.Maui.Switch.Interfaces;

namespace IeuanWalker.Maui.Switch.Platform;
public class CustomContentViewGroup : ContentViewGroup
{
	readonly Android.Widget.Switch _a11YSwitch;
	readonly ISwitchView _switchView;
	public CustomContentViewGroup(Context context, IContentView virtualView) : base(context)
	{
		_a11YSwitch = new Android.Widget.Switch(context);

		_switchView = (ISwitchView)virtualView;
		_a11YSwitch.Checked = _switchView.IsToggled;

		//! important - this is what makes the switch accessible via keyboard navigation
		Focusable = true;
		Clickable = true;
	}

	public void SetIsToggled(bool isToggled)
	{
		if (_a11YSwitch.Checked != isToggled)
		{
			_a11YSwitch.Checked = isToggled;
			AnnounceForAccessibility(GetStateDescription());
		}
	}

	public override ICharSequence? AccessibilityClassNameFormatted => new String(_a11YSwitch.Class.Name);

	public override void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo? info)
	{
		if (info is not null)
		{
			info.Focusable = true;
			info.Checkable = true;
			info.Checked = _a11YSwitch.Checked;
			info.Text = GetStateDescription();
		}

		base.OnInitializeAccessibilityNodeInfo(info);
	}

	string? GetStateDescription()
	{
		return _a11YSwitch.Checked ? _a11YSwitch.TextOn : _a11YSwitch.TextOff;
	}

	public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent? e)
	{
		if (keyCode == Keycode.Space || keyCode == Keycode.Enter)
		{
			_switchView.IsToggled = !_switchView.IsToggled;
		}

		return base.OnKeyUp(keyCode, e);
	}
}