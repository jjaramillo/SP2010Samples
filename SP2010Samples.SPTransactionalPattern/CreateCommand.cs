using System;
using System.Collections.Generic;
using Microsoft.SharePoint;

namespace SP2010Samples.SPTransactionalPattern
{
    public class CreateCommand : SPCommandCollection
    {
        protected string _ListName;
        protected Dictionary<string, object> _Values;

        public CreateCommand(SPWeb web, Dictionary<string, object> values, string listName)
            : base(web)
        {
            _ListName = listName;
            _Values = values;
        }

        public override void Execute()
        {
            try
            {
                AddCommand addCommand = new AddCommand(_Web, _ListName);
                addCommand.Execute();
                _Commands.Push(addCommand);
                _Item = addCommand.Item;
                UpdateCommand updateCommand = new UpdateCommand(_Item, _Web, _Values);
                updateCommand.Execute();
                _Commands.Push(updateCommand);
            }
            catch (Exception)
            {
                Undo();
                throw;
            }
        }

    }
}
