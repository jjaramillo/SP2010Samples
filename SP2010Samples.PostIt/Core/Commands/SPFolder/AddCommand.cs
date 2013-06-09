using System;
using SP = Microsoft.SharePoint;

namespace SP2010Samples.PostIt.Core.Commands.SPFolder
{
    public class AddCommand : SPCommand
    {
        protected string _listName;
        protected SP.SPList _list;
        protected string _folderName;
        protected SP.SPFolder _folder;

        public AddCommand(SP.SPList list, string folderName, SP.SPWeb web)
            : base(web)
        {
            _listName = list.Title;
            _list = list;
            _folderName = folderName;
        }

        public AddCommand(string listName, string folderName, SP.SPWeb web)
            : base(web)
        {
            _folderName = folderName;
            _list = _web.Lists.TryGetList(listName);
            if (_list == default(SP.SPList)) { throw new Exception(string.Format("Could not find any list with the name {0}", listName)); }
        }

        public override void Execute()
        {
            AddFolderToList();
        }

        public override void Undo()
        {
            DeleteFolderFromList();
        }

        protected virtual void AddFolderToList()
        {
            SP.SPFolderCollection listFolders = _list.RootFolder.SubFolders;
            _folder = listFolders.Add(_folderName);
        }

        protected virtual void DeleteFolderFromList()        
        {
            _folder.Recycle();
        }
    }
}
