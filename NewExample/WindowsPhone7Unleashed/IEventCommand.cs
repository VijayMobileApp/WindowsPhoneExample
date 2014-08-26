

using System.Windows.Input;
namespace NewExample.WindowsPhone7Unleashed
{
    public interface IEventCommand : ICommand
    {
        string EventName { get; }
    }
}
