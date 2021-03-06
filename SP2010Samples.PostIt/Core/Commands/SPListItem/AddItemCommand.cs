﻿using System;
using SP = Microsoft.SharePoint;

namespace SP2010Samples.PostIt.Core.Commands.SPListItem
{
    public class AddItemCommand : SPCommand
    {
        protected SP.SPListItem _item;
        protected string _listName;
        protected string _subfolder;
        protected SP.SPList _list;        

        public SP.SPListItem Item { get { return _item; } }
        public string ListName { get { return _listName; } }
        public SP.SPList List { get { return _list; } }

        public AddItemCommand(SP.SPList list, SP.SPWeb web)
            : base(web)
        {
            _listName = list.Title;
            _list = list;
        }

        public AddItemCommand(string listName, SP.SPWeb web)
            : base(web)
        {
            _listName = listName;
            _list = _web.Lists.TryGetList(listName);
            if (_list == default(SP.SPList)) { throw new Exception(string.Format("Could not find any list with the name {0}", listName)); }
        }

        public AddItemCommand(SP.SPList list, string subfolder,SP.SPWeb web)
            : base(web)
        {
            _listName = list.Title;
            _list = list;
            _subfolder = subfolder;
        }

        public AddItemCommand(string listName, string subfolder, SP.SPWeb web)
            : base(web)
        {
            _listName = listName;
            _subfolder = subfolder;
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

        protected void AddElementToList()
        {
            if (string.IsNullOrEmpty(_subfolder)) { _item = _list.AddItem(_subfolder, SP.SPFileSystemObjectType.File); }
            else { _item = _list.AddItem(); }   
        }

        protected void DeleteElementFromList()
        {
            _item.Delete();
        }
    }
}
