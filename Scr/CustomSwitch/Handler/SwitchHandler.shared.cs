namespace CustomSwitch.Handler;
public partial class SwitchHandler
{
	public static IPropertyMapper<SwitchView, SwitchHandler> PropertyMapper = new PropertyMapper<SwitchView, SwitchHandler>(ViewMapper)
	{
		[nameof(ISwitchView.IsToggled)] = MapIsToggled,
		[nameof(ISwitchView.Content)] = MapContent
	};

	public static CommandMapper<SwitchView, SwitchHandler> CommandMapper = new(ViewCommandMapper)
	{
	};


	public SwitchHandler() : base(PropertyMapper, CommandMapper)
	{
	}

	public SwitchHandler(IPropertyMapper? mapper) : base(mapper ?? PropertyMapper, CommandMapper)
	{
	}

	public SwitchHandler(IPropertyMapper? mapper, CommandMapper? commandMapper) : base(mapper ?? PropertyMapper, commandMapper ?? CommandMapper)
	{

	}
}
