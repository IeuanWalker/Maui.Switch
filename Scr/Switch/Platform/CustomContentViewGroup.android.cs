using Android.Content;
using Android.Views.Accessibility;
using Java.Lang;
using Microsoft.Maui.Platform;
using String = Java.Lang.String;
using IeuanWalker.Maui.Switch.Interfaces;

namespace IeuanWalker.Maui.Switch.Platform;
public class CustomContentViewGroup : ContentViewGroup
{
	// TODO: Allow user to set these values
	const string textOn = "Yes";
	const string textOff = "No";

	readonly ISwitchView _switchView;
	public CustomContentViewGroup(Context context, IContentView virtualView) : base(context)
	{
		_switchView = (ISwitchView)virtualView;

		//! important - this is what makes the switch accessible
		Clickable = true;
		Click += (sender, e) => _switchView.IsToggled = !_switchView.IsToggled;
	}

	public void SetIsToggled()
	{
		AnnounceForAccessibility(_switchView.IsToggled ? textOn : textOff);
	}

	public override void SendAccessibilityEventUnchecked(AccessibilityEvent? e)
	{
		//! important - used to override the default On/Off announcement when it is toggled. Now handled manually in the `SetIsToggled` method
		if (e?.EventType.Equals(EventTypes.ViewClicked) ?? false)
		{
			return;
		}

		base.SendAccessibilityEventUnchecked(e);
	}

	public override ICharSequence? AccessibilityClassNameFormatted => new String("android.widget.Switch");

	public override void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo? info)
	{
		if (info is not null)
		{
			info.Checkable = true;
			info.Checked = _switchView.IsToggled;
			info.Text = _switchView.IsToggled ? textOn : textOff;
		}

		base.OnInitializeAccessibilityNodeInfo(info);
	}
}