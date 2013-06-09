using System;
using System.Collections.Generic;
using System.Linq;
using SP = Microsoft.SharePoint;

namespace SP2010Samples.PostIt.Core.Commands.SPFolder
{
    public class UpdateCommand : SPCommand
    {
        protected SP.SPListItem _item;
        protected Dictionary<string, object> _oldPropertiesValues;
        protected Dictionary<string, object> _newPropertiesValues;

        public SP.SPListItem Item { get { return _item; } }

        public UpdateCommand(SP.SPFolder folder, Dictionary<string, object> properties)
            : base()
        {
            _web = folder.ParentWeb;
            _item = folder.Item;
            _newPropertiesValues = properties;
            BackUpOldPropertiesValues();
        }

        public UpdateCommand(int itemID, string listName, Dictionary<string, object> properties, SP.SPWeb web)
            : base(web)
        {
            SP.SPList targetList = _web.Lists.TryGetList(listName);
            if (targetList == default(SP.SPList)) { throw new Exception(string.Format("Could not find any list with the name {0}", listName)); }
            _item = targetList.GetItemByIdSelectedFields(itemID, properties.Keys.ToArray());
            BackUpOldPropertiesValues();
        }

        public UpdateCommand(string folderUrl, Dictionary<string, object> properties, SP.SPWeb web)
            : base(web)
        {
            SP.SPFolder folder = _web.GetFolder(folderUrl);
            if (!folder.Exists) { throw new Exception(string.Format("Could not find any folder with the url {0}", folder)); }
            _item = folder.Item;
            BackUpOldPropertiesValues();
        }

        public override void Execute()
        {
            UpdateProperties();
        }

        public override void Undo()
        {
            RestoreOldPropertiesValues();
        }

        protected virtual void UpdateProperties()
        {
            foreach (KeyValuePair<string, object> currentProperty in _newPropertiesValues)
            {
                _item[currentProperty.Key] = currentProperty.Value;
            }
            _item.UpdateOverwriteVersion();
        }

        protected virtual void BackUpOldPropertiesValues()
        {
            foreach (KeyValuePair<string, object> currentProperty in _newPropertiesValues)
            {
                _oldPropertiesValues.Add(currentProperty.Key, _item[currentProperty.Key]);
            }
        }

        protected virtual void RestoreOldPropertiesValues()
        {
            foreach (KeyValuePair<string, object> currentProperty in _oldPropertiesValues)
            {
                _item[currentProperty.Key] = currentProperty.Value;
            }
            _item.SystemUpdate();
        }
    }
}
