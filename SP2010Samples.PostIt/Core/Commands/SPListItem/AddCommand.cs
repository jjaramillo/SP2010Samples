using System;
using SP = Microsoft.SharePoint;

namespace SP2010Samples.PostIt.Core.Commands.SPListItem
{
    public class AddCommand : SPCommand
    {
        private SP.SPListItem _item;
        private string _listName;
        private SP.SPList _list;

        public SP.SPListItem Item { get { return _item; } }
        public string ListName { get { return _listName; } }
        public SP.SPList List { get { return _list; } }

        public AddCommand(SP.SPList list, SP.SPWeb web)
            : base(web)
        {
            _listName = list.Title;
            _list = list;
        }

        public AddCommand(string listName, SP.SPWeb web)
            : base(web)
        {
            _listName = listName;
            _list = _web.Lists.TryGetList(listName);
            if (_list == default(SP.SPList)) { throw new Exception(string.Format("Could not find any list with the name {0}", listName)); }
        }

        public override void Execute()
        {
            AddElementToList();
        }

        public override void Undo()
        {
            DeleteElementFromList();
        }

        private void AddElementToList()
        {
            _item = _list.AddItem();
        }

        private void DeleteElementFromList()
        {
            _item.Delete();
        }
    }
}
