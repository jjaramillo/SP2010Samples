using System.Collections.Generic;
using Microsoft.SharePoint;

namespace SP2010Samples.PostIt.Core.Commands
{
    public abstract class SPCommandCollection : SPCommand
    {
        protected Stack<SPCommand> _commands;

        public SPCommandCollection(SPWeb web) : base(web)
        {
            _commands = new Stack<SPCommand>();
        }

        public override void Undo()
        {
            while (_commands.Count > 0) { _commands.Pop().Undo(); }
        }
    }
}
