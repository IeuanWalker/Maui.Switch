using System.ComponentModel;
using System.Windows.Input;
using CustomSwitch.Enums;
using CustomSwitch.Events;
using CustomSwitch.Handler;
using Microsoft.Maui.Controls.Shapes;

namespace CustomSwitch;

public partial class CustomSwitch : SwitchView
{
	#region Properties

	// General properties
	SwitchStateEnum CurrentState { get; set; }

	double _xRef;

	public static readonly BindableProperty ToggleAnimationDurationProperty = BindableProperty.Create(nameof(ToggleAnimationDuration), typeof(int), typeof(CustomSwitch), 100);

	public int ToggleAnimationDuration
	{
		get => (int)GetValue(ToggleAnimationDurationProperty);
		set => SetValue(ToggleAnimationDurationProperty, value);
	}

	// Background Properties
	public static new readonly BindableProperty HeightRequestProperty = BindableProperty.Create(nameof(HeightRequest), typeof(double), typeof(CustomSwitch), 0d, propertyChanged: SizeRequestChanged);

	public new double HeightRequest
	{
		get => (double)GetValue(HeightRequestProperty);
		set => SetValue(HeightRequestProperty, value);
	}

	public static new readonly BindableProperty WidthRequestProperty = BindableProperty.Create(nameof(WidthRequest), typeof(double), typeof(CustomSwitch), 0d, propertyChanged: SizeRequestChanged);

	public new double WidthRequest
	{
		get => (double)GetValue(WidthRequestProperty);
		set => SetValue(WidthRequestProperty, value);
	}

	public static readonly BindableProperty StrokeShapeProperty = BindableProperty.Create(nameof(StrokeShape), typeof(IShape), typeof(CustomSwitch), new Rectangle());

	[TypeConverter(typeof(StrokeShapeTypeConverter))]
	public IShape? StrokeShape
	{
		set { SetValue(StrokeShapeProperty, value); }
		get { return (IShape?)GetValue(StrokeShapeProperty); }
	}

	public static readonly BindableProperty StrokeProperty = BindableProperty.Create(nameof(Stroke), typeof(Brush), typeof(CustomSwitch), Brush.Default);

	[TypeConverter(typeof(BrushTypeConverter))]
	public Brush Stroke
	{
		get => (Brush)GetValue(StrokeProperty);
		set => SetValue(StrokeProperty, value);
	}

	public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create(nameof(StrokeThickness), typeof(double), typeof(CustomSwitch), 0d);

	public double StrokeThickness
	{
		get => (double)GetValue(StrokeThicknessProperty);
		set => SetValue(StrokeThicknessProperty, value);
	}

	public static new readonly BindableProperty BackgroundProperty = BindableProperty.Create(nameof(Background), typeof(Brush), typeof(CustomSwitch), Brush.Default);

	[TypeConverter(typeof(BrushTypeConverter))]
	public new Brush Background
	{
		get => (Brush)GetValue(BackgroundProperty);
		set => SetValue(BackgroundProperty, value);
	}

	public static new readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(CustomSwitch), Colors.Transparent);

	public new Color BackgroundColor
	{
		get => (Color)GetValue(BackgroundColorProperty);
		set => SetValue(BackgroundColorProperty, value);
	}

	public static readonly BindableProperty BackgroundContentProperty = BindableProperty.Create(nameof(BackgroundContent), typeof(View), typeof(CustomSwitch));

	public View BackgroundContent
	{
		get => (View)GetValue(BackgroundContentProperty);
		set => SetValue(BackgroundContentProperty, value);
	}

	// Knob properties

	public static readonly BindableProperty KnobHeightProperty = BindableProperty.Create(nameof(KnobHeight), typeof(double), typeof(CustomSwitch), 0d, propertyChanged: SizeRequestChanged);

	public double KnobHeight
	{
		get => (double)GetValue(KnobHeightProperty);
		set => SetValue(KnobHeightProperty, value);
	}

	public static readonly BindableProperty KnobWidthProperty = BindableProperty.Create(nameof(KnobWidth), typeof(double), typeof(CustomSwitch), 0d, propertyChanged: SizeRequestChanged);

	public double KnobWidth
	{
		get => (double)GetValue(KnobWidthProperty);
		set => SetValue(KnobWidthProperty, value);
	}

	public static readonly BindableProperty KnobBackgroundProperty = BindableProperty.Create(nameof(KnobBackground), typeof(Brush), typeof(CustomSwitch), Brush.Default);

	[TypeConverter(typeof(BrushTypeConverter))]
	public Brush KnobBackground
	{
		get => (Brush)GetValue(KnobBackgroundProperty);
		set => SetValue(KnobBackgroundProperty, value);
	}

	public static readonly BindableProperty KnobColorProperty = BindableProperty.Create(nameof(KnobColor), typeof(Color), typeof(CustomSwitch), Colors.Transparent);

	public Color KnobColor
	{
		get => (Color)GetValue(KnobColorProperty);
		set => SetValue(KnobColorProperty, value);
	}

	public static readonly BindableProperty KnobStrokeShapeProperty = BindableProperty.Create(nameof(KnobStrokeShape), typeof(IShape), typeof(CustomSwitch), new Rectangle());

	[TypeConverter(typeof(StrokeShapeTypeConverter))]
	public IShape? KnobStrokeShape
	{
		set { SetValue(KnobStrokeShapeProperty, value); }
		get { return (IShape?)GetValue(KnobStrokeShapeProperty); }
	}

	public static readonly BindableProperty KnobStrokeProperty = BindableProperty.Create(nameof(KnobStroke), typeof(Brush), typeof(CustomSwitch), Brush.Default);

	[TypeConverter(typeof(BrushTypeConverter))]
	public Brush KnobStroke
	{
		get => (Brush)GetValue(KnobStrokeProperty);
		set => SetValue(KnobStrokeProperty, value);
	}

	public static readonly BindableProperty KnobStrokeThicknessProperty = BindableProperty.Create(nameof(KnobStrokeThickness), typeof(double), typeof(CustomSwitch), 0d);

	public double KnobStrokeThickness
	{
		get => (double)GetValue(KnobStrokeThicknessProperty);
		set => SetValue(KnobStrokeThicknessProperty, value);
	}

	public static readonly BindableProperty KnobContentProperty = BindableProperty.Create(nameof(KnobContent), typeof(View), typeof(CustomSwitch));

	public View KnobContent
	{
		get => (View)GetValue(KnobContentProperty);
		set => SetValue(KnobContentProperty, value);
	}

	public static readonly BindableProperty HorizontalKnobMarginProperty = BindableProperty.Create(nameof(HorizontalKnobMargin), typeof(double), typeof(CustomSwitch), 0d, propertyChanged: SizeRequestChanged);

	public double HorizontalKnobMargin
	{
		get => (double)GetValue(HorizontalKnobMarginProperty);
		set => SetValue(HorizontalKnobMarginProperty, value);
	}

	public static readonly BindableProperty KnobLimitProperty = BindableProperty.Create(nameof(KnobLimit), typeof(KnobLimitEnum), typeof(CustomSwitch), KnobLimitEnum.Boundary, propertyChanged: SizeRequestChanged);

	public KnobLimitEnum KnobLimit
	{
		get => (KnobLimitEnum)GetValue(KnobLimitProperty);
		set => SetValue(KnobLimitProperty, value);
	}

	#endregion Properties

	#region Commands

	public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(CustomSwitch));

	public ICommand ToggledCommand
	{
		get => (ICommand)GetValue(ToggledCommandProperty);
		set => SetValue(ToggledCommandProperty, value);
	}

	#endregion Commands

	#region Events

	public event EventHandler<ToggledEventArgs>? Toggled;

	public event EventHandler<SwitchPanUpdatedEventArgs>? SwitchPanUpdate;

	#endregion Events

	public CustomSwitch()
	{
		InitializeComponent();

		CurrentState = IsToggled ? SwitchStateEnum.Right : SwitchStateEnum.Left;

		KnobFrame.SetBinding(ContentProperty, new Binding(nameof(KnobContent)) { Source = this, Mode = BindingMode.TwoWay });
	}

	void SwitchLoaded(object sender, EventArgs e)
	{
		if (IsToggled)
		{
			GoToRight(100);
		}
		else
		{
			GoToLeft(100);
		}
	}

	static void IsToggledChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is not CustomSwitch view)
		{
			return;
		}

		if ((bool)newValue && view.CurrentState != SwitchStateEnum.Right)
		{
			view.GoToRight();
		}
		else if (!(bool)newValue && view.CurrentState != SwitchStateEnum.Left)
		{
			view.GoToLeft();
		}

		view.Toggled?.Invoke(view, new ToggledEventArgs((bool)newValue));
		view.ToggledCommand?.Execute((bool)newValue);
	}

	void GoToLeft(double percentage = 0.0)
	{
		if (Math.Abs(KnobFrame.TranslationX + _xRef) > 0.0)
		{
			this.AbortAnimation("SwitchAnimation");
			new Animation
			{
				{0, 1, new Animation(v => KnobFrame.TranslationX = v, KnobFrame.TranslationX, -_xRef)},
				{0, 1, new Animation(_ => SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running))}
			}.Commit(this, "SwitchAnimation", 16, Convert.ToUInt32(ToggleAnimationDuration - (ToggleAnimationDuration * percentage / 100)), null, (_, __) =>
			{
				this.AbortAnimation("SwitchAnimation");
				CurrentState = SwitchStateEnum.Left;
				IsToggled = false;
				SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
			});
		}
		else
		{
			this.AbortAnimation("SwitchAnimation");
			CurrentState = SwitchStateEnum.Left;
			IsToggled = false;
			SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
		}
	}

	void GoToRight(double percentage = 0.0)
	{
		if (Math.Abs(KnobFrame.TranslationX - _xRef) > 0.0)
		{
			this.AbortAnimation("SwitchAnimation");

			IsToggled = true;
			new Animation
			{
				{0, 1, new Animation(v => KnobFrame.TranslationX = v, KnobFrame.TranslationX, _xRef)},
				{0, 1, new Animation(_ => SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running))}
			}.Commit(this, "SwitchAnimation", 16, Convert.ToUInt32(ToggleAnimationDuration - (ToggleAnimationDuration * percentage / 100)), null, (_, __) =>
			{
				this.AbortAnimation("SwitchAnimation");
				CurrentState = SwitchStateEnum.Right;
				SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
			});
		}
		else
		{
			this.AbortAnimation("SwitchAnimation");
			CurrentState = SwitchStateEnum.Right;
			IsToggled = true;
			SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
		}
	}

	void SendSwitchPanUpdatedEventArgs(PanStatusEnum status)
	{
		SwitchPanUpdatedEventArgs ev = new()
		{
			XRef = _xRef,
			IsToggled = IsToggled,
			TranslateX = KnobFrame.TranslationX,
			Status = status,
			Percentage = IsToggled
				? Math.Abs(KnobFrame.TranslationX - _xRef) / (2 * _xRef) * 100
				: Math.Abs(KnobFrame.TranslationX + _xRef) / (2 * _xRef) * 100
		};

		if (!double.IsNaN(ev.Percentage))
		{
			SwitchPanUpdate?.Invoke(this, ev);
		}
	}

	void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		SendSwitchPanUpdatedEventArgs(PanStatusEnum.Started);
		if (CurrentState == SwitchStateEnum.Right)
		{
			GoToLeft();
		}
		else
		{
			GoToRight();
		}
	}

	double _tmpTotalX;

	void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
	{
		this.AbortAnimation("SwitchAnimation");
		double dragX = e.TotalX - _tmpTotalX;

		switch (e.StatusType)
		{
			case GestureStatus.Started:
				SendSwitchPanUpdatedEventArgs(PanStatusEnum.Started);
				break;

			case GestureStatus.Running:
				KnobFrame.TranslationX = Math.Min(_xRef, Math.Max(-_xRef, KnobFrame.TranslationX + dragX));
				_tmpTotalX = e.TotalX;
				SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running);
				break;

			case GestureStatus.Completed:
				double percentage = IsToggled
					? Math.Abs(KnobFrame.TranslationX - _xRef) / (2 * _xRef) * 100
					: Math.Abs(KnobFrame.TranslationX + _xRef) / (2 * _xRef) * 100;

				if (KnobFrame.TranslationX > 0)
				{
					GoToRight(percentage);
				}
				else
				{
					GoToLeft(percentage);
				}

				_tmpTotalX = 0;
				break;

			case GestureStatus.Canceled:
				SendSwitchPanUpdatedEventArgs(PanStatusEnum.Canceled);
				break;
		}
	}

	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);

		if (width <= 0 && height <= 0)
		{
			return;
		}

		SizeRequestChanged(this, 0, 0);
	}

	static void SizeRequestChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is not CustomSwitch view)
		{
			return;
		}

		// Knob
		view.KnobFrame.WidthRequest = view.KnobWidth < 0.0 ? view.Width / 2 : view.KnobWidth;
		view.KnobFrame.HeightRequest = view.KnobHeight < 0.0 ? view.Height : view.KnobHeight;

		// Background
		view.BackgroundFrame.WidthRequest = view.WidthRequest < 0.0 ? view.Width : view.WidthRequest;
		view.BackgroundFrame.HeightRequest = view.HeightRequest < 0.0 ? view.Height : view.HeightRequest;

		// View
		view.SetBaseWidthRequest(Math.Max(view.BackgroundFrame.WidthRequest, view.KnobFrame.WidthRequest * 2));

		// Calculate knob position
		switch (view.KnobLimit)
		{
			case KnobLimitEnum.Boundary:
				view._xRef = ((view.BackgroundFrame.WidthRequest - view.KnobFrame.WidthRequest) / 2) - view.HorizontalKnobMargin;
				break;

			case KnobLimitEnum.Centered:
				view._xRef = ((view.BackgroundFrame.WidthRequest - view.KnobFrame.WidthRequest) / 2) - (((view.BackgroundFrame.WidthRequest / 2) - view.KnobFrame.WidthRequest) / 2);
				break;

			case KnobLimitEnum.Max:
				view._xRef = Math.Max(view.BackgroundFrame.WidthRequest, view.KnobFrame.WidthRequest * 2) / 4;
				break;
		}
		view.KnobFrame.TranslationX = view.CurrentState == SwitchStateEnum.Left ? -view._xRef : view._xRef;
	}

	void SetBaseWidthRequest(double widthRequest)
	{
		base.WidthRequest = widthRequest;
	}
}