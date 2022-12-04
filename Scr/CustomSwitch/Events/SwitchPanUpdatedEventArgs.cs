using CustomSwitch.Enums;

namespace CustomSwitch.Events;

public class SwitchPanUpdatedEventArgs : EventArgs
{
	public double XRef { get; set; }
	public bool IsToggled { get; set; }
	public double TranslateX { get; set; }
	public double Percentage { get; set; }
	public PanStatusEnum Status { get; set; }
}