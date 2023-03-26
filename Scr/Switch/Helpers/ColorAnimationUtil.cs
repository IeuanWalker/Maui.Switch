namespace IeuanWalker.Maui.Switch.Helpers;

public static class ColorAnimationUtil
{
	public static Color ColorAnimation(Color fromColor, Color toColor, double t)
	{
		return Color.FromRgba(fromColor.Red + t * (toColor.Red - fromColor.Red),
			fromColor.Green + t * (toColor.Green - fromColor.Green),
			fromColor.Blue + t * (toColor.Blue - fromColor.Blue),
			fromColor.Alpha + t * (toColor.Alpha - fromColor.Alpha));
	}
}