namespace CustomSwitch;
public interface ISwitchView : IView, IPadding
{
	bool IsToggled { get; set; }
	/// <summary>
	/// Gets the raw content of this view.
	/// </summary>
	object? Content { get; }
}
