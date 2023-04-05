using IeuanWalker.Maui.Switch;
using Microsoft.Maui.Controls.Shapes;

namespace App.Controls.SwitchViewExamples;

public partial class BorderSwitch : SwitchView
{
	public BorderSwitch()
	{
		InitializeComponent();

		Loaded += (sender, args) => StyleSwitch();
	}

	void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		IsToggled = !IsToggled;
	}

	protected override void IsToggledChanged()
	{
		base.IsToggledChanged();

		StyleSwitch();
		InvokeToggled();
	}

	void StyleSwitch()
	{
		if (IsToggled)
		{
			SwitchBackground.StrokeShape = new RoundRectangle
			{
				CornerRadius = new CornerRadius(40, 0, 40, 0)
			};
			SwitchBackground.Stroke = new LinearGradientBrush()
			{
				EndPoint = new Point(1, 0),
				GradientStops = new GradientStopCollection
				{
					new GradientStop
					{
						Offset = 0.1f,
						Color = Colors.Transparent
					},
					new GradientStop
					{
						Offset = 1f,
						Color = Color.FromArgb("#a8ff78")
					}
				}
			};
			SwitchBackground.Background = new LinearGradientBrush()
			{
				EndPoint = new Point(1, 0),
				GradientStops = new GradientStopCollection
				{
					new GradientStop
					{
						Offset = 0.1f,
						Color = Colors.Transparent
					},
					new GradientStop
					{
						Offset = 0.5f,
						Color = Color.FromArgb("#78ffd6")
					},
					new GradientStop
					{
						Offset = 1f,
						Color = Color.FromArgb("#a8ff78")
					}
				}
			};
			SwitchText.Text = "On";
		}
		else
		{
			SwitchBackground.StrokeShape = new RoundRectangle
			{
				CornerRadius = new CornerRadius(0, 40, 0, 40)
			};
			SwitchBackground.Stroke = new LinearGradientBrush()
			{
				EndPoint = new Point(1, 0),
				GradientStops = new GradientStopCollection
				{
					new GradientStop
					{
						Offset = 0.1f,
						Color = Color.FromArgb("#FF512F")
					},
					new GradientStop
					{
						Offset = 1f,
						Color = Colors.Transparent
					}
				}
			};
			SwitchBackground.Background = new LinearGradientBrush()
			{
				EndPoint = new Point(1, 0),
				GradientStops = new GradientStopCollection
				{
					new GradientStop
					{
						Offset = 0.1f,
						Color = Color.FromArgb("#DD2476")
					},
					new GradientStop
					{
						Offset = 0.5f,
						Color = Color.FromArgb("#FF512F")
					},
					new GradientStop
					{
						Offset = 1f,
						Color = Colors.Transparent
					}
				}
			};
			SwitchText.Text = "Off";
		}
	}
}