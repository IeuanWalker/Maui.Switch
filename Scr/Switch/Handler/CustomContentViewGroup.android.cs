using Android.Runtime;
using Android.Views.Accessibility;
using Android.Views;
using Java.Lang;
using Microsoft.Maui.Platform;
using String = Java.Lang.String;

namespace CustomSwitch.Handler;
public class CustomContentViewGroup : ContentViewGroup
{
	readonly Android.Widget.Switch _a11YSwitch;
	readonly ISwitchView _switchView;
	public CustomContentViewGroup(Android.Content.Context context, IContentView virtualView) : base(context)
	{
		_a11YSwitch = new Android.Widget.Switch(context);

		_switchView = (ISwitchView)virtualView;
		_a11YSwitch.Checked = _switchView.IsToggled;

	}

	/// <summary>
	/// Triggered when `IsToggled` is changed
	/// </summary>
	/// <param name="isToggled"></param>
	public void SetIsToggled(bool isToggled)
	{
		if (_a11YSwitch.Checked != isToggled)
		{
			_a11YSwitch.Checked = isToggled;
			AnnounceForAccessibility(GetStateDescription());
		}
	}

	/// <inheritdoc />
	public override ICharSequence? AccessibilityClassNameFormatted => new String(_a11YSwitch.Class.Name);

	/// <inheritdoc />
	public override void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo? info)
	{
		if (info is not null)
		{
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
