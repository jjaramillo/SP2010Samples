using System;
using SP =Microsoft.SharePoint;

namespace SP2010Samples.PostIt.Core.Commands.SPListItem
{
    public class DeleteCommand : SPCommand
    {
        protected SP.SPListItem _item;
        protected Guid _recycleBinItemID;

        public SP.SPListItem Item { get { return _item; } }
        public Guid RecycleBinItemID { get { return _recycleBinItemID; } }

        public DeleteCommand(SP.SPListItem item)
            : base()
        {
            _web = item.Web;
            _item = item;
        }

        public DeleteCommand(int itemID, string listName, SP.SPWeb web)
            : base(web)
        {
            SP.SPList targetList = _web.Lists.TryGetList(listName);
            if (targetList == default(SP.SPList)) { throw new Exception(string.Format("Could not find any list with the name {0}", listName)); }
            _item = targetList.GetItemByIdSelectedFields(itemID);
        }

        public override void Execute()
        {
            RecycleItem();
        }

        public override void Undo()
        {
            RestoreItem();
        }

        protected virtual void RecycleItem()
        {
            _recycleBinItemID = _item.Recycle();
        }

        protected virtual void RestoreItem()
        {
            _web.RecycleBin.Restore(new Guid[] { _recycleBinItemID });
        }
    }
}
