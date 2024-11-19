using Android.Content;
using Android.Views.Accessibility;
using IeuanWalker.Maui.Switch.Interfaces;
using Java.Lang;
using Microsoft.Maui.Platform;
using String = Java.Lang.String;

namespace IeuanWalker.Maui.Switch.Platform;
public class CustomContentViewGroup : ContentViewGroup
{
	readonly string _textOn;
	readonly string _textOff;

	readonly ISwitchView _switchView;
	public CustomContentViewGroup(Context context, IContentView virtualView) : base(context)
	{
		var tempSwitch = new Android.Widget.Switch(context);
		_textOn = tempSwitch.TextOn ?? "On";
		_textOff = tempSwitch.TextOff ?? "Off";

		_switchView = (ISwitchView)virtualView;

		//! important - this is what makes the switch accessible
		Clickable = true;
		Click += (sender, e) => _switchView.IsToggled = !_switchView.IsToggled;
	}

	public override ICharSequence? AccessibilityClassNameFormatted => new String("android.widget.Switch");

	public override void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo? info)
	{
		if(info is not null)
		{
			info.Checkable = true;
			info.Checked = _switchView.IsToggled;
			info.Text = _switchView.IsToggled ? _textOn : _textOff;
		}

		base.OnInitializeAccessibilityNodeInfo(info);
	}
}