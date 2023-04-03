using Microsoft.Maui.Handlers;
using IeuanWalker.Maui.Switch.Interfaces;

namespace IeuanWalker.Maui.Switch.Handler;

public partial class SwitchViewHandler : ContentViewHandler, ISwitchViewHandler
{
	/// <summary>
	/// The default property mapper for this handler.
	/// </summary>
	public static new IPropertyMapper<IContentView, ISwitchViewHandler> Mapper = new PropertyMapper<IContentView, ISwitchViewHandler>(ContentViewHandler.Mapper)
	{
		[nameof(ISwitchView.IsToggled)] = MapIsToggled
	};

	/// <summary>
	/// The default command mapper for this handler.
	/// </summary>
	public static new CommandMapper<IContentView, ISwitchViewHandler> CommandMapper = new(ContentViewHandler.CommandMapper);

	/// <summary>
	/// Initializes a new instance of the <see cref="SwitchViewHandler"/> class.
	/// </summary>
	public SwitchViewHandler() : base(Mapper, CommandMapper)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="SwitchViewHandler"/> class
	/// with custom property and command mappers.
	/// </summary>
	/// <param name="mapper">The custom property mapper to use.</param>
	public SwitchViewHandler(IPropertyMapper? mapper): base(mapper ?? Mapper, CommandMapper)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="SwitchViewHandler"/> class
	/// with custom property and command mappers.
	/// </summary>
	/// <param name="mapper">The custom property mapper to use.</param>
	/// <param name="commandMapper">The custom command mapper to use.</param>
	public SwitchViewHandler(IPropertyMapper? mapper, CommandMapper? commandMapper) : base(mapper ?? Mapper, commandMapper ?? CommandMapper)
	{
	}
}