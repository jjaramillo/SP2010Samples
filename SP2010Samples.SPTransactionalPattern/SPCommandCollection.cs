using System.Collections.Generic;
using Microsoft.SharePoint;

namespace SP2010Samples.SPTransactionalPattern
{
    public abstract class SPCommandCollection : SPCommand
    {
        protected Stack<ICommand> _Commands;

        public SPCommandCollection(SPListItem item, SPWeb web)
            : base(item, web)
        {
            _Commands = new Stack<ICommand>();
        }

        public SPCommandCollection(SPWeb web)
            : base(web)
        {
            _Commands = new Stack<ICommand>();
        }

        public override void Undo()
        {
            while (_Commands.Count > 0) { _Commands.Pop().Undo(); }
        }
    }
}
