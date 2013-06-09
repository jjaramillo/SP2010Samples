using Microsoft.SharePoint;

namespace SP2010Samples.PostIt.Core.Commands
{
    public abstract class SPCommand : ICommand
    {
        protected SPWeb _web;

        public SPWeb Web { get { return _web; } }

        public SPCommand(SPWeb web)
        {
            web = _web;
        }

        public SPCommand() { }

        public abstract void Execute();

        public abstract void Undo();

    }
}
