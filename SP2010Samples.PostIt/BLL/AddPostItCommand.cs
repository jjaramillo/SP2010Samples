using System.Collections.Generic;
using Microsoft.SharePoint;
using SP2010Samples.PostIt.Core.Commands;
using SP2010Samples.PostIt.Core.Commands.SPFolder;
using SP2010Samples.PostIt.Core.Commands.SPListItem;

namespace SP2010Samples.PostIt.BLL
{
    public class AddPostItCommand : SPCommandCollection
    {
        private Dictionary<string, object> _properties;
        private string _listName;

        public AddPostItCommand(string listName, Dictionary<string, object> properties, SPWeb web) : base(web)
        {
            _properties = properties;
            _listName = listName;
        }

        public override void Execute()
        {
            AddPostIt();
        }

        private void AddPostIt()
        {
            SPUser currentUser = SPContext.Current.Web.CurrentUser;
            int currentUserID = currentUser.ID;

            AddFolderCommand addFolderCommand = new AddFolderCommand(_listName, currentUserID.ToString(), _web);
            addFolderCommand.Execute();
            _commands.Push(addFolderCommand);

            AddItemCommand addItemCommand = new AddItemCommand(addFolderCommand.List,currentUserID.ToString(), _web);
            addItemCommand.Execute();
            _commands.Push(addItemCommand);
        }
    }
}
