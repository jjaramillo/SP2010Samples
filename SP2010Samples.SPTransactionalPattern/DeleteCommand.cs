using System;
using Microsoft.SharePoint;

namespace SP2010Samples.SPTransactionalPattern
{
    public class DeleteCommand : SPCommand
    {
        private Guid _RecycledElementId;

        public DeleteCommand(SPListItem item, SPWeb web) : base(item, web) { }

        public override void Execute()
        {
            Delete();
        }

        public override void Undo()
        {
            Restore();
        }

        private void Delete()
        {
            _RecycledElementId = _Item.Recycle();
        }

        private void Restore() 
        {
            _Web.RecycleBin.Restore(new Guid[] { _RecycledElementId });
        }

        
    }
}
