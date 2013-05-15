
namespace SP2010Samples.SPTransactionalPattern
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
