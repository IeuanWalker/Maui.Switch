namespace CustomSwitch.Handler;
public partial class SwitchViewHandler
{
	public static IPropertyMapper<SwitchView, SwitchViewHandler> PropertyMapper = new PropertyMapper<SwitchView, SwitchViewHandler>(ViewMapper)
	{
		[nameof(ISwitchView.IsToggled)] = MapIsToggled,
		[nameof(ISwitchView.Content)] = MapContent
	};

	public static CommandMapper<SwitchView, SwitchViewHandler> CommandMapper = new(ViewCommandMapper)
	{
	};


	public SwitchViewHandler() : base(PropertyMapper, CommandMapper)
	{
	}

	public SwitchViewHandler(IPropertyMapper? mapper) : base(mapper ?? PropertyMapper, CommandMapper)
	{
	}

	public SwitchViewHandler(IPropertyMapper? mapper, CommandMapper? commandMapper) : base(mapper ?? PropertyMapper, commandMapper ?? CommandMapper)
	{

	}
}
