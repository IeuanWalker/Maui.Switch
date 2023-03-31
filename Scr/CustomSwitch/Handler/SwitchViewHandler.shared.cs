using Microsoft.Maui.Handlers;

namespace CustomSwitch.Handler;
public partial class SwitchViewHandler : ContentViewHandler, ISwitchViewHandler
{
	public static new IPropertyMapper<IContentView, ISwitchViewHandler> Mapper =
		new PropertyMapper<IContentView, ISwitchViewHandler>(ContentViewHandler.Mapper)
		{
			[nameof(ISwitchView.IsToggled)] = MapIsToggled
		};

	public static new CommandMapper<IContentView, ISwitchViewHandler> CommandMapper =
		new(ContentViewHandler.CommandMapper);

	public SwitchViewHandler() : base(Mapper, CommandMapper)
	{
	}

	public SwitchViewHandler(IPropertyMapper? mapper)
		: base(mapper ?? Mapper, CommandMapper)
	{
	}

	public SwitchViewHandler(IPropertyMapper? mapper, CommandMapper? commandMapper)
		: base(mapper ?? Mapper, commandMapper ?? CommandMapper)
	{
	}
}


public interface ISwitchViewHandler : IContentViewHandler
{
}