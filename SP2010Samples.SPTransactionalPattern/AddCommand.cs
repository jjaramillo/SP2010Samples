using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace SP2010Samples.SPTransactionalPattern
{
    public class AddCommand : SPCommand
    {
        protected string _ListName;

        public AddCommand(SPWeb web, string listName) : base(web)
        {
            _ListName = listName;
        }

        private void AddItem()
        {
            SPList targetList = _Web.Lists.TryGetList(_ListName);
            if (targetList == default(SPList)) { throw new Exception(string.Format( "Could not found any list with the title {0}", _ListName)); }
            _Item = targetList.AddItem();
        }

        private void DeleteItem()
        {
            _Item.Delete();
        }

        public override void Execute()
        {
            AddItem();
        }        

        public override void Undo()
        {
            DeleteItem();
        }
    }
}
