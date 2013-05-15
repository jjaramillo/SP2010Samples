using Microsoft.SharePoint;

namespace SP2010Samples.SPTransactionalPattern
{
    public abstract class SPCommand : ICommand
    {
        protected SPListItem _Item;
        protected SPWeb _Web;

        public SPListItem Item { get { return _Item; } }
        public SPWeb Web { get { return _Web; } }

        public SPCommand(SPListItem item, SPWeb web)
        {
            _Item = item;
            _Web = web;
        }

        public SPCommand(SPWeb web)
        {
            _Web = web;
        }

        public abstract void Execute();

        public abstract void Undo();

    }
}
