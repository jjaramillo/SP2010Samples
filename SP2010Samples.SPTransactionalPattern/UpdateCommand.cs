using System.Collections.Generic;
using Microsoft.SharePoint;

namespace SP2010Samples.SPTransactionalPattern
{
    public class UpdateCommand : SPCommand
    {
        protected Dictionary<string, object> _OldValues;
        protected Dictionary<string, object> _NewValues;

        public UpdateCommand(SPListItem item, SPWeb web, Dictionary<string, object> values)
            : base(item, web)
        {
            _NewValues = values;
            _OldValues = new Dictionary<string, object>();
            LoadOldValues();
        }

        private void LoadOldValues()
        {
            foreach (KeyValuePair<string, object> property in _NewValues)
            {
                _OldValues.Add(property.Key, _Item[property.Key]);
            }
        }

        private void Update()
        {
            foreach (KeyValuePair<string, object> property in _NewValues)
            {
                _Item[property.Key] = property.Value;
            }
            _Item.SystemUpdate();
        }

        private void Rollback()
        {
            foreach (KeyValuePair<string, object> property in _OldValues)
            {
                _Item[property.Key] = property.Value;
            }
            _Item.SystemUpdate();
        }

        public override void Execute()
        {
            Update();
        }

        public override void Undo()
        {
            Rollback();
        }


    }
}
