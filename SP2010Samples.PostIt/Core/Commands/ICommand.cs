
namespace SP2010Samples.PostIt.Core.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
